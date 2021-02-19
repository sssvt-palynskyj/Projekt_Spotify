using System;

using SongsAndVotesCommon.Interfaces;



namespace SongsAndVotesCommon.Cryptography
{



    /// <summary>
    /// Implements the encryption based on shifting Unicode codes of characters.
    /// Caution: Very easy to crack!!!
    /// </summary>
    internal class CodeShifting : ICrypto
    {



        string ICrypto.Encrypt(string textToEncrypt)
        {
            throw new NotImplementedException();
        }



        string ICrypto.Decrypt(string textToDecrypt)
        {
            throw new NotImplementedException();
        }



    }



}
