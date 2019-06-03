using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models
{
    public class PostView:Post
    {
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string Nickname { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Place { get; set; }
    }
}
