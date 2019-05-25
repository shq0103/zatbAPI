using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class User
    {
        /// <summary>
        /// 用户ID
        /// </summary>
        
        public int Id { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// 密码
        /// </summary>
        [Required]
        public string Password { get; set; }
        /// <summary>
        /// 昵称
        /// </summary>
        [Required]
        public string Nickname { get; set; }
        /// <summary>
        /// 角色
        /// </summary>
        [Required]
        public string Role { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 出生日期
        /// </summary>
        public long? Birthday { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        public int? Gender { get; set; }
        /// <summary>
        /// 真实姓名
        /// </summary>
        public string TrueName { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        public string IdCard { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        public string Phone { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        public string Mail { get; set; }
        /// <summary>
        /// 个人简介
        /// </summary>
        public string Intro { get; set; }
        /// <summary>
        /// 地区
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// 上次登录时间
        /// </summary>
        [Required]
        public long? LastTime { get; set; }
        /// <summary>
        /// 用户状态
        /// </summary>
        [Required]
        public int Status { get; set; }
    }
}
