using Microsoft.AspNetCore.Authorization;
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
        /// <param name="type">类型（可选，1.服装2.装备3.其它）</param>
        /// <param name="username">发布者用户名</param>
        /// <param name="keyword">查询参数</param>
        /// <param name="orderBy">viewCount</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<GoodsView> GetGoodsList(int page,int pageSize,int? type,string username,string keyword,string orderBy)
        {
            string con = "where 1=1";
            if (!string.IsNullOrEmpty(keyword))
            {
                con += string.Format(" and name like N'%{0}%'", keyword);
            }
            if (!string.IsNullOrEmpty(username))
            {
                con += string.Format(" and username like N'%{0}%'", username);
            }
            if (type!=null)
            {
                con += string.Format(" and type={0}", type);
            }
            string mOrderBy = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                mOrderBy = orderBy + " desc";
            }
            var data = new DaoBase<GoodsView,int>().GetListPaged(page, pageSize, con, mOrderBy);
            foreach(var item in data)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 3);
            }
            return new RestfulArray<GoodsView>
            {
                data = data,
                total = new DaoBase<GoodsView, int>().RecordCount(con)
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
        /// 获取当前登录用户闲趣
        /// </summary>
        /// <returns></returns>
        [HttpGet("user")]
        public RestfulArray<GoodsView> GetUserGoods()
        {
            var cUser = Helper.GetCurrentUser(HttpContext);
            var good = new DaoBase<GoodsView,int>().GetList(string.Format("select * from goodsView where userId={0}",cUser.Id));
            return new RestfulArray<GoodsView>
            {
                data = good
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
            goods.Time = Datetime.GetNowTimestamp();
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
        public RestfulData Delete(int id)
        {
            new GoodsDao().Delete(id);
            return new RestfulData
            {

            };
        }
    }
}
