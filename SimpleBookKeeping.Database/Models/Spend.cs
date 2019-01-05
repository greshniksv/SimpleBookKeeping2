using System.Collections.Generic;

namespace Database.Models
{
    public class Spend
    {
        public int SpendId { get; set; }
        public int OrderNumber { get; set; }
        public int Value { get; set; }
        public string Comment { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }
        public int CostDetailId { get; set; }
        public CostDetail CostDetail { get; set; }
    }
}
