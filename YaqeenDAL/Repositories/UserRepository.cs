using Microsoft.Extensions.Logging;
using YaqeenDAL.Model;

namespace YaqeenDAL.Repositories
{
    internal class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(YaqeenDbContext context, ILogger<User> logger) : base(context, logger)
        {
        }
    }
}
