using System;
using System.Data.Linq;
using System.Linq.Expressions;

namespace Database
{
    public class UserRepository : RepositoryBase<User, Entities.User>
    {
        protected override Table<Entities.User> GetTable()
        {
            return context.Users;
        }

        protected override Expression<Func<Entities.User, User>> GetConverter()
        {
            return c => new User
            {
                Id = c.Id,
                Name = c.Name,
                RoleId = c.RoleId
            };
        }

        protected override void UpdateEntry(Entities.User dbUser, User user)
        {
            dbUser.Name = user.Name;
            dbUser.RoleId = user.RoleId;
        }
    }
}
