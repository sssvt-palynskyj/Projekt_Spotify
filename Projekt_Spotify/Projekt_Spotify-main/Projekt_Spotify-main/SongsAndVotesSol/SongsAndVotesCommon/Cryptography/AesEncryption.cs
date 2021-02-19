using System;
using System.IO;
using System.Security.Cryptography;

using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Services;



namespace SongsAndVotesCommon.Cryptography
{



    /// <summary>
    /// Implements the AES encryption.
    /// </summary>
    internal class AesEncryption : ICrypto
    {



        /// <summary>A "secret file" with AES key and initialization vector.</summary>
        private const string SecretFile = @"..\..\..\Resources\Database\Secret.txt";



        /// <summary>AES key.</summary>
        private byte[] key;

        /// <summary>Initializatio vector.</summary>
        private byte[] initializationVector;



        /// <summary>
        /// Constructor.
        /// </summary>
        public AesEncryption()
        {

            // Read the key and initialization vector from the secret file.
            string keyEncoded;
            string ivEncoded;
            using (StreamReader reader = new StreamReader(SecretFile))
            {
                keyEncoded = reader.ReadLine();
                ivEncoded = reader.ReadLine();
            }

            // Decode data and store it in the appropriate instance fields.
            ConvertService convertService = new ConvertService();
            this.key = convertService.DecodeToByteArray(keyEncoded);
            this.initializationVector = convertService.DecodeToByteArray(ivEncoded);

        }



        string ICrypto.Encrypt(string textToEncrypt)
        {

            byte[] encryptedBytes;

            // Prepare an AES object.
            using (Aes aes = Aes.Create())
            {
                aes.Key = this.key;
                aes.IV = this.initializationVector;

                // Create an encryptor for stream transformation.
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);

                // Prepare necessary streams and encrypt the given text.
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter streamWriter = new StreamWriter(cryptoStream))
                        {
                            // Write the given text to the stream.
                            streamWriter.Write(textToEncrypt);
                        }
                        // Get the encrypted data from the memory stream.
                        encryptedBytes = memoryStream.ToArray();
                    }
                }

            }

            // Convert the byte array with the encrypted text into a string.
            ConvertService convertService = new ConvertService();
            string encryptedText = convertService.EncodeToString(encryptedBytes);

            return encryptedText;

        }



        string ICrypto.Decrypt(string textToDecrypt)
        {
            string decryptedText = null;

            byte[] bytesToDecrypt;

            // Convert the byte array with the encrypted text into a string.
            ConvertService convertService = new ConvertService();
            bytesToDecrypt = convertService.DecodeToByteArray(textToDecrypt);

            // Prepare an AES object.
            using (Aes aes = Aes.Create())
            {
                aes.Key = this.key;
                aes.IV = this.initializationVector;

                // Create a decryptor for stream transformation.
                //ICryptoTransform decryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);

                // Prepare necessary streams and encrypt the given text.
                using (MemoryStream memoryStream = new MemoryStream(bytesToDecrypt))
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader streamReader = new StreamReader(cryptoStream))
                        {
                            // Read (and decrypt) the given text.
                            decryptedText = streamReader.ReadToEnd();
                        }
                    }
                }

            }

            return decryptedText;

        }



    }



}
