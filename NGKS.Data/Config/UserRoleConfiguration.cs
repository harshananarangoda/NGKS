using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Config
{
    public class UserRoleConfiguration: EntityBaseConfiguration<UserRole>
    {
        public UserRoleConfiguration()
        {
            Property(ur => ur.UserID).IsRequired();
            Property(ur => ur.RoleID).IsRequired();
        }
    }
}
