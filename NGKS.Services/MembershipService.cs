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

        public MembershipService(IEntityRepository<User> userRepository, IEntityRepository<Role> roleRepository,
            IEntityRepository<UserRole> userRoleRepository, IEncryptionService encryptionService, IUnitOfWork unitOfWork)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userroleRepository = userRoleRepository;
            _encryptionService = encryptionService;
            _unitOfWork = unitOfWork;
        }

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
