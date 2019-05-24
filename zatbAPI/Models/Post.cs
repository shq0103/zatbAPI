using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Post
    {
        /// <summary>
        /// 帖子ID
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// 用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// 发表日期
        /// </summary>
        [Required]
        public long Date { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public string Type { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required]
        public int ViewCount { get; set; }
    }
}
