using System.Collections.Generic;

namespace Database.Models
{
    public class User
    {
        public int UserId { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public ICollection<Plan> Plans { get; set; }
        public ICollection<Spend> Spend { get; set; }
        public ICollection<PlanMember> PlanMembers { get; set; }
    }
}
