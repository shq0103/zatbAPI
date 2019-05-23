using System;
using System.Collections.Generic;

namespace GenModel.Models
{
    public partial class ActivityJoin
    {
        public int Id { get; set; }
        public int ActivityId { get; set; }
        public int Status { get; set; }
        public string Name { get; set; }
        public string Idcard { get; set; }
        public string Number { get; set; }
        public string UrgentNum { get; set; }
        public int Sex { get; set; }
        public long Birth { get; set; }
        public string Remark { get; set; }
    }
}
