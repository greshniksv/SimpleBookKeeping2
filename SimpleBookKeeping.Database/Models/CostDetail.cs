using System;
using System.Collections.Generic;

namespace Database.Models
{
    public class CostDetail
    {
        public int CostDetailId { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public bool Deleted { get; set; }

        public int CostId { get; set; }
        public Cost Cost { get; set; }
        public ICollection<Spend> Spends { get; set; }
    }
}
