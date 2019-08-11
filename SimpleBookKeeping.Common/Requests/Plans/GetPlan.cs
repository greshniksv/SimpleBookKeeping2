using MediatR;
using SimpleBookKeeping.Common.DTOs;

namespace SimpleBookKeeping.Common.Requests.Plans
{
    public class GetPlan : IRequest<PlanDto>
    {
        public GetPlan(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
