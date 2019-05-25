using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class TravelPlace
    {
        /// <summary>
        /// 打卡点ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 路书ID
        /// </summary>
        [Required]
        public int BookId { get; set; }
        /// <summary>
        /// 打卡点名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 纬度
        /// </summary>
        [Required]
        public double Lat { get; set; }
        /// <summary>
        /// 经度
        /// </summary>
        [Required]
        public double Lon { get; set; }
        /// <summary>
        /// 内容
        /// </summary>
        [Required]
        public string Contents { get; set; }
        /// <summary>
        /// 图片url列表
        /// </summary>
        [Required]
        public IEnumerable<string> imgList { get; set; }
    }
}
