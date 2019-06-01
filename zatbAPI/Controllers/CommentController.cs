
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
    [Authorize]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        /// <summary>
        /// 获取评论列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="toId">针对的id</param>
        /// <param name="type">类型（1.打卡点，2.论坛,3.新闻）</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<Comment> GetCommentList(int page,int pageSize,int? toId,int? type)
        {
            string con = "where 1=1";
            if (toId != null)
            {
                con += string.Format(" and toId={0}", toId);
            }
            if (type != null)
            {
                con += string.Format(" and type={0}", type);
            }
            return new RestfulArray<Comment>
            {
                data=new CommentDao().GetListPaged(page,pageSize,con,"time"),
                total= new CommentDao().RecordCount(con)
            };
        }

        /// <summary>
        /// 评论
        /// </summary>
        /// <param name="comment">评论</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public RestfulData Post([FromBody]Comment comment)
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
            comment.Time = Datetime.GetNowTimestamp();
            comment.UserId= Helper.GetCurrentUser(HttpContext).Id;
            new CommentDao().Insert(comment);
            if (comment.Type == 2)
            {
                var date = new PostDao().Get(comment.ToId);
                date.replyDate = Datetime.GetNowTimestamp();
                new PostDao().Update(date);
            }
            return new RestfulData
            {
                message = "评论成功！"
            };
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete]
        public RestfulData Delete([FromBody]int[] id)
        {
            foreach (var item in id)
            {
                new DaoBase<Comment, int>().Delete(item);
            }

            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
