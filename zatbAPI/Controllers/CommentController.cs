using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models.Comment;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class CommentController : Controller
    {
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
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
