using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models.Comment
{
    public class Comment
    {
        public int id { get; set; }
        public string contents { get; set; }
        public string name { get; set; }
        public string type { get; set; }
    }
}
