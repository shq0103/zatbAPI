using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models.Goods;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class GoodsController : Controller
    {


        // GET api/<controller>/5
        [HttpGet("{id}")]
        public Goods Get(int id)
        {
           return new GoodsDao().Get(id);
        }

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]Goods goods)
        {
            new GoodsDao().Insert(goods);
        }

        // PUT api/<controller>/5
        [HttpPut]
        public void Put([FromBody]Goods goods)
        {
            new GoodsDao().Update(goods);
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            new GoodsDao().Delete(id);
        }
    }
}
