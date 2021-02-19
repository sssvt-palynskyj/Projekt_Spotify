using System;
using System.Security.Cryptography;
using System.IO;
using SongsAndVotesCommon.Services;

namespace SongsAndVotesMain
{



    internal class UserServiceTest
    {



        public void GenerateAesKeyAndInitializationVector()
        {

            byte[] aesKey;
            byte[] aesIV;
            using (Aes aes = Aes.Create())
            {
                aesKey = aes.Key;
                aesIV = aes.IV;
            }

            ConvertService convertService = new ConvertService();

            string aesKeyEncoded = convertService.EncodeToString(aesKey);
            string aesIVEncoded = convertService.EncodeToString(aesIV);

            //string secretFile = @"..\..\Resources\Database\Secret.txt";
            string secretFile = @"..\..\..\Resources\Database\Secret.txt";
            StreamWriter sw = new StreamWriter(secretFile);
            sw.WriteLine(aesKeyEncoded);
            sw.WriteLine(aesIVEncoded);
            sw.Close();
            sw.Dispose();

        }



    }



}
