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
        /// 类型(1.咨询，2.户外技巧，3.户外常识，4.户外装备)
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
        /// <summary>
        /// 图片url列表
        /// </summary>
        public IEnumerable<string> ImgList { get; set; }

    }
}
