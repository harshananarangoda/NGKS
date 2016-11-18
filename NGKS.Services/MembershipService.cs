using NGKS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGKS.Entities;
using NGKS.Data.Repositories;
using NGKS.Data.Infrastructure;

namespace NGKS.Services
{
    /// <summary>
    /// Class: Membership Service
    /// </summary>
    public class MembershipService : IMembershipService
    {
        #region Private Variables

        private readonly IEntityRepository<User> _userRepository;
        private readonly IEntityRepository<Role> _roleRepository;
        private readonly IEntityRepository<UserRole> _userroleRepository;
        private readonly IEncryptionService _encryptionService;
        private readonly IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors

        public MembershipService(IEntityRepository<User> userRepository, IEntityRepository<Role> roleRepository,
            IEntityRepository<UserRole> userRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userroleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

        #endregion

        #region Private Helper Methods

        /// <summary>
        /// Add user role to the user helper method
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="roleID">role id</param>
        private void AddUserToRole(User user, int roleID)
        {
            var role = _roleRepository.GetSingle(roleID);
            if (role == null)
                throw new ApplicationException("Role doesn't exists");

            var userRole = new UserRole()
            {
                RoleID = role.ID,
                UserID = user.ID
            };
            _userroleRepository.Add(userRole);
        }
        
        /// <summary>
        /// Check password valid or not
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="password">password</param>
        /// <returns>bool (Password valid or not)</returns>
        private bool IsPasswordValid(User user, string password)
        {
            return string.Equals(_encryptionService.EncryptedPassword(password,user.Salt),user.Password);
        }

        /// <summary>
        /// Check user is valid
        /// </summary>
        /// <param name="user">user</param>
        /// <param name="password">password</param>
        /// <returns>bool (valid user or not)</returns>
        private bool IsUserValid(User user,string password)
        {
            if (IsPasswordValid(user, password))
            {
                return !user.IsLocked;
            }
            return false;
        }

        #endregion
        
        public User CreateUSer(string username, string email, string password, int[] roles)
        {
            throw new NotImplementedException();
        }

        public User GetUser(int userID)
        {
            throw new NotImplementedException();
        }

        public List<Role> GetUserRoles(string username)
        {
            throw new NotImplementedException();
        }

        public MembershipCntext ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
