using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models.Newspaper
{
    public class Newspaper
    {
        public int id { get; set; }
        public string title { get; set; }
        public string author { get; set; }
        public int date { get; set; }
        public string contents { get; set; }
        public int type { get; set; }
    }
}
