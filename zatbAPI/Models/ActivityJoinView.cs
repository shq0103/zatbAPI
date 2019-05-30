using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models
{
    public class ActivityJoinView:ActivityJoin
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
        /// <summary>
        /// 用户昵称
        /// </summary>
        public string Nickname { get; set; }
        /// <summary>
        /// 用户头像
        /// </summary>
        public string Avatar { get; set; }
    }
}
