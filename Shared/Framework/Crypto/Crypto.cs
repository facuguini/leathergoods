using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Framework.Crypto
{
    public static class Crypto
    {
        private static readonly byte[] key = Convert.FromBase64String("AAECAwQFBgcICQoLDA0ODw==");

        /// <summary>
        ///     Encrypt a value
        /// </summary>
        /// <param name="value">Value to encrypt</param>
        /// <returns>Encrypted value</returns>
        public static string Encrypt(string value)
        {
            byte[] encrypted;
            byte[] IV;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                aesAlg.GenerateIV();
                IV = aesAlg.IV;
                aesAlg.Mode = CipherMode.CBC;
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                {
                    using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (var swEncrypt = new StreamWriter(csEncrypt))
                        {
                            swEncrypt.Write(value);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            var combinedIvCt = new byte[IV.Length + encrypted.Length];
            Array.Copy(IV, 0, combinedIvCt, 0, IV.Length);
            Array.Copy(encrypted, 0, combinedIvCt, IV.Length, encrypted.Length);

            return Convert.ToBase64String(combinedIvCt);
        }

        /// <summary>
        ///     Decrypt value
        /// </summary>
        /// <param name="value">Encrypted value</param>
        /// <returns>Decrypted value</returns>
        public static string Decrypt(string value)
        {
            byte[] toBytes = Convert.FromBase64String(value);
            string plaintext = null;
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = key;
                byte[] IV = new byte[aesAlg.BlockSize / 8];
                byte[] cipherText = new byte[toBytes.Length - IV.Length];
                Array.Copy(toBytes, IV, IV.Length);
                Array.Copy(toBytes, IV.Length, cipherText, 0, cipherText.Length);
                aesAlg.IV = IV;
                aesAlg.Mode = CipherMode.CBC;
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(cipherText))
                {
                    using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (var srDecrypt = new StreamReader(csDecrypt))
                        {
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }

            }

            return plaintext;
        }
    }
}
