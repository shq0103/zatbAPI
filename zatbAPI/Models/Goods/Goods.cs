using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models.Goods
{
    public class Goods
    {
        public int id { get; set;}
        public string name { get; set; }
        public int price { get; set; }
        public string introduction { get; set; }
        public int time { get; set; }
        public int sPrice { get; set; }
        public int userId { get; set; }
        public int extent { get; set; }
    }
}
