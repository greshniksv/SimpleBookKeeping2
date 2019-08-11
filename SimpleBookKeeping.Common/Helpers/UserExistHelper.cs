using AutoMapper;
using SimpleBookKeeping.Database;

namespace SimpleBookKeeping.Common.Helpers
{
    public class UserExistHelper: IUserExistHelper
    {
        private readonly DatabaseContext context;
        private readonly IMapper mapper;

        public UserExistHelper(DatabaseContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public bool IsUserExist(int userId)
        {
            return context.Users.Find(userId) != null;
        }
    }
}
