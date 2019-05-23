using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public long Date { get; set; }
        public string Contents { get; set; }
        public int Type { get; set; }
        public int ViewCount { get; set; }
        public string Source { get; set; }
    }
}
