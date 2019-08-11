using System.Collections.Generic;
using Database.Models;

namespace SimpleBookKeeping.Database.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Plan> Plans { get; set; }
        public ICollection<Spend> Spend { get; set; }
        public ICollection<PlanMember> PlanMembers { get; set; }
    }
}
