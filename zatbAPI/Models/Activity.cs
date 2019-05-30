using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Activity
    {
        /// <summary>
        /// 活动id
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 发布活动的用户id
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// 活动名称
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        [Required]
        public long startDate { get; set; }
        /// <summary>
        /// 结束时间
        /// </summary>
        [Required]
        public long endDate { get; set; }
        /// <summary>
        /// 活动报名截止时间
        /// </summary>
        [Required]
        public long Deadline { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 出发地
        /// </summary>
        [Required]
        public string StartPlace { get; set; }
        /// <summary>
        /// 线路长短(1.短信,2.中线,3.长线,4.其它)
        /// </summary>
        [Required]
        public int Theme { get; set; }
        /// <summary>
        /// 活动名额
        /// </summary>
        [Required]
        public int Quota { get; set; }
        /// <summary>
        /// 费用
        /// </summary>
        [Required]
        public int Price { get; set; }
        /// <summary>
        /// 目的地
        /// </summary>
        [Required]
        public string Destination { get; set; }
        /// <summary>
        /// 浏览量
        /// </summary>
        [Required]
        public int ViewCount { get; set; }
        /// <summary>
        /// 活动封面图
        /// </summary>
        [Required]
        public string Image { get; set; }
        /// <summary>
        /// 活动说明
        /// </summary>
        [Required]
        public string Explain { get; set; }
        /// <summary>
        /// 行程介绍
        /// </summary>
        [Required]
        public string Routing { get; set; }
        /// <summary>
        /// 费用说明
        /// </summary>
        [Required]
        public string CostExplain { get; set; }
        /// <summary>
        /// 路线说明
        /// </summary>
        [Required]
        public string Line { get; set; }
        /// <summary>
        /// 装备说明
        /// </summary>
        [Required]
        public string Equip { get; set; }
        /// <summary>
        /// 更多介绍
        /// </summary>
        public string MoreInfo { get; set; }
    }
}
