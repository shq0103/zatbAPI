using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public int Author { get; set; }
        public long Date { get; set; }
        public string Type { get; set; }
        public int ViewCount { get; set; }
    }
}
