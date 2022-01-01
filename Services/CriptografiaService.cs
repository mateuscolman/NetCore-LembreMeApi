using System.Security.Cryptography;
using System.Text;

namespace LembreMeApi.Services
{
    public static class CriptografiaService
    {
        private const string PasswordHash = "f9ee7a80-6b26-11ec-81d7-0ee724d30681";
        private const string SaltKey = "0baecb6e-6b27-11ec-81d7-0ee724d30681";
        private const string ViKey = "f5296c04e7232032";

        /// <summary>
        /// Criptografa uma string
        /// </summary>
        /// <param name="plainText"></param>
        /// <returns></returns>
        public static string Encrypt(string plainText)
        {
            return SymetricEncrypt(plainText);
        }
        
        public static string Decrypt(string encryptedText)
        {
            return SymetricDecrypt(encryptedText);
        }

        #region Metodos privados
        
        private static string SymetricEncrypt(string plainText)
        {
            var plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            var keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.Zeros };
            var encryptor = symmetricKey.CreateEncryptor(keyBytes, Encoding.ASCII.GetBytes(ViKey));

            byte[] cipherTextBytes;

            using var memoryStream = new MemoryStream();
            using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
            {
                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                cryptoStream.FlushFinalBlock();
                cipherTextBytes = memoryStream.ToArray();
                cryptoStream.Close();
            }
            memoryStream.Close();

            return Convert.ToBase64String(cipherTextBytes);
        }

        private static string SymetricDecrypt(string encryptedText)
        {
            var cipherTextBytes = Convert.FromBase64String(encryptedText);
            var keyBytes = new Rfc2898DeriveBytes(PasswordHash, Encoding.ASCII.GetBytes(SaltKey)).GetBytes(256 / 8);
            var symmetricKey = new RijndaelManaged() { Mode = CipherMode.CBC, Padding = PaddingMode.None };

            var decryptor = symmetricKey.CreateDecryptor(keyBytes, Encoding.ASCII.GetBytes(ViKey));
            var memoryStream = new MemoryStream(cipherTextBytes);
            var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            var plainTextBytes = new byte[cipherTextBytes.Length];

            var decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
            memoryStream.Close();
            cryptoStream.Close();
            return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount).TrimEnd("\0".ToCharArray());
        }

        #endregion
    }
}
