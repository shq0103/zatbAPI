using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models.Activity
{
    public class Activity
    {
        public int id { get; set; }
        public string name { get; set; }
        public int date { get; set; }
        public int gTime { get; set; }
        public string gPlace { get; set; }
        public string theme { get; set; }
        public int quota { get; set; }
        public int price { get; set; }
        public string destination { get; set; }
        public string explanation { get; set; }
    }
}
