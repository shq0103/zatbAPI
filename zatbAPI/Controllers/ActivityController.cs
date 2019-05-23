using GenModel.Models;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        // GET: api/<controller>
    //    [HttpGet]
 //       public IEnumerable<string> Get()
  //      {
  //          return new string[] { "value1", "value2" };
  //      }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Activity Get(int id)
        {
            return new ActivityDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Activity activity)
        {
            new ActivityDao().Insert(activity);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put( [FromBody]Activity activity)
        {
            new ActivityDao().Update(activity);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new ActivityDao().Delete(id);
        }
    }
}
