using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Annotations;
using zatbAPI.DbHelper.IRepository;
using zatbAPI.Models;
using zatbAPI.Models.Forms;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;
using zatbAPI.DbHelper;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivityController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> GetActivityList()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 获取某个活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<Activity> GetActivity(int id)
        {
            var act = new ActivityDao().Get(id);
            act.ViewCount += 1;
            new ActivityDao().Update(act);
            return new RestfulData<Activity>
            {
                data = act
            };
        }

        /// <summary>
        /// 新增活动
        /// </summary>
        /// <param name="activity"></param>
        /// <returns></returns>
        [HttpPost]
        [Authorize]
        public RestfulData PostActivity([FromBody]Activity activity)
        {
            activity.UserId = Helper.GetCurrentUser(HttpContext).Id;
            new ActivityDao().Insert(activity);
            return new RestfulData
            {
                message="新增成功"
            };
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
