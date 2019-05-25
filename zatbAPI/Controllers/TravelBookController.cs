using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    [Route("api/[controller]")]
    public class TravelBookController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取某条路书
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<TravelBook> GetTravelBook(int id)
        {
            var tb = new DaoBase<TravelBook, int>().Get(id);
            tb.Nickname = new UserDao().Get(tb.UserId).Nickname;
            
            tb.ViewCount += 1;
            new DaoBase<TravelBook, int>().Update(tb);
            tb.travelPlaces = new DaoBase<TravelPlace, int>().GetList("where bookId=@id", new { id });
            foreach(var item in tb.travelPlaces)
            {
                item.imgList = new ImageDao().GetImageList(item.Id, 4);
            }
            return new RestfulData<TravelBook> {
            data=tb};
        }

        /// <summary>
        /// 新增路书
        /// </summary>
        /// <param name="travelBook">路书</param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public RestfulData PostTravelBook([FromBody]TravelBook travelBook)
        {
            var cUser = Helper.GetCurrentUser(HttpContext);
            travelBook.PublishTime = Datetime.GetNowTimestamp();
            travelBook.UserId = cUser.Id;
            int travelBookId = new DaoBase<TravelBook, int>().Insert(travelBook)??0;
            foreach(var item in travelBook.travelPlaces)
            {
                item.BookId = travelBookId;
                int placesId= new DaoBase<TravelPlace, int>().Insert(item) ?? 0;
                new ImageDao().InsertImageList(item.imgList, placesId, 4);
            }
            return new RestfulData { };
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
