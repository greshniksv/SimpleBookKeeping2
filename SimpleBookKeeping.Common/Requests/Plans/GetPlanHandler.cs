using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Extensions;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Requests.Plans
{
    public class GetPlanHandler : IRequestHandler<GetPlan, PlanDto>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContext;

        public GetPlanHandler(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContext = httpContext;
        }

        public Task<PlanDto> Handle(GetPlan request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(httpContext.HttpContext.User.Identity.Name);
            return context.Plans.Include(x=>x.PlanMembers).FirstOrDefaultAsync(
                x=> 
                    x.Id == request.Id && 
                    x.Deleted == false && 
                    (x.User.Id == userId || x.PlanMembers.Any(m=>m.User.Id == userId)),
                cancellationToken: cancellationToken).Convert<Plan, PlanDto>(mapper);
        }
    }
}
