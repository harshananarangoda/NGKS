using NGKS.Data.Repositories;
using NGKS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Data.Extensions
{
    /// <summary>
    /// Class: User Extentions
    /// </summary>
    public static class UserExtentions
    {
        /// <summary>
        /// Extention method to get user by username
        /// </summary>
        /// <param name="userRepository">User repository</param>
        /// <param name="username">username</param>
        /// <returns>User</returns>
        public static User GetSingleByUsername(this IEntityRepository<User> userRepository, string username)
        {
            return userRepository.GetAll().FirstOrDefault(x => x.Username == username);
        }
    }
}
