using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class News
    {
        /// <summary>
        /// 新闻ID
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [Required]
        public string Author { get; set; }
        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 发表时间
        /// </summary>
        [Required]
        public long Date { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// 类型
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required]
        public int ViewCount { get; set; }
        /// <summary>
        /// 来源
        /// </summary>
        public string Source { get; set; }
    }
}
