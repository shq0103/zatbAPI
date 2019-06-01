﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.DbHelper.IRepository;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class TravelBookController : Controller
    {
        /// <summary>
        /// 获取路书列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword">路书名称</param>
        /// <param name="username">用户名</param>
        /// <param name="length">线路长短</param>
        /// <param name="status">状态（选填，0.待审核1.审核通过2.审核不通过）</param>
        /// <param name="orderBy">选填（publishTime.时间，viewCount.浏览量,star点赞量）</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<TravelBookView> GetList(int? page,int? pageSize,string keyword,string username,int? length,int? status,string orderBy)
        {
            string conditions = " where 1=1";
            if (status != null)
            {
                conditions += string.Format(" and status={0}", status);
            }
            if (!string.IsNullOrEmpty(keyword))
            {
                conditions += string.Format(" and title like N'%{0}%'", keyword);
            }
            if (!string.IsNullOrEmpty(username))
            {
                conditions += string.Format(" and username like N'%{0}%'", username);
            }
            if (length != null)
            {
                conditions += string.Format(" and length={0}", length);
            }
            string mOrderBy = "";
            if (orderBy != null)
            {
                mOrderBy = orderBy + " desc";
            }
            var traveltreList = new DaoBase<TravelBookView, int>().GetListPaged(page ?? 1, pageSize ?? 20, conditions, mOrderBy, null);
            var total = new DaoBase<TravelBookView, int>().RecordCount(conditions);
            foreach (var item in traveltreList)
            {
                item.travelPlaces = new DaoBase<TravelPlace, int>().GetList("where bookId=@bookId", new { bookId = item.Id });

                foreach(var ele in item.travelPlaces)
                {
                    ele.imgList = new ImageDao().GetImageList(ele.Id, 4);
                }
            }
            return new RestfulArray<TravelBookView> {
            data=traveltreList,
            total=total
            };
        }
        /// <summary>
        /// 获取当前登录用户发布的路书
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("user")]
        public RestfulArray<TravelBookView> GetUserTravelBook(int? page,int? pageSize)
        {
            var userId = Helper.GetCurrentUser(HttpContext).Id;
            var traveltreList = new DaoBase<TravelBookView, int>().GetListPaged(page ?? 1, pageSize ?? 20, "where userId=@userId", null, new { userId});
            var total = new DaoBase<TravelBookView, int>().RecordCount("where userId=@userId", new { userId });
            foreach (var item in traveltreList)
            {
                item.travelPlaces = new DaoBase<TravelPlace, int>().GetList("where bookId=@bookId", new { bookId = item.Id });

                foreach (var ele in item.travelPlaces)
                {
                    ele.imgList = new ImageDao().GetImageList(ele.Id, 4);
                }
            }
            return new RestfulArray<TravelBookView>
            {
                data=traveltreList,
                total=total
            };
        }
        /// <summary>
        /// 获取某条路书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<TravelBookView> GetTravelBook(int id)
        {
            var tb = new DaoBase<TravelBookView, int>().Get(id);
  
            
            tb.ViewCount += 1;
            new DaoBase<TravelBook, int>().Update(tb);
            tb.travelPlaces = new DaoBase<TravelPlace, int>().GetList("where bookId=@id", new { id });
            foreach(var item in tb.travelPlaces)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 4);
            }
            return new RestfulData<TravelBookView> {
            data=tb};
        }

        /// <summary>
        /// 新增路书
        /// </summary>
        /// <param name="travelBook">路书</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public RestfulData PostTravelBook([FromBody]TravelBook travelBook)
        {
            var cUser = Helper.GetCurrentUser(HttpContext);
            var user = new UserDao().Get(cUser.Id);
            if (user.Status == 1)
            {
                return new RestfulData
                {
                    code = 400,
                    message = "您已被禁言"
                };
            }
            travelBook.PublishTime = Datetime.GetNowTimestamp();
            travelBook.UserId = cUser.Id;
            int travelBookId = new DaoBase<TravelBook, int>().Insert(travelBook)??0;
            foreach(var item in travelBook.travelPlaces)
            {
                item.BookId = travelBookId;
                int placesId= new DaoBase<TravelPlace, int>().Insert(item) ?? 0;
                new ImageDao().InsertImageList(item.imgList, placesId, 4);
            }
            return new RestfulData { };
        }

        /// <summary>
        /// 审核路书
        /// </summary>
        /// <param name="id">路书id</param>
        /// <param name="status">状态（1.通过，2.不通过）</param>
        /// <returns></returns>
        [HttpPut("status")]
        public RestfulData PutTravelBookStatus(int id,int status)
        {
            var book= new DaoBase<TravelBook, int>().Get(id);

            book.Status = status;
            new DaoBase<TravelBook, int>().Update(book);

            new DaoBase<SystemNotice, int>().Insert(new SystemNotice
            {
                Type = 1,
                Status = 0,
                Content = status == 2 ? "您的路书审核不通过，请做出修改！" : "您的路书审核通过！",
                Time = Datetime.GetNowTimestamp(),
                TouserId = book.UserId,

            });
            return new RestfulData {
            message="审核成功"};
        }
        /// <summary>
        /// 更新路书
        /// </summary>
        /// <param name="travelBook">路书实体</param>
        [HttpPut]
        public RestfulData PutTravelBook([FromBody]TravelBook travelBook)
        {
            travelBook.Status = 0;
            new DaoBase<TravelBook, int>().Update(travelBook);
            foreach(var place in travelBook.travelPlaces)
            {
                new DaoBase<TravelPlace, int>().Update(place);
                new ImageDao().UpdateImageList(place.imgList, place.Id, 4);
            }
            return new RestfulData
            {
                message = "更新成功！"
            };
        }

        /// <summary>
        /// 删除路书
        /// </summary>
        /// <param name="id">路书数组id</param>
        [HttpDelete]
        public RestfulData Delete([FromBody]int[] id)
        {
            foreach (var item in id)
            {
                new DaoBase<TravelBook, int>().Delete(item);
                new DaoBase<TravelPlace, int>().DeleteList("where bookId=@bookId", new { bookId = item });
            }

            return new RestfulData
            {
                message = "删除成功！"
            };
        }

        /// <summary>
        /// 点赞
        /// </summary>
        /// <param name="id">点赞id</param>
        /// <param name="type">点赞类型(1.路书,2.打卡点)</param>
        /// <returns></returns>
        [HttpPut("star")]
        public RestfulData PutStar(int id,int type)
        {

            if (type == 1)
            {
                var book = new DaoBase<TravelBook, int>().Get(id);
                book.Star += 1;
                new DaoBase<TravelBook, int>().Update(book);
            }else if (type == 2)
            {
                var place = new DaoBase<TravelPlace, int>().Get(id);
                place.Star += 1;
                new DaoBase<TravelPlace, int>().Update(place);
            }
            return new RestfulData
            {
                message = "更新成功！"
            };
        }
    }
}
