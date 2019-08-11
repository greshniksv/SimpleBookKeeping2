using SimpleBookKeeping.Common.CommandInterfaces;
using SimpleBookKeeping.Common.DTOs;

namespace SimpleBookKeeping.Common.Commands
{
    public class AddPlan : ICommand
    {
        public AddPlan(PlanDto plan)
        {
            Plan = plan;
        }

        public PlanDto Plan { get; set; }
    }
}
