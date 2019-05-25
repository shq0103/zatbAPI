
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewspaperController : Controller
    {

        /// <summary>
        /// 获取新闻列表
        /// </summary>
        /// <param name="page">当前页</param>
        /// <param name="pageSize">每页数目</param>
        /// <param name="type">类型(选填，1.咨询，2.户外技巧，3.户外常识，4.户外装备,5.户外知识即2、3、4)</param>
        /// <param name="orderBy">排序(选填，date.最新,viewCount.热门)</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<News> GetNewsList(int? page, int? pageSize, int? type,string orderBy)
        {
            string conditions = " where 1=1";
            if (type != null)
            {
                conditions = string.Format(" where type={0}", type);
                if (type == 5)
                {
                    conditions = string.Format(" where type>1");
                }
            }
            string mOrderBy = "";
            if (orderBy != null)
            {
                mOrderBy = orderBy + " desc";
            }
            var newsList = new NewspaperDao().GetListPaged(page ?? 1, pageSize ?? 20, conditions, mOrderBy, null);
            var total = new NewspaperDao().RecordCount(conditions);
            foreach(var item in newsList)
            {
                item.ImgList= new ImageDao().GetImageList(item.Id, 1);
            }
            return new RestfulArray<News>
            {
                data = newsList
            };
        }
        /// <summary>
        /// 读取某条新闻
        /// </summary>
        /// <param name="id">新闻id</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<News> GetNews(int id)
        {
            var news = new NewspaperDao().Get(id);
            news.ImgList = new ImageDao().GetImageList(id, 1);
            news.ViewCount += 1;
            new NewspaperDao().Update(news);
            return new RestfulData<News> {
                data = news
            };
        }

        /// <summary>
        /// 发布新闻
        /// </summary>
        /// <param name="newspaper">新闻实体</param>
        /// <param name="imgList">图片列表</param>
        [HttpPost]
        public RestfulData PostNews([FromBody]News newspaper)
        {
            newspaper.Date = Datetime.GetNowTimestamp();
            int newsId= new NewspaperDao().Insert(newspaper)??0;
            if (newspaper.ImgList != null)
            {
                new ImageDao().InsertImageList(newspaper.ImgList, newsId, 1);

            }
            return new RestfulData { message = "新增成功" };
        }

        /// <summary>
        /// 更新某条新闻
        /// </summary>
        /// <param name="newspaper"></param>
        [HttpPut]
        public RestfulData PutNews([FromBody]News newspaper)
        {
            new NewspaperDao().Update(newspaper);
            new ImageDao().UpdateImageList(newspaper.ImgList, newspaper.Id, 1);
            return new RestfulData
            {
                message = "更新成功"
            };
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            new NewspaperDao().Delete(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
