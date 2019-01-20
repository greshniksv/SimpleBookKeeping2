using Common.DTOs;
using MediatR;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class GetUser : IRequest<UserDto>
    {
        public GetUser(string userId)
        {
            int.TryParse(userId, out var user);
            UserId = user;
        }

        public GetUser(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
