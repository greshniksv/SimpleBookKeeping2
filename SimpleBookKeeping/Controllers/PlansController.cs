using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Database.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using SimpleBookKeeping.Common.Commands;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Requests.Plans;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;
using SimpleBookKeeping.Settings;

namespace SimpleBookKeeping.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PlansController : ControllerBase
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;
        private readonly IMediator mediator;
        private AppSettings appSettings;

        public PlansController(DatabaseContext context, IMapper mapper, IMediator mediator, IOptions<AppSettings> appSettings)
        {
            this.context = context;
            this.mapper = mapper;
            this.mediator = mediator;
            this.appSettings = appSettings.Value;
        }

        // GET: api/Plans
        [HttpGet]
        public async Task<IActionResult> GetPlans()
        {
            return Ok(await mediator.Send(new GetPlans()));
        }

        // GET: api/Plans/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPlan([FromRoute] int id)
        {
            var plan = await mediator.Send(new GetPlan(id));

            if (plan == null)
            {
                return NotFound();
            }

            return Ok(plan);
        }

        // PUT: api/Plans/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPlan([FromRoute] int id, [FromBody] PlanDto plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != plan.Id)
            {
                return BadRequest();
            }

            try
            {
                await mediator.Send(new AddPlan(plan));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (await mediator.Send(new GetPlan(id)) == null)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Plans
        [HttpPost]
        public async Task<IActionResult> PostPlan([FromBody] PlanDto plan)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!await mediator.Send(new AddPlan(plan)))
            {
                return BadRequest();
            }

            return Ok();
        }

        // DELETE: api/Plans/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlan([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var plan = await context.Plans.FindAsync(id);
            if (plan == null)
            {
                return NotFound();
            }

            plan.Deleted = true;
            context.Entry(plan).State = EntityState.Modified;
            await context.SaveChangesAsync();

            return Ok(plan);
        }
    }
}