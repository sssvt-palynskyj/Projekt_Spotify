using System;
using System.Text;



namespace SongsAndVotesCommon.Services
{



    /// <summary>
    /// Provides methods to convert values of one data type to another.
    /// </summary>
    public class ConvertService
    {



        /// <summary>
        /// Encodes a given array of bytes to a string.
        /// </summary>
        /// <param name="bytes">Bytes to encode.</param>
        /// <returns>Returns a string with the encoded array.</returns>
        public string EncodeToString(byte[] bytes)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in bytes)
            {
                string hexCode = ByteToString(b);
                sb.Append(hexCode);
            }
            return sb.ToString();
        }



        /// <summary>
        /// Decodes a given string and makes a byte array out of it.
        /// </summary>
        /// <param name="text">String to decode.</param>
        /// <returns>Returns an array of bytes taken (decoded) from the given string.</returns>
        public byte[] DecodeToByteArray(string text)
        {
            byte[] bytes = new byte[text.Length / 2];
            for (int i = 0, j = 0; i < text.Length - 1; i += 2, j++)
            {
                string hexCode = text[i].ToString() + text[i + 1].ToString();
                byte b = StringToByte(hexCode);
                bytes[j] = b;
            }
            return bytes;
        }



        private static string ByteToString(byte b)
        {
            int lowerHex = ((int)b) % 16;
            int higherHex = ((int)b) / 16;
            char lowerHexChar = HexValueToHexCode(lowerHex);
            char higherHexChar = HexValueToHexCode(higherHex);
            string hexCode = higherHexChar.ToString() + lowerHexChar.ToString();
            return hexCode;
        }



        private static byte StringToByte(string s)
        {
            if (s.Length != 2)
            {
                throw new ArgumentException(String.Format($"The given string is not recognized as a hexadecimal code for a byte value: {s}"), "s");
            }
            int higherHex = HexCodeToHexValue(s[0]);
            int lowerHex = HexCodeToHexValue(s[1]);
            int hex = higherHex * 16 + lowerHex;
            return (byte)hex;
        }



        private static char HexValueToHexCode(int hexValue)
        {
            return ((hexValue < 10) ? ((char)(((int)'0') + hexValue)) : ((char)(((int)'A') + (hexValue - 10))));
        }



        private static int HexCodeToHexValue(char hexCode)
        {
            if ( ! (((hexCode >= '0') && (hexCode <= '9')) || ((hexCode >= 'A') && (hexCode <= 'F')) || ((hexCode >= 'a') && (hexCode <= 'f'))) )
            {
                throw new ArgumentException(String.Format($"Cannot recognize a hexadecimal digit in the given character: \'{hexCode}\'"), "hexCode");
            }
            char hexCodeUpper = hexCode.ToString().ToUpper()[0];
            return (((hexCodeUpper >= '0') && (hexCodeUpper <= '9')) ? (((int) hexCodeUpper) - ((int) '0')) : (((int)hexCodeUpper) - ((int)'A') + 10));
        }



    }



}
