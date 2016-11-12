using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: User Role Entity
    /// </summary>
    public class UserRole : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }
        
        /// <summary>
        /// Int: RoleID
        /// </summary>
        public int RoleID { get; set; }

        /// <summary>
        /// Int: UserID
        /// </summary>
        public int UserID { get; set; }

        /// <summary>
        /// Navigation Property
        /// Role: Role 
        /// </summary>
        public virtual Role Role { get; set; }

        /// <summary>
        /// Navigation Property
        /// User: User
        /// </summary>
        public virtual User User { get; set; }
    }
}
