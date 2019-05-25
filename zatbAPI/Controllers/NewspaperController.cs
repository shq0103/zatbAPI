
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
        /// <param name="type">类型（1.咨询，2.知识）</param>
        /// <param name="orderBy">排序</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<News> GetNewsList(int? page, int? pageSize, int? type,string orderBy)
        {
            string conditions = " where 1=1";
            if (type != null)
            {
                conditions = string.Format(" where type={0}", type);
            }
            string mOrderBy = "";
            if (orderBy != null)
            {
                mOrderBy = orderBy + " desc";
            }
            var newsList = new NewspaperDao().GetListPaged(page ?? 1, pageSize ?? 20, mOrderBy, null);
            
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
        [HttpPost]
        public RestfulData PostNews([FromBody]News newspaper)
        {
            newspaper.Date = Dateime.GetNowTimestamp();
            new NewspaperDao().Insert(newspaper);
            return new RestfulData { message = "新增成功" };
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]News newspaper)
        {
            new NewspaperDao().Update(newspaper);
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
