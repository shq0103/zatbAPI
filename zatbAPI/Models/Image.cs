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
        /// 图片名字
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 图片路径
        /// </summary>
        [Required]
        public string Url { get; set; }
        /// <summary>
        /// 图片类型
        /// </summary>

        public string Type { get; set; }
    }
}
