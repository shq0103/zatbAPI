using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class ActivityJoin
    {
        /// <summary>
        /// 活动报名ID
        /// </summary>
        [Required]
        public int Id { get; set; }
        /// <summary>
        /// activityID
        /// </summary>
        [Required]
        public int ActivityId { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Required]
        public int UserId { get; set; }
        /// <summary>
        /// 审核状态
        /// </summary>
        [Required]
        public int Status { get; set; }
        /// <summary>
        /// 用户姓名
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// 身份证
        /// </summary>
        [Required]
        public string Idcard { get; set; }
        /// <summary>
        /// 手机号
        /// </summary>
        [Required]
        public string Number { get; set; }
        /// <summary>
        /// 紧急联系方式
        /// </summary>

        public string UrgentNum { get; set; }
        /// <summary>
        /// 性别
        /// </summary>
        [Required]
        public int Sex { get; set; }
        /// <summary>
        /// 出生年月日
        /// </summary>
        [Required]
        public long Birth { get; set; }
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }
    }
}
