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
        /// 类型(1.户外文档，2.装备问答，3.线路问答，4.旅途观光)
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required]
        public int ViewCount { get; set; }
        /// <summary>
        /// 最新回复时间
        /// </summary>
        [Required]
        public long? replyDate { get; set; }
    }
}
