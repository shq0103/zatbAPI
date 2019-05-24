using System;
using System.Collections.Generic;

namespace zatbAPI.Models
{
    public partial class SystemNotice
    {
        public int Id { get; set; }
        public int TouserId { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public long Time { get; set; }
    }
}
