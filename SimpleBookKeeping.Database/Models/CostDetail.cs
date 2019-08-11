using System;
using System.Collections.Generic;
using SimpleBookKeeping.Database.Models;

namespace Database.Models
{
    public class CostDetail
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Value { get; set; }
        public bool Deleted { get; set; }

        public Cost Cost { get; set; }
        public ICollection<Spend> Spends { get; set; }
    }
}
