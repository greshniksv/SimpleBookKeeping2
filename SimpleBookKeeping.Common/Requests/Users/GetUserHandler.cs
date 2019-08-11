using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using MediatR;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Extensions;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class GetUserHandler : IRequestHandler<GetUser, UserDto>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public GetUserHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<UserDto> Handle(GetUser request, CancellationToken cancellationToken)
        {
            return context.Users.FindAsync(request.UserId).Convert<User, UserDto>(mapper);
        }
    }
}
