using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class SystemNoticeController : Controller
    {
        /// <summary>
        /// 用户获取系统通知
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Authorize]
        public RestfulArray<SystemNotice> GetSystemNoticeList()
        {
           
            return new RestfulArray<SystemNotice>
            {
                data = new DaoBase<SystemNotice, int>().GetList("where touserId=@TouserId", 
                new { TouserId = Helper.GetCurrentUser(HttpContext).Id })
            };
        }

        /// <summary>
        /// 用户获取系统通知未读数量
        /// </summary>
        /// <returns></returns>
        [HttpGet("count")]
        [Authorize]
        public RestfulData<int> GetSystemNoticeCount()
        {

            return new RestfulData<int>
            {
                data = new DaoBase<SystemNotice, int>().RecordCount("where touserId=@TouserId and status=0",
                new { TouserId = Helper.GetCurrentUser(HttpContext).Id })
            };
        }





        /// <summary>
        /// 标记系统通知为已读
        /// </summary>
        /// <param name="systemNotice">status设置为1</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public RestfulData PutSystemNotice([FromBody]SystemNotice systemNotice)
        {
            new DaoBase<SystemNotice, int>().Update(systemNotice);
            return new RestfulData
            {

            };
        }

        /// <summary>
        /// 删除某条系统通知
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public RestfulData DeleteSystemNotice(int id)
        {
            new DaoBase<SystemNotice, int>().Delete(id);
            return new RestfulData
            {

            };
        }
    }
}
