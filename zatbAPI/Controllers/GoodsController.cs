﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {
        /// <summary>
        /// 获取商品列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="keyword">查询参数</param>
        /// <param name="orderBy">viewCount</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Goods> GetGoodsList(int page,int pageSize,string keyword,string orderBy)
        {
            string con = "";
            if (string.IsNullOrEmpty(keyword))
            {
                con = string.Format("where name like N'%{0}% or introduction like N'%{0}%'", keyword);
            }
            string mOrderBy = null;
            if (string.IsNullOrEmpty(orderBy))
            {
                mOrderBy = orderBy + " desc";
            }
            var data = new GoodsDao().GetListPaged(page, pageSize, con, mOrderBy);
            foreach(var item in data)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 3);
            }
            return new RestfulArray<Goods>
            {
                data = data,
                total = new GoodsDao().RecordCount(con)
            };
        }

        /// <summary>
        /// 获取某个商品
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData< Goods> GetGoods(int id)
        {
            var good = new GoodsDao().Get(id);
            good.viewCount += 1;
            new GoodsDao().Update(good);
            good.imgList = new ImageDao().GetImageList(id, 3);

            return new RestfulData<Goods>
            {
                data= good
            };
        }

        /// <summary>
        /// 发布商品
        /// </summary>
        /// <param name="goods"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public RestfulData PostGoods([FromBody]Goods goods)
        {
            goods.UserId = Helper.GetCurrentUser(HttpContext).Id;
            int goodsId=new GoodsDao().Insert(goods)??0;
            new ImageDao().InsertImageList(goods.imgList, goodsId, 3);
            return new RestfulData
            {
                message = "新增成功"
            };

        }

        /// <summary>
        /// 更新商品
        /// </summary>
        /// <param name="goods">商品</param>
        [HttpPut]
        public RestfulData PutGoods([FromBody]Goods goods)
        {
            new GoodsDao().Update(goods);
            new ImageDao().UpdateImageList(goods.imgList, goods.Id, 3);
            return new RestfulData
            {

            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new GoodsDao().Delete(id);
        }
    }
}
