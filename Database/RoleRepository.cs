using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class RoleRepository : RepositoryBase<Role, Entities.Role>
    {
        protected override Table<Entities.Role> GetTable()
        {
            return context.Roles;
        }

        protected override Expression<Func<Entities.Role, Role>> GetConverter()
        {
            return c => new Role
            {
                Id = c.Id,
                ShortName = c.ShortName,
                Descriprion = c.Desctiption
            };
        }

        protected override void UpdateEntry(Entities.Role dbRole, Role role)
        {
            dbRole.ShortName = role.ShortName;
            dbRole.Desctiption = role.Descriprion;
        }
    }
}
