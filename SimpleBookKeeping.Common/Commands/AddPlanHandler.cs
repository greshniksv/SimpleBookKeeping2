using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleBookKeeping.Common.CommandService;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Commands
{
    public class AddPlanHandler : ICommandHandler<AddPlan>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContext;

        public AddPlanHandler(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContext = httpContext;
        }

        public async Task<bool> Handle(AddPlan request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(httpContext.HttpContext.User.Identity.Name);
            var plan = mapper.Map<PlanDto, Plan>(request.Plan);
            var user = await context.Users.FirstAsync(x => x.Id == userId, cancellationToken: cancellationToken);
            plan.User = user;

            await context.Plans.AddAsync(plan, cancellationToken);
            await context.SaveChangesAsync(cancellationToken);
            return true;
        }
    }
}
