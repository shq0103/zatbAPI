using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace zatbAPI.Models.Post
{
    public class Post
    {
        public int id { get; set; }
        public string title { get; set; }
        public string contents { get; set; }
        public int author { get; set; }
        public int date { get; set; }
        public string type { get; set; }
    }
}
