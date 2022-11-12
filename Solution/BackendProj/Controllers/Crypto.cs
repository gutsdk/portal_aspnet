using System.Security.Cryptography;
using System.Text;

namespace BackendProj.Controllers
{
    public class Crypto
    {
        public static string  CreateSalt(int size)
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] buff = new byte[size];
            rng.GetBytes(buff);
            return Convert.ToBase64String(buff);
        }

        public static string GenerateHash(string input, string salt)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(input + salt);
            SHA256 sHA256String = SHA256.Create();
            byte[] hash = sHA256String.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        public static bool AreEqual(string plainTextInput, string hashedInput, string salt)
        {
            string newHashedPin = GenerateHash(plainTextInput, salt);
            return newHashedPin.Equals(hashedInput);
        }
    }
}
