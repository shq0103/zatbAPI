using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class Goods
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Introduction { get; set; }
        public int Price { get; set; }
        public string Extent { get; set; }
        public int SPrice { get; set; }
        public long Time { get; set; }
        public int UserId { get; set; }
        public string Type { get; set; }
        public string Num { get; set; }
        public string Place { get; set; }
    }
}
