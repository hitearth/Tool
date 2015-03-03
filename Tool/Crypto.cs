using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Hitearth.Tool.Crypto
{

    /// <summary>
    /// MD5加密
    /// </summary>
    public class MD5Crypto
    {
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plaintext">待加密的字符串</param>
        /// <returns>加密后的字符串</returns>
        public static string Encrypt(string plaintext)
        {
            MD5CryptoServiceProvider md5Hasher = new MD5CryptoServiceProvider();
            UTF8Encoding Encode = new UTF8Encoding();
            byte[] HashedBytes = md5Hasher.ComputeHash(Encode.GetBytes(plaintext));
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < HashedBytes.Length; i++)
            {
                sb.Append(HashedBytes[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }

    public class DESCrypto
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };

        private const string DefaultKey = "12345678";
        /// <summary>
        /// 加密
        /// </summary>
        /// <param name="plaintext">待加密的字符串</param>
        /// <param name="eKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string Encrypt(string plaintext, string eKey = DefaultKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(eKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(plaintext);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return plaintext;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="ciphertext">待解密的字符串</param>
        /// <param name="eKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string Decrypt(string ciphertext, string eKey = DefaultKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(eKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(ciphertext);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return ciphertext;
            }
        }

    }
}
