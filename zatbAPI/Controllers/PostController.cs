using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using zatbAPI.DbHelper;
using zatbAPI.DbHelper.IRepository;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class PostController : Controller
    {

        /// <summary>
        /// 获取论坛列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="type">类型（选填1.户外文档，2.装备问答，3.线路问答，4.旅途观光）</param>
        /// <param name="orderBy">排序（选填date发布时间，viewCount浏览量，replyDate最新回复）</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Post> GetPostList(int page,int pageSize,int? type,string orderBy)
        {
            string con = null;
            if (type != null)
            {
                con = string.Format("where type={0}", type);
            }
            string order = null;
            if (!string.IsNullOrEmpty(orderBy))
            {
                order = orderBy + " desc";
            }

            return new RestfulArray<Post>
            {
                data = new PostDao().GetListPaged(page, pageSize, con, order),
                total = new PostDao().RecordCount(con)
            };
        }


        /// <summary>
        /// 用户发帖
        /// </summary>
        /// <param name="post"></param>
        [Authorize]
        [HttpPost]
        public RestfulData Post([FromBody]Post post)
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
            post.UserId = cUser.Id;
            post.Date = Datetime.GetNowTimestamp();
            int i= new PostDao().Insert(post)??0;
            var res = new RestfulData();
            res.message = "新增成功！";
            return res;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public RestfulData Put( [FromBody]Post post)
        {
            new PostDao().Update(post);
            return new RestfulData
            {

            };
        }

        // DELETE api/<controller>/5
        [HttpDelete]
        public RestfulData Delete([FromBody]int[] id)
        {
            foreach (var item in id)
            {
                new DaoBase<Post, int>().Delete(item);
            }

            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
