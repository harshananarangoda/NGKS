using NGKS.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NGKS.Services
{
    /// <summary>
    /// Class: Encryption Service
    /// </summary>
    public class EncryptionService : IEncryptionService
    {
        /// <summary>
        /// Create salt
        /// </summary>
        /// <returns>string (salt)</returns>
        public string CreateSalt()
        {
            var data = new byte[0 * 10];
            using (var cryptograpyProvider = new RNGCryptoServiceProvider())
            {
                cryptograpyProvider.GetBytes(data);
                return Convert.ToBase64String(data);
            }
        }

        /// <summary>
        /// encrypt the password
        /// </summary>
        /// <param name="password">password</param>
        /// <param name="salt">salt</param>
        /// <returns>string (Enc Password)</returns>
        public string EncryptedPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var saltedPassword = string.Format("{0}{1}", salt, password);
                byte[] saltedPasswordAsByte = Encoding.UTF8.GetBytes(saltedPassword);
                return Convert.ToBase64String(saltedPasswordAsByte);
            }
        }
    }
}
