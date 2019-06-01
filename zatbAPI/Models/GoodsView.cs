using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models
{
    public class GoodsView:Goods
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string Username { get; set; }
    }
}
