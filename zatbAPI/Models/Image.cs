using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Image
    {
        /// <summary>
        /// 图片ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 图片展现
        /// </summary>
        public int? ToId { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// 图片类型(1.新闻,2.活动，3.闲趣，4.打卡点)
        /// </summary>

        public int Type { get; set; }
    }
}
