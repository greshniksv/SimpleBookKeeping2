using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Database.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SimpleBookKeeping.Common.DTOs;
using SimpleBookKeeping.Common.Extensions;
using SimpleBookKeeping.Database;
using SimpleBookKeeping.Database.Models;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class GetAuthenticatedUserHandler : IRequestHandler<GetAuthenticatedUser, UserDto>
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public GetAuthenticatedUserHandler(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public Task<UserDto> Handle(GetAuthenticatedUser request, CancellationToken cancellationToken)
        {
            return context.Users.
                FirstOrDefaultAsync(x => 
                    x.Login == request.Login && 
                    x.Password == request.Password, cancellationToken: cancellationToken)
                .Convert<User, UserDto>(mapper);
        }
    }
}
