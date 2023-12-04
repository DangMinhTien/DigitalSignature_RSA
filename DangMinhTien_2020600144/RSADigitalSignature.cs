using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace DangMinhTien_2020600144
{
    public class RSADigitalSignature
    {
        public RSAParameters PublicParam { get; set; }
        public RSAParameters PrivateParam { get; set; }

        public RSACryptoServiceProvider? RSAalg { get; set; }

        public int KeySize { get; set; }

        public string? PublicKeyHex { get; set; }
        public string? PrivateKeyHex { get; set; }


        public RSADigitalSignature()
        {
            KeySize = 2048;
        }


        // hàm tạo khóa
        public void CreateKey(int keySize = 2048)
        {
            RSAalg = new(keySize);
            KeySize = keySize;
            PublicParam = RSAalg.ExportParameters(false);
            PrivateParam = RSAalg.ExportParameters(true);
            PublicKeyHex = Convert.ToHexString(RSAalg.ExportRSAPublicKey());
            PrivateKeyHex = Convert.ToHexString(RSAalg.ExportRSAPrivateKey());
        }

        // hàm băm dữ liệu, sinh chữ ký
        public byte[]? HashAndSign(byte[] originalData)
        {
            try
            {
                // Tạo đối tượng RSA
                RSACryptoServiceProvider rsaCSP = new();

                // Import các tham số bí mật để tạo khóa
                rsaCSP.ImportParameters(PrivateParam);

                // Băm dữ liệu sử dụng SHA256
                using SHA256 hash = SHA256.Create();
                byte[] hashedData = hash.ComputeHash(originalData);

                // Ký
                byte[] signedHash = rsaCSP.SignHash(hashedData, HashAlgorithmName.SHA256.Name);

                return signedHash;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data was not signed or verified");
                return null;
            }
        }
        // Kiểm tra tính toàn vẹn của dữ liệu và chữ ký
        public VerifySignatureResult VerifySignature(byte[] receivedData, byte[] signature)
        {
            try
            {
                // Tạo đối tượng RSA
                RSACryptoServiceProvider rsaCSP = new();

                // Import các tham số công khai để tạo khóa
                rsaCSP.ImportParameters(PublicParam);

                // Kiểm tra tính toàn vẹn dữ liệu
                string? hashAlgorithmID = CryptoConfig.MapNameToOID(HashAlgorithmName.SHA256.Name ?? "SHA256");
                if (hashAlgorithmID == null)
                {
                    return VerifySignatureResult.Error;
                }
                bool isValidData = rsaCSP.VerifyData(receivedData, hashAlgorithmID, signature);
                if (!isValidData)
                {
                    return VerifySignatureResult.DataChanged;
                }

                // Băm dữ liệu sử dụng SHA256
                using SHA256 hash = SHA256.Create();
                byte[] hashedData = hash.ComputeHash(receivedData);

                // Kiểm tra chữ ký
                bool isValidSignature = rsaCSP.VerifyHash(hashedData, hashAlgorithmID, signature);
                if (!isValidSignature)
                {
                    return VerifySignatureResult.InvalidSignature;
                }
                return VerifySignatureResult.ValidSignature;
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("The data was not signed or verified");
                return VerifySignatureResult.Error;
            }
        }
    }

    public enum VerifySignatureResult
    {
        Error = 0,
        DataChanged = 1,
        InvalidSignature = 2,
        ValidSignature = 3
    }
}
