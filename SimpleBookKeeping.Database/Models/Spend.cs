using Database.Models;

namespace SimpleBookKeeping.Database.Models
{
    public class Spend
    {
        public int Id { get; set; }
        public int OrderNumber { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }

        public User User { get; set; }
        public CostDetail CostDetail { get; set; }
    }
}
