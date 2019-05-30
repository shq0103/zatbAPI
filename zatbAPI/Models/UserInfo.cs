using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models
{
    public class UserInfo

    {
        /// <summary>
     /// 角色数组
     /// </summary>
        public IEnumerable<string> Roles { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        public string Name { get; set; }
    }
}
