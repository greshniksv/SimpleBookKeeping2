using MediatR;

namespace SimpleBookKeeping.Common.Requests.Users
{
    public class IsUserExist : IRequest<bool>
    {
        public IsUserExist(int userId)
        {
            UserId = userId;
        }

        public int UserId { get; set; }
    }
}
