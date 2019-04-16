using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models.Post;

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

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Post post)
        {
            new PostDao().Insert(post);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put( [FromBody]Post post)
        {
            new PostDao().Update(post);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new PostDao().Delete(id);
        }
    }
}
