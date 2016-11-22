using NGKS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NGKS.Entities;
using NGKS.Data.Repositories;
using NGKS.Data.Infrastructure;
using NGKS.Data.Extensions;

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
        
        /// <summary>
        /// Add user 
        /// </summary>
        /// <param name="username">username</param>
        /// <param name="email">email</param>
        /// <param name="password">password</param>
        /// <param name="roles">roles</param>
        /// <returns>User</returns>
        public User CreateUSer(string username, string email, string password, int[] roles)
        {
            var existsUser = _userRepository.GetSingleByUsername(username);

            if (existsUser != null)
                throw new Exception("Username already exists");

            var passwordSalt = _encryptionService.CreateSalt();

            var user = new User()
            {
                Username = username,
                Salt = passwordSalt,
                Email = email,
                IsLocked = false,
                Password = _encryptionService.EncryptedPassword(password, passwordSalt),
                DateCreated = DateTime.Now
            };

            _userRepository.Add(user);

            _unitOfWork.Commit();

            if (roles != null || roles.Length > 0)
            {
                foreach (var role in roles)
                {
                    AddUserToRole(user, role);
                }
            }

            _unitOfWork.Commit();

            return user;
        }

        /// <summary>
        /// Get User
        /// </summary>
        /// <param name="userID">UserID</param>
        /// <returns>User</returns>
        public User GetUser(int userID)
        {
            return _userRepository.GetSingle(userID);
        }

        /// <summary>
        /// Get user roles for user
        /// </summary>
        /// <param name="username">username</param>
        /// <returns>List<Role></returns>
        public List<Role> GetUserRoles(string username)
        {
            List<Role> _result = new List<Role>();

            var existingUser = _userRepository.GetSingleByUsername(username);

            if(existingUser != null)
            {
                foreach(var role in existingUser.UserRoles)
                {
                    _result.Add(role.Role);
                }
            }

            return _result.Distinct().ToList();
        }

        public MembershipContext ValidateUser(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
