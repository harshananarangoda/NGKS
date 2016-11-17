using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Services.Abstract
{
    /// <summary>
    /// Interface: IMembershipService
    /// </summary>
    public interface IMembershipService
    {
        /// <summary>
        /// Validate User
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="password">password</param>
        /// <returns>MembershipCntext</returns>
        MembershipCntext ValidateUser(string username, string password);

        /// <summary>
        /// Create a user
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <param name="roles">roles</param>
        /// <returns>User</returns>
        User CreateUSer(string username, string email, string password, int[] roles);

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userID">user ID</param>
        /// <returns>User</returns>
        User GetUser(int userID);

        /// <summary>
        /// Get List of Roles
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>List<Roles></returns>
        List<Role> GetUserRoles(string username);
    }
}
