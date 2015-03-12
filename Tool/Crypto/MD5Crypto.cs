using System.Security.Cryptography;
using System.Text;

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


}
