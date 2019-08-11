using System.Collections.Generic;
using Database.Models;

namespace SimpleBookKeeping.Database.Models
{
    public class Cost
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public Plan Plan { get; set; }
        public ICollection<CostDetail> CostDetails { get; set; }
    }
}
