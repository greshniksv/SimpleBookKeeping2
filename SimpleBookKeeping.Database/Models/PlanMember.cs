namespace Database.Models
{
    public class PlanMember
    {
        public int PlanMemberId { get; set; }

        public int? UserId { get; set; }
        public int PlanId { get; set; }
        public User User { get; set; }
        public Plan Plan { get; set; }
    }
}
