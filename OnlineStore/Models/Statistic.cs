using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineStore.Models
{
    public class Statistic
    {
        public int? sum { get; set; }
        public int? quantity { get; set; }// tong don hang
        public DateTime firstdate { get; set; }
        public DateTime lastdate { get; set; }
    }
}