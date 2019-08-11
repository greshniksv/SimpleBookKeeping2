using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Requests.Plans
{
    public class GetPlansHandler : IRequestHandler<GetPlans, IList<PlanDto>>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly IHttpContextAccessor httpContext;

        public GetPlansHandler(DatabaseContext context, IMapper mapper, IHttpContextAccessor httpContext)
        {
            this.context = context;
            this.mapper = mapper;
            this.httpContext = httpContext;
        }

        public Task<IList<PlanDto>> Handle(GetPlans request, CancellationToken cancellationToken)
        {
            var userId = int.Parse(httpContext.HttpContext.User.Identity.Name);
            var plans = context.Plans.Include(x=>x.PlanMembers).Where(x => x.User.Id == userId);

            if (!request.ShowDeleted.HasValue)
            {
                // Filter deleted items
                plans = plans.Where(x => x.Deleted);
            }

            if (request.IsActive.HasValue)
            {
                var now = DateTime.Now;
                plans = plans.Where(x => x.Start <= now && x.End >= now);
            }

            var plansByMember = context.PlanMembers.
                Include(x => x.Plan).
                Where(x => x.User.Id == userId).Select(x=>x.Plan).Include(x=>x.PlanMembers).Select(x=>x);

            if (!request.ShowDeleted.HasValue)
            {
                // Filter deleted items
                plansByMember = plansByMember.Where(x => x.Deleted);
            }

            if (request.IsActive.HasValue)
            {
                var now = DateTime.Now;
                plansByMember = plansByMember.Where(x => x.Start <= now && x.End >= now);
            }

            var allPlans = plans.ToList().Concat(plansByMember.ToList()).ToList();
            var items = mapper.Map<IList<Plan>, IList<PlanDto>>(allPlans);
            return Task.Factory.StartNew(() => items, cancellationToken);
        }
    }
}
