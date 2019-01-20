using AutoMapper;
using Database.Models;
using MediatR;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class IsUserExistHandler: RequestHandler<IsUserExist, bool>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public IsUserExistHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        protected override bool Handle(IsUserExist request)
        {
            return context.Users.Find(request.UserId) != null;
        }
    }
}
