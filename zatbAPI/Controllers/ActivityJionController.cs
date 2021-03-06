﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using zatbAPI.DbHelper;
using zatbAPI.Models;
using zatbAPI.Models.RestfulData;
using zatbAPI.Utils;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace zatbAPI.Controllers
{
    [Route("api/[controller]")]
    public class ActivityJionController : Controller
    {
        /// <summary>
        /// 获取某活动的报名列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="activityId">活动id</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<ActivityJoinView> Get(int page,int pageSize,int activityId)
        {
            var data = new DaoBase<ActivityJoinView, int>().GetListPaged(page, pageSize, "where activityID=@activityId", null, new { activityId });
            return new RestfulArray<ActivityJoinView>
            {
                data = data,
                total = new DaoBase<ActivityJoinView, int>().RecordCount("where activityID=@activityId", new { activityId })
            };
        }

        /// <summary>
        /// 获取用户报名活动列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        [HttpGet("user")]
        public RestfulArray<ActivityJoinView> GetUserActivityJoinView(int page, int pageSize)
        {
            var userId = Helper.GetCurrentUser(HttpContext).Id;
            var data = new DaoBase<ActivityJoinView, int>().GetListPaged(page, pageSize, "where userId=@userId", null, new { userId });
            return new RestfulArray<ActivityJoinView>
            {
                data = data,
                total = new DaoBase<ActivityJoinView, int>().RecordCount("where userId=@userId", new { userId })
            };
        }


        /// <summary>
        /// 报名活动
        /// </summary>
        /// <param name="activityJoin">活动实体</param>
        [HttpPost]
        public RestfulData PostActivityJoin([FromBody]ActivityJoin activityJoin)
        {
            var ac = new DaoBase<Activity, int>().Get(activityJoin.ActivityId);
            if (ac.Signin + 1 > ac.Quota)
            {
                
                    return new RestfulData
                    {
                        code = 400,
                        message = "名额已满！"
                    };
                
            }


            var aj = new DaoBase<ActivityJoin, int>().Get(
                string.Format("select * from activityJoin where activityID={0} and userId={1}", 
                activityJoin.ActivityId, Helper.GetCurrentUser(HttpContext).Id)
                );                   
            if (aj != null)
            {
                return new RestfulData
                {
                    code = 400,
                    message = "已报名！"
                };
            }
            
            activityJoin.UserId = Helper.GetCurrentUser(HttpContext).Id;
            ac.Signin += 1;
            new ActivityDao().Update(ac);
            new DaoBase<ActivityJoin, int>().Insert(activityJoin);
            return new RestfulData
            {
                message="报名成功！"
            };
        }

        /// <summary>
        /// 审核报名
        /// </summary>
        /// <param name="id">报名id</param>
        /// <param name="status">审核状态（1.通过，2.不通过）</param>
        [HttpPut]
        public RestfulData PutActivity(int id, int status)
        {
            var data = new DaoBase<ActivityJoin, int>().Get(id);
            data.Status = status;
            new DaoBase<ActivityJoin, int>().Update(data);
            return new RestfulData
            {
                message = "审核成功！"
            };

        }

        /// <summary>
        /// 删除用户报名
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            var aj = new DaoBase<ActivityJoin, int>().Get(id);
            var ac = new DaoBase<Activity, int>().Get(aj.ActivityId);
            ac.Signin -= 1;
            new DaoBase<Activity, int>().Update(ac);
            new DaoBase<ActivityJoin, int>().Delete(id);
            return new RestfulData
            {
                
            };
        }
    }
}
