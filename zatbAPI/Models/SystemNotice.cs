using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class SystemNotice
    {
        /// <summary>
        /// 系统通知ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 通知的用户的ID
        /// </summary>
        [Required]
        public int TouserId { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 状态
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Content { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        public long Time { get; set; }
    }
}
