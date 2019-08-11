using Database.Models;

namespace SimpleBookKeeping.Database.Models
{
    public class PlanMember
    {
        public int Id { get; set; }

        public User User { get; set; }
        public Plan Plan { get; set; }
    }
}
