using System;



namespace SongsAndVotesCommon.Interfaces
{



    /// <summary>
    /// Defines methods to be implemented by classes providing cryptographic features.
    /// </summary>
    public interface ICrypto
    {



        /// <summary>
        /// Encrypts a given text.
        /// </summary>
        /// <param name="textToEncrypt">Text to be encrypted.</param>
        /// <returns>Returns the encrypted text.</returns>
        string Encrypt(string textToEncrypt);

        /// <summary>
        /// Decrypts a given text.
        /// </summary>
        /// <param name="textToDecrypt">Text to be decrypted.</param>
        /// <returns>Returns the decrypted text.</returns>
        string Decrypt(string textToDecrypt);



    }



}
