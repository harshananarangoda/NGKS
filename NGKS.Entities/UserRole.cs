using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    public class UserRole : IEntityBase
    {
        public int ID { get; set; }
        public int RoleID { get; set; }
        public int UserID { get; set; }
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
