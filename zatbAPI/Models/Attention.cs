using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace zatbAPI.Models
{
    public partial class Attention
    {
        /// <summary>
        /// 用户关注ID
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// 被关注人ID
        /// </summary>
        [Required]
        public int AttId { get; set; }
        /// <summary>
        /// 关注人ID
        /// </summary>
        [Required]
        public int FansId { get; set; }
    }
}
