using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Entities
{
    /// <summary>
    /// Class: User Entity
    /// </summary>
    public class User : IEntityBase
    {
        /// <summary>
        /// Int: ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// String: Username
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// String: Email
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// String: Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// string: Sala
        /// </summary>
        public string Salt { get; set; }

        /// <summary>
        /// Bool: Is Locked
        /// </summary>
        public bool IsLocked { get; set; }

        /// <summary>
        /// DateTime: Date Created
        /// </summary>
        public DateTime DateCreated { get; set; }

        /// <summary>
        /// Naviagtion Property
        /// ICollection<UserRole>: UserRoles
        /// </summary>
        public virtual ICollection<UserRole> UserRoles { get; set; }
    }
}
