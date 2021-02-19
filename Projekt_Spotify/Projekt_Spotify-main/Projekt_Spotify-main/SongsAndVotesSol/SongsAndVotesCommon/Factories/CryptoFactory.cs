using System;

using SongsAndVotesCommon.Interfaces;
using SongsAndVotesCommon.Cryptography;



namespace SongsAndVotesCommon.Factories
{



    /// <summary>
    /// Exposes cryptography-related factory methods.
    /// </summary>
    internal static class CryptoFactory
    {



        /// <summary>
        /// Gets an object implementing encryption.
        /// </summary>
        /// <returns>Returns the encryption-algorithm object.</returns>
        public static ICrypto GetCrypto()
        {
            //return new CodeShifting();
            return new AesEncryption();
        }



    }



}
