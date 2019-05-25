﻿using System;
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
        /// 类型
        /// </summary>
        [Required]
        public string Type { get; set; }
    }
}
