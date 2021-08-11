using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace General_Hospital_Management_System
{
   public static class PassAuthentication
    {
        // HASHING THE LOGIN PASSWORD//
        //==========================//
        private static string GenerateSalt()
        {
            var bytes = new byte[128 / 8];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);


            return Convert.ToBase64String(bytes);

        }
       
        public static string HashPassword(string password, string salt = null)
        {
            // Generate the Salt
            var genSalt = (salt == null) ? GenerateSalt() : salt;

            // Hash the password
            var byteResult = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), Encoding.UTF8.GetBytes(genSalt), 10000);
            var hash = Convert.ToBase64String(byteResult.GetBytes(24));
            return hash + '.' + genSalt;
          
        }
        public static bool VerifyPassword(string password, string digest)
        {
            // Split the digest into two parts. The digest is the string hashed password stored
            // in the database. So the command ' var password = reader.GetString(2);' in the Login code
            // fetches the password, digest.Split('.') command split it and use the stroedsalt key to
            // hash the new password inserted in the tbPassword, then compare to the original stored
            // digest with new one for a match. if they matched, access is given to login else access is denied.
            var parts = digest.Split('.');
            var storedHash = parts[0];
            var storedSalt = parts[1];

            var hash = HashPassword(password, storedSalt);

            return (hash == digest);
        }

    }
}
