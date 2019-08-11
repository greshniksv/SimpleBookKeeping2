using System;
using System.Collections.Generic;

namespace SimpleBookKeeping.Database.Models
{
    public class Plan
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
        public int Balance { get; set; }
        public bool Deleted { get; set; }

        public User User { get; set; }
        public ICollection<Cost> Costs { get; set; }
        public ICollection<PlanMember> PlanMembers { get; set; }
    }
}
