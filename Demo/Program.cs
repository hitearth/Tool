using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hitearth.Tool.Crypto;
using System.Security.Cryptography;

namespace Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            string plaintext = "abc"; string strmd5 = "900150983CD24FB0D6963F7D28E17F72"; string strdes = "Wr+MOY7jM8M=";

            //MD5
            var s1 = MD5Crypto.Encrypt(plaintext);
            Console.WriteLine("MD5 加密：{0} {1} {2}", s1 == strmd5, strmd5, s1); Console.WriteLine();

            //DES
            var s2 = DESCrypto.Encrypt(plaintext);
            Console.WriteLine("DES 加密：{0} {1} {2}", s2 == strdes, strdes, s2);

            var s3 = DESCrypto.Decrypt(s2);
            Console.WriteLine("DES 解密：{0} {1} {2}", s3 == plaintext, plaintext, s3); Console.WriteLine();

            //RSA           
            string modulus = "nJDcBWNIV+DzZb8ZY5h4JJInVwVy5NvJ9hG0qH0TUM36j5DUFeUivBIdX+7fxwKIxPRkRyvwVjGjnMxna3Kq53Y5BLGpl84DvRqPGjxly2kAitbuHRIR5iiuza0rbA+ZPo/8kNrbRCYquaqnL1KIrDcIh7bZDWN6qY22+RVaVvs=";

            string publicExponent = "AQAB";
            string privateExponent = "ZZTTPCerc2D/ar9vYKA3KzssjRh68CPuSFo6hasJEj9iVy2XfVE6lR2Hs4uP41YwmOEcAtVuTO5OAljYrO0sFpdYNrEthZG5UBkC2wH+SsXOAaTDb2YRCEsdxFA8MRqRQLux/9/Fef/oIk+od1sjC3WzBwMqvVHBO232u9V9suE=";

            //公钥加密
            var s4 = RSACrypto.EncryptByPublicExponent(plaintext, modulus, publicExponent);
            Console.WriteLine("RSA 公钥加密：" + s4);

            string p = "y8v6G7Ap6jeTHILLAjQT0auvd9kRh91txQ4YkGf8ocijRbThKgAtWUrvNx27km6PEetWqw0VnA2YN53v6WCBMQ==";
            string q = "xKuz+9vgOYZf9WvA0vU8byCmZd93mYrw+uAymUiT6jvG1MQ0vAQMW7wwoifJYIqWFNZo356R6g2OeOz8Edfv6w==";
            string dp = "vqI3et721ljWC71tGMqOH3txz7IFbAn9PG9LGwmqj8uWrwXb+eXghb5KtkvhwcAZpLF3iNncdPViheP/H1degQ==";
            string dq = "dZ+ruYo7hKwVYBbd8E2zo1MHsg4A3df3YFQObxa1QHYX6NCgKYLSUVswSws4qYC5WiUR/Aw+gJkzCKfT6mgXmQ==";
            string inverseQ = "Fohpu2QfkHBCy11L0MV88pX3+EszJWWSgXqsGUzxTx0c2WK33o5wZkjq0AEKgk19aOOJc0RoKwcw6vtRRux/+Q==";
            //私钥解密
            var s5 = RSACrypto.DecryptByPrivateExponent(s4, modulus, privateExponent, publicExponent, p, q, dp, dq, inverseQ);
            var s55 = RSACrypto.Decrypt(s4, modulus, privateExponent);

            Console.WriteLine("RSA 私钥解密 ： {0} {1} {2}", s5 == plaintext, plaintext, s5);
            Console.WriteLine("RSA 私钥解密2： {0} {1} {2}", s55 == plaintext, plaintext, s55); Console.WriteLine();

            //私钥加密
            var s6 = RSACrypto.Encrypt(plaintext, modulus, privateExponent);
            Console.WriteLine("RSA 私钥加密：" + s6);

            //公钥解密
            var str6 = RSACrypto.Decrypt(s6, modulus, publicExponent);
            Console.WriteLine("RSA 公钥解密2：{0} {1} {2}", str6 == plaintext, plaintext, str6);

            Console.ReadKey();
        }
    }
}
