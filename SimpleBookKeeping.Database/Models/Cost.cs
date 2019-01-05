using System.Collections.Generic;

namespace Database.Models
{
    public class Cost
    {
        public int CostId { get; set; }
        public string Name { get; set; }
        public bool Deleted { get; set; }

        public int PlanId { get; set; }
        public Plan Plan { get; set; }
        public ICollection<CostDetail> CostDetails { get; set; }
    }
}
