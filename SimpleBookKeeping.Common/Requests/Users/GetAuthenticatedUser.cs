using MediatR;
using SimpleBookKeeping.Common.DTOs;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class GetAuthenticatedUser : IRequest<UserDto>
    {
        public GetAuthenticatedUser(string login, string password)
        {
            Login = login;
            Password = password;
        }

        public string Login { get; set; }

        public string Password { get; set; }
    }
}
