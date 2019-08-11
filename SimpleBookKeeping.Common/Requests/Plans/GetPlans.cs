using System.Collections.Generic;
using System.ComponentModel;
using MediatR;
using SimpleBookKeeping.Common.DTOs;

namespace SimpleBookKeeping.Common.Requests.Plans
{
    public class GetPlans : IRequest<IList<PlanDto>>
    {
        public GetPlans()
        {
            ShowDeleted = false;
            IsActive = null;
        }

        /// <summary>
        /// If value is TRUE, return only deleted plan; If FALSE, return only not deleted; If NULL return all;
        /// </summary>
        [DefaultValue(false)]
        public bool? ShowDeleted { get; set; }

        /// <summary>
        /// If value is TRUE, return only active plan; If FALSE, return only not active; If NULL return all;
        /// </summary>
        [DefaultValue(null)]
        public bool? IsActive { get; set; }
    }
}
