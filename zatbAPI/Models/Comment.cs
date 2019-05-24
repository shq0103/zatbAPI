using System;
using System.Collections.Generic;

namespace zatbAPI.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ToId { get; set; }
        public int? ReplyTo { get; set; }
        public string Contents { get; set; }
        public string Type { get; set; }
    }
}
