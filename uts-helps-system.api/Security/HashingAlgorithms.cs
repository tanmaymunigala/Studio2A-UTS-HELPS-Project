using System;
using System.Security.Cryptography;
using System.Text;

namespace uts_helps_system.api.Security
{
    public class HashingAlgorithms
    {
        public static bool VerifyPassword(string dbHash, string givenPassword) {
            using(MD5 md5hash = MD5.Create()) {
                var hashedString = GetMd5Hash(md5hash, givenPassword);
                var hashVerified = VerifyMd5Hash(md5hash, givenPassword, dbHash);
                return hashVerified;
            }
        }

        public static string ComputeMd5Hash(string input) {
           using(MD5 md5hash = MD5.Create()){
               return GetMd5Hash(md5hash, input);
           }
        }
        private static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        private static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}