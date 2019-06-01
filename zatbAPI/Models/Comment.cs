using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Comment
    {
        /// <summary>
        /// 评论ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// 回复的类型的ID
        /// </summary>
        [Required]
        public int ToId { get; set; }
        /// <summary>
        /// 回复的评论的ID
        /// </summary>
        public int? ReplyTo { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// 类型（1.打卡点，2.论坛,3.新闻）
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 时间
        /// </summary>
        public long Time { get; set; }
    }
}
