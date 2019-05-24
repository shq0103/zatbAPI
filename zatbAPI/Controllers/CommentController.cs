
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            var cUser = Helper.GetCurrentUser(HttpContext);
            return new CommentDao().Get(id);
        }

        // POST api/<controller>
        
        [HttpPost]
        public void Post([FromBody]Comment comment)
        {
            new CommentDao().Insert(comment);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put( [FromBody]Comment comment)
        {
            new CommentDao().Update(comment);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new CommentDao().Delete(id);
        }
    }
}
