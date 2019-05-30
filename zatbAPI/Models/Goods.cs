using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Goods
    {
        /// <summary>
        /// 闲趣ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 发布用户ID
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// 商品名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 商品介绍
        /// </summary>
        [Required]
        public string Introduction { get; set; }
        /// <summary>
        /// 原始价格
        /// </summary>
        [Required]
        public int Price { get; set; }
        /// <summary>
        /// 新旧程度
        /// </summary>
        [Required]
        public string Extent { get; set; }
        /// <summary>
        /// 转卖价格
        /// </summary>
        [Required]
        public int SPrice { get; set; }
        /// <summary>
        /// 发布时间
        /// </summary>
        [Required]
        public long Time { get; set; }
        /// <summary>
        /// 商品类别(1.服装2.装备3.其它)
        /// </summary>
        [Required]
        public int Type { get; set; }
        /// <summary>
        /// 联系方式
        /// </summary>
        public string Num { get; set; }
        /// <summary>
        /// 所在地
        /// </summary>
        public string Place { get; set; }
        /// <summary>
        /// 商品图片
        /// </summary>
        public IEnumerable<string> imgList { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        
        public int viewCount { get; set; }
    }
}
