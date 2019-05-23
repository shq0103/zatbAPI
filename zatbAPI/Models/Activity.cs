using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class Activity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public long Date { get; set; }
        public long Deadline { get; set; }
        public string Organiger { get; set; }
        public string StartPlace { get; set; }
        public string Theme { get; set; }
        public int Quota { get; set; }
        public int Price { get; set; }
        public string Destination { get; set; }
        public int ViewCount { get; set; }
        public int Image { get; set; }
        public string Explain { get; set; }
        public string Routing { get; set; }
        public string CostExplain { get; set; }
        public string Line { get; set; }
        public string Equip { get; set; }
        public string MoreInfo { get; set; }
    }
}
