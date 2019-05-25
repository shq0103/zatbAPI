using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class TravelBook
    {
        /// <summary>
        /// 路书ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 用户ID(后端赋值)
        /// </summary>
        [Required]
        public int UserId { get; set; }

        /// <summary>
        /// 标题
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// 摘要
        /// </summary>
        [Required]
        public string Intro { get; set; }
        /// <summary>
        /// 平均海拔
        /// </summary>
        public int? Altitude { get; set; }
        /// <summary>
        /// 平均速度
        /// </summary>
        public int? Speed { get; set; }
        /// <summary>
        /// 总里程
        /// </summary>
        public int? Distance { get; set; }
        /// <summary>
        /// 总时间
        /// </summary>
        public int? TakeTime { get; set; }
        /// <summary>
        /// 发布时间(后端赋值)
        /// </summary>
        [Required]
        public long PublishTime { get; set; }
        /// <summary>
        /// 线路长短
        /// </summary>
        [Required]
        public string Length { get; set; }
        /// <summary>
        /// 浏览量(后端赋值)
        /// </summary>
        [Required]
        public int ViewCount { get; set; }

        /// <summary>
        /// 路书打卡点列表
        /// </summary>
        public IEnumerable<TravelPlace> travelPlaces { get; set; }

        /// <summary>
        /// 昵称(后端赋值)
        /// </summary>
        public object Nickname { get; set; }
    }
}
