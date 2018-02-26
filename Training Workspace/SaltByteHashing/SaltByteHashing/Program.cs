using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace SaltByteHashing
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "Kenneth";  // original password
            string wrongPassword = "Kenneth1";    // wrong password

            string passwordHashMD5 = ComputeHash(password, "MD5", null);
            string passwordHashSha1 =ComputeHash(password, "SHA1", null);
            string passwordHashSha256 =ComputeHash(password, "SHA256", null);
            string passwordHashSha384 =ComputeHash(password, "SHA384", null);
            string passwordHashSha512 =ComputeHash(password, "SHA512", null);

            Console.WriteLine("COMPUTING HASH VALUES\r\n");
            Console.WriteLine("MD5   : {0}", passwordHashMD5);
            Console.WriteLine("SHA1  : {0}", passwordHashSha1);
            Console.WriteLine("SHA256: {0}", passwordHashSha256);
            Console.WriteLine("SHA384: {0}", passwordHashSha384);
            Console.WriteLine("SHA512: {0}", passwordHashSha512);
            Console.WriteLine("COMPARING PASSWORD HASHES\r\n");


            Console.WriteLine("MD5    (good): {0}",VerifyHash(password, "MD5",passwordHashMD5).ToString());
            Console.WriteLine("MD5    (bad) : {0}",VerifyHash(wrongPassword, "MD5",passwordHashMD5).ToString());
            Console.WriteLine("SHA1   (good): {0}",VerifyHash(password, "SHA1",passwordHashSha1).ToString());
            Console.Read();

        }
        static string ComputeHash(string plaintext,string hashalgo,byte[] saltbyte)
        {
            if(saltbyte==null)
            {
                Random rand = new Random();
                int saltsize = rand.Next(2, 10);
                saltbyte = new byte[saltsize];
                RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider();
                rng.GetNonZeroBytes(saltbyte); 
            }
            byte[] plaintextbytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] plaintextsaltbytes = new byte[plaintextbytes.Length + saltbyte.Length];
            for (int i = 0; i < plaintextbytes.Length; i++)
            {
                plaintextsaltbytes[i] = plaintextbytes[i];
            }
            for (int i = 0; i < saltbyte.Length; i++)
            {
                plaintextsaltbytes[i + plaintextbytes.Length] = saltbyte[i];
            }


            HashAlgorithm hash;
            if (hashalgo == null)
                hashalgo = "";

            switch (hashalgo.ToUpper())
            {
                case "SHA1":
                    hash = new SHA1Managed();
                    break;

                case "SHA256":
                    hash = new SHA256Managed();
                    break;

                case "SHA384":
                    hash = new SHA384Managed();
                    break;

                case "SHA512":
                    hash = new SHA512Managed();
                    break;

                default:
                    hash = new MD5CryptoServiceProvider();
                    break;
            }

            byte[] hashbytes = hash.ComputeHash(plaintextsaltbytes);

            byte[] hashWithSaltBytes = new byte[hashbytes.Length +
                                                saltbyte.Length];

            for (int i = 0; i < hashbytes.Length; i++)
                hashWithSaltBytes[i] = hashbytes[i];

            for (int i = 0; i < saltbyte.Length; i++)
                hashWithSaltBytes[hashbytes.Length + i] = saltbyte[i];

            string hashValue = Convert.ToBase64String(hashWithSaltBytes);

            return hashValue;
        }

   
        public static bool VerifyHash(string   plainText,string   hashAlgorithm,string   hashValue)
        {
                // Convert base64-encoded hash value into a byte array.
                byte[] hashWithSaltBytes = Convert.FromBase64String(hashValue);
        
                // We must know size of hash (without salt).
                int hashSizeInBits, hashSizeInBytes;
        
                // Make sure that hashing algorithm name is specified.
                if (hashAlgorithm == null)
                    hashAlgorithm = "";
        
                // Size of hash is based on the specified algorithm.
                switch (hashAlgorithm.ToUpper())
                {
                    case "SHA1":
                        hashSizeInBits = 160;
                        break;

                    case "SHA256":
                        hashSizeInBits = 256;
                        break;

                    case "SHA384":
                        hashSizeInBits = 384;
                        break;

                    case "SHA512":
                        hashSizeInBits = 512;
                        break;

                    default: // Must be MD5
                        hashSizeInBits = 128;
                        break;
                }

                // Convert size of hash from bits to bytes.
                hashSizeInBytes = hashSizeInBits / 8;

                // Make sure that the specified hash value is long enough.
                if (hashWithSaltBytes.Length < hashSizeInBytes)
                    return false;

                // Allocate array to hold original salt bytes retrieved from hash.
                byte[] saltBytes = new byte[hashWithSaltBytes.Length - 
                                            hashSizeInBytes];

                // Copy salt from the end of the hash to the new array.
                for (int i=0; i < saltBytes.Length; i++)
                    saltBytes[i] = hashWithSaltBytes[hashSizeInBytes + i];

                // Compute a new hash string.
                string expectedHashString = 
                            ComputeHash(plainText, hashAlgorithm, saltBytes);

                // If the computed hash matches the specified hash,
                // the plain text value must be correct.
                return (hashValue == expectedHashString);
        }

    }
}
