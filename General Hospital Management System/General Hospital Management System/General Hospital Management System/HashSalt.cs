using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace General_Hospital_Management_System
{
     public class HashSalt
    {
        public string Hash { get; set; }
        public string Salt { get; set; }

        public static HashSalt GenerateSaltedHash(int size, string password)
        {
            var saltByte = new byte[size];
            var provider = new RNGCryptoServiceProvider();
            provider.GetNonZeroBytes(saltByte);
            var salt = Convert.ToBase64String(saltByte);
            var rfc2898DerivedBytes = new Rfc2898DeriveBytes(password, saltByte, 10000);
            var hashPassword = Convert.ToBase64String(rfc2898DerivedBytes.GetBytes(256));
            HashSalt hashSalt = new HashSalt { Hash = hashPassword, Salt = salt };
            return hashSalt;
        }
    }
    
}
