﻿using System;
using System.Collections.Generic;

namespace zatbAPI.Models
{
    public partial class Image
    {
        public int Id { get; set; }
        public int? ToId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Type { get; set; }
    }
}
