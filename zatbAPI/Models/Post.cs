using System;
using System.Collections.Generic;

namespace zatbAPI.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Contents { get; set; }
        public long Date { get; set; }
        public string Type { get; set; }
        public int ViewCount { get; set; }
    }
}
