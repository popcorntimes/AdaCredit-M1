using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using bcrypt = BCrypt.Net.BCrypt;
using System.Security.Cryptography;

namespace AdaCredit.Console
{
    public class Password
    {
        private static readonly int SaltLength = 10;
        public static string HashGeneration(string password, string salt)
        {
            string hash = bcrypt.HashPassword(password, salt);

            return hash;
        }

        public static string SaltGeneration()
        {
            var salt = bcrypt.GenerateSalt(SaltLength);
            return salt;
        }

        public static bool PasswordCompare(string password, string hash)
        {
            return bcrypt.Verify(password, hash);
        }
    }
}
