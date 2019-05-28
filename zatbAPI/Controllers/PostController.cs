using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    
    public class PostController : Controller
    {

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Post Get(int id)
        {
            return new PostDao().Get(id);
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
            post.UserId = cUser.Id;
            post.Date = DateTime.Now.ToFileTimeUtc();
            int i= new PostDao().Insert(post)??0;
            var res = new RestfulData();
            res.message = "新增成功！";
            return res;
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put( [FromBody]Post post)
        {
            new PostDao().Update(post);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            new PostDao().Delete(id);
            return new RestfulData
            {
                message = "删除成功"
            };
        }
    }
}
