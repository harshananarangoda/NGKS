using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Services.Abstract
{
    /// <summary>
    /// Interface: IEncryptionService
    /// </summary>
    public interface IEncryptionService
    {
        /// <summary>
        /// Create Salt
        /// </summary>
        /// <returns>string (Salt)</returns>
        string CreateSalt();

        /// <summary>
        /// Get Encrypted Password
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="salt">salt</param>
        /// <returns>string(Encrypted Password)</returns>
        string EncryptedPassword(string password, string salt);
    }
}
