using Common.DTOs;
using MediatR;

namespace Common.Requests.Users
{
    public class GetUser : IRequest<UserDto>
    {
        public int UserId { get; set; }
    }
}
