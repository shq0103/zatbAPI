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
        /// 类型(1.系统通知)
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 状态（0.未读，1.已读）
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        [Required]
        public long Time { get; set; }
    }
}
