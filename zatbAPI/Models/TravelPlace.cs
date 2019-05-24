using System;
using System.Collections.Generic;

namespace zatbAPI.Models
{
    public partial class TravelPlace
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public string Name { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public string Content { get; set; }
    }
}
