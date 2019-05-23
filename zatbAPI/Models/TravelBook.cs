using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class TravelBook
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Intro { get; set; }
        public int? Altitude { get; set; }
        public int? Speed { get; set; }
        public int? Distance { get; set; }
        public int? TakeTime { get; set; }
        public long PublishTime { get; set; }
        public int UserId { get; set; }
        public string Length { get; set; }
        public int ViewCount { get; set; }
    }
}
