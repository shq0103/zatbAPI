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
        /// <summary>
        /// 获取活动列表
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="status">状态（可选，0.未审核，1.审核通过，2.审核不通过）</param>
        /// <param name="keyword">可选，搜索活动名称</param>
        /// <param name="user">可选，搜索发布用户</param>
        /// <param name="theme">可选，活动强度</param>
        /// <param name="startDate">可选，开始时间</param>
        /// <param name="endDate">可选，结束时间</param>
        /// <param name="orderBy">可选，排序</param>
        /// <returns></returns>
        [HttpGet]
        public RestfulArray<ActivityView> GetActivityList(int page,int pageSize,int? status,string keyword,string user,int theme, long startDate,long endDate,string orderBy)
        {
            string con = "where 1=1";
            if (!string.IsNullOrEmpty(keyword))
            {
                con += string.Format(" and name like N'%{0}%'", keyword);
            }
            if (status!=null)
            {
                con += string.Format(" and status={0}'", status);
            }
            if (!string.IsNullOrEmpty(user))
            {
                con += string.Format(" and (username='{0}' or nickname='{0}')", user);
            }
            if (theme != 0)
            {
                con += string.Format(" and theme={0}", theme);
            }
            if (startDate != 0 && endDate != 0)
            {
                con += string.Format(" and startDate>={0} and endDate<={1}", startDate, endDate);
            }else if (startDate != 0)
            {
                con += string.Format(" and startDate={0}", startDate);
            }

            string mOrderBy = "";
            if (!string.IsNullOrEmpty(orderBy))
            {
                mOrderBy = orderBy + " desc";
            }

            var data= new DaoBase<ActivityView, int>().GetListPaged(page, pageSize, con, mOrderBy);
            var total = new DaoBase<ActivityView, int>().RecordCount(con);
            foreach (var item in data)
            {
                var joinList = new DaoBase<ActivityJoinView, int>().GetList("where activityID=@activityID", new { activityID = item.Id });
                foreach(var el in joinList)
                {
                    item.joinList.Append(new UserView
                    {
                        Nickname = el.Nickname,
                        Avatar=el.Avatar
                    });
                }

            }

            return new RestfulArray<ActivityView>
            {
                data = data,
                total = total
            };
        }

        /// <summary>
        /// 获取某个活动
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public RestfulData<ActivityView> GetActivity(int id)
        {
            var act = new ActivityDao().Get(id);
            act.ViewCount += 1;
            new ActivityDao().Update(act);
            var actView = new DaoBase<ActivityView, int>().Get(id);
            var joinList = new DaoBase<ActivityJoinView, int>().GetList("where activityID=@activityID", new { activityID = id });
            foreach (var el in joinList)
            {
                actView.joinList.Append(new UserView
                {
                    Nickname = el.Nickname,
                    Avatar = el.Avatar
                });
            }
            return new RestfulData<ActivityView>
            {
                data = actView
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
            var cUser= Helper.GetCurrentUser(HttpContext);
            activity.UserId = cUser.Id;
            activity.PublishTime = Datetime.GetNowTimestamp();
            new ActivityDao().Insert(activity);
            return new RestfulData
            {
                message="新增成功"
            };
        }

        /// <summary>
        /// 更新某个活动
        /// </summary>
        /// <param name="activity">活动实体</param>
        [HttpPut]
        public RestfulData PutActivity( [FromBody]Activity activity)
        {
            new ActivityDao().Update(activity);
            return new RestfulData
            {
                message = "更新成功"
            };
        }
        /// <summary>
        /// 审核活动
        /// </summary>
        /// <param name="id">活动id</param>
        /// <param name="status">审核状态（1.通过，2.不通过）</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        public RestfulData StstutsActivity(int id,int status)
        {
            var data=new DaoBase<Activity, int>().Get(id);
            data.Status = status;
            new DaoBase<Activity, int>().Update(data);
            return new RestfulData
            {

                message = "审核成功"
            };
        }

        /// <summary>
        /// 删除某个活动
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        public RestfulData Delete(int id)
        {
            new ActivityDao().Delete(id);
            return new RestfulData
            {
                message = "删除成功！"
            };
        }
    }
}
