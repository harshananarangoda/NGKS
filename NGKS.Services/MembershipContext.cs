using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Services
{
    /// <summary>
    /// Class: MembershipContext
    /// </summary>
    public class MembershipContext
    {
        /// <summary>
        /// Principal object (Include user identity and and also the the roles that belongs)
        /// </summary>
        public IPrincipal Principal { get; set; }
        /// <summary>
        /// User
        /// </summary>
        public User User { get; set; } 
        /// <summary>
        /// Is Valid Principal
        /// </summary>
        /// <returns>bool</returns>
        public bool IsValid()
        {
            return Principal != null;
        }
    }
}
