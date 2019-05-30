using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models
{
    public class UserView
    {
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Nickname { get; set; }
    }
    public class ActivityView:Activity
    {
        /// <summary>
        /// 报名列表
        /// </summary>
        public IEnumerable<UserView> joinList { get; set; }
        /// <summary>
        /// 活动发起人用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 活动发起人昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 活动发起人角色
        /// </summary>
        public string Role { get; set; }
    }
}
