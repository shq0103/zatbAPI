using GenModel.Models;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class NewspaperController : Controller
    {

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public News Get(int id)
        {
            return new NewspaperDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]News newspaper)
        {
            new NewspaperDao().Insert(newspaper);
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put([FromBody]News newspaper)
        {
            new NewspaperDao().Update(newspaper);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new NewspaperDao().Delete(id);
        }
    }
}
