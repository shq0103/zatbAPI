using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class SystemNotice
    {
        public int Id { get; set; }
        public int Type { get; set; }
        public int Status { get; set; }
        public string Content { get; set; }
        public int ToId { get; set; }
        public int TouserId { get; set; }
        public long Time { get; set; }
    }
}
