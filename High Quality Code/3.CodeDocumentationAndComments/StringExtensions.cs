﻿namespace Telerik.ILS.Common
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Text.RegularExpressions;

    /// <summary>
    /// Class which contains extension methods for the <see cref="System.String"/> class.
    /// </summary>
    public static class StringExtensions
    {
        public static string ToMd5Hash(this string input)
        {
            var md5Hash = MD5.Create();

            // Convert the input string to a byte array and compute the hash.
            var data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new StringBuilder to collect the bytes
            // and create a string.
            var builder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                builder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return builder.ToString();
        }

        /// <summary>
        /// Checks if a given string can be interpreted as a 'true' <see cref="System.Boolean"/> value.
        /// </summary>
        /// <param name="input">The string to be checked.</param>
        /// <returns>True if the string can be interpreted as 'true' boolean value. </returns>
        public static bool ToBoolean(this string input)
        {
            var stringTrueValues = new[] { "true", "ok", "yes", "1", "да" };
            return stringTrueValues.Contains(input.ToLower());
        }

        /// <summary>
        /// Converts a given string into a <see cref="Sistem.Int16"/> value.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns> The <see cref="System.In16"/> representation of the string if conversion is possible, otherwise returns 0.</returns>
        public static short ToShort(this string input)
        {
            short shortValue;
            short.TryParse(input, out shortValue);
            return shortValue;
        }

        /// <summary>
        /// Converts a given string into a <see cref="Sistem.Int32"/> value.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns> The <see cref="System.In32"/> representation of the string if conversion is possible, otherwise returns 0.</returns>
        public static int ToInteger(this string input)
        {
            int integerValue;
            int.TryParse(input, out integerValue);
            return integerValue;
        }

        /// <summary>
        /// Converts a given string into a <see cref="Sistem.Int64"/> value.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns> The <see cref="System.In64"/> representation of the string if conversion is possible, otherwise returns 0.</returns>
        public static long ToLong(this string input)
        {
            long longValue;
            long.TryParse(input, out longValue);
            return longValue;
        }

        /// <summary>
        /// Converts a given string into a <see cref="Sistem.DateTime"/> value.
        /// </summary>
        /// <param name="input">The string to be converted.</param>
        /// <returns> The <see cref="System.DateTime"/> representation of the string if conversion is possible, otherwise returns date 01.01.0001 00:00:00.</returns>
        public static DateTime ToDateTime(this string input)
        {
            DateTime dateTimeValue;
            DateTime.TryParse(input, out dateTimeValue);
            return dateTimeValue;
        }

        /// <summary>
        /// Capitalizes the first letter of a given string.
        /// </summary>
        /// <param name="input">The string to modify.</param>
        /// <returns>Copy of the given string with capitalized first letter.</returns>
        public static string CapitalizeFirstLetter(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            return input.Substring(0, 1).ToUpper(CultureInfo.CurrentCulture) + input.Substring(1, input.Length - 1);
        }


        /// <summary>
        /// Extracts a substring which is between two given substrings and is placed after a given index of the given string.
        /// </summary>
        /// <param name="input">The string to extract from.</param>
        /// <param name="startString">The substring after which starts the searched substring.</param>
        /// <param name="endString">The substring before which ends the searched substring.</param>
        /// <param name="startFrom">The index from which to start looking for the searched substring.</param>
        /// <returns>A substring which is between <paramref name="startString"/> and <paramref name="endString"/> and 
        /// starting the search from <paramref name="startFrom"/>. Returns empty string if <paramref name="startString"/> or <paramref name="endString"/>
        /// don't occur within <paramref name="input"/>.</returns>
        public static string GetStringBetween(this string input, string startString, string endString, int startFrom = 0)
        {
            input = input.Substring(startFrom);
            startFrom = 0;

            // Check if input contains startString and endString 
            if (!input.Contains(startString) || !input.Contains(endString))
            {
                return string.Empty;
            }

            // Determine the start index of the searched substring
            var startPosition = input.IndexOf(startString, startFrom, StringComparison.Ordinal) + startString.Length;
            if (startPosition == -1)
            {
                return string.Empty;
            }

            // Determine the end index of the searched substring
            var endPosition = input.IndexOf(endString, startPosition, StringComparison.Ordinal);
            if (endPosition == -1)
            {
                return string.Empty;
            }

            return input.Substring(startPosition, endPosition - startPosition);
        }

        /// <summary>
        /// Replaces the cyrillic letters in a text with their latin representation
        /// </summary>
        /// <param name="input">The string for which the letters to be replaced.</param>
        /// <returns>A string in which all occurances of cyrillic letters are replaced with their latin representation.</returns>
        public static string ConvertCyrillicToLatinLetters(this string input)
        {
            var bulgarianLetters = new[]
                                       {
                                           "а", "б", "в", "г", "д", "е", "ж", "з", "и", "й", "к", "л", "м", "н", "о", "п",
                                           "р", "с", "т", "у", "ф", "х", "ц", "ч", "ш", "щ", "ъ", "ь", "ю", "я"
                                       };
            var latinRepresentationsOfBulgarianLetters = new[]
                                                             {
                                                                 "a", "b", "v", "g", "d", "e", "j", "z", "i", "y", "k",
                                                                 "l", "m", "n", "o", "p", "r", "s", "t", "u", "f", "h",
                                                                 "c", "ch", "sh", "sht", "u", "i", "yu", "ya"
                                                             };
            for (var i = 0; i < bulgarianLetters.Length; i++)
            {
                input = input.Replace(bulgarianLetters[i], latinRepresentationsOfBulgarianLetters[i]);
                input = input.Replace(bulgarianLetters[i].ToUpper(), latinRepresentationsOfBulgarianLetters[i].CapitalizeFirstLetter());
            }

            return input;
        }

        /// <summary>
        /// Replaces the latin letters in a text with their cyrillic representation
        /// </summary>
        /// <param name="input">The string for which the letters to be replaced.</param>
        /// <returns>A string in which all occurances of latin letters are replaced with their cyrillic representation.</returns>
        public static string ConvertLatinToCyrillicKeyboard(this string input)
        {
            var latinLetters = new[]
                                   {
                                       "a", "b", "c", "d", "e", "f", "g", "h", "i", "j", "k", "l", "m", "n", "o", "p",
                                       "q", "r", "s", "t", "u", "v", "w", "x", "y", "z"
                                   };

            var bulgarianRepresentationOfLatinKeyboard = new[]
                                                             {
                                                                 "а", "б", "ц", "д", "е", "ф", "г", "х", "и", "й", "к",
                                                                 "л", "м", "н", "о", "п", "я", "р", "с", "т", "у", "ж",
                                                                 "в", "ь", "ъ", "з"
                                                             };

            for (int i = 0; i < latinLetters.Length; i++)
            {
                input = input.Replace(latinLetters[i], bulgarianRepresentationOfLatinKeyboard[i]);
                input = input.Replace(latinLetters[i].ToUpper(), bulgarianRepresentationOfLatinKeyboard[i].ToUpper());
            }

            return input;
        }

        /// <summary>
        /// Converts a username represented as string to a valid username, by removing all illigal characters. 
        /// Valid username contains only latin letters, digits, "_" and ".";
        /// </summary>
        /// <param name="input">The username represented as <see cref="System.String"/>.</param>
        /// <returns>The valid username according to the rules stated above.</returns>
        public static string ToValidUsername(this string input)
        {
            input = input.ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.]+", string.Empty);
        }

        /// <summary>
        /// Converts a file name represented as string to a valid file name, by removing all illigal characters. 
        /// Valid username contains only latin letters, digits, "_", "-" and ".";
        /// </summary>
        /// <param name="input">The file name represented as <see cref="System.String"/>.</param>
        /// <returns>The valid file name according to the rules stated above.</returns>
        public static string ToValidLatinFileName(this string input)
        {
            input = input.Replace(" ", "-").ConvertCyrillicToLatinLetters();
            return Regex.Replace(input, @"[^a-zA-z0-9_\.\-]+", string.Empty);
        }

        /// <summary>
        /// Gets a substring with specified amount of characters from the beginning of the given string.
        /// </summary>
        /// <param name="input">The input string.</param>
        /// <param name="charsCount">Specifies the number of characters to be extracted.</param>
        /// <returns>A substring with the specified amount of characters from the beginning of the given string or 
        /// the whole string if its length is smaller than the specified amonunt of characters.</returns>
        public static string GetFirstCharacters(this string input, int charsCount)
        {
            return input.Substring(0, Math.Min(input.Length, charsCount));
        }
        
        /// <summary>
        /// Tries to interpret the input string as a file name and returns its extention.
        /// </summary>
        /// <param name="fileName">The input string</param>
        /// <returns>A string which represents the file extension or empty string if the input string can not be interpreted as a file name.</returns>                        
        public static string GetFileExtension(this string fileName)
        {
            if (string.IsNullOrWhiteSpace(fileName))
            {
                return string.Empty;
            }

            string[] fileParts = fileName.Split(new[] { "." }, StringSplitOptions.None);
            if (fileParts.Count() == 1 || string.IsNullOrEmpty(fileParts.Last()))
            {
                return string.Empty;
            }
            
            return fileParts.Last().Trim().ToLower();
        }

        /// <summary>
        /// Determines the content type of a file according to file extension.
        /// </summary>
        /// <param name="fileExtension">The file extension</param>
        /// <returns>The content type as a string.</returns>
        public static string ToContentType(this string fileExtension)
        {
            var fileExtensionToContentType = new Dictionary<string, string>
                                                 {
                                                     { "jpg", "image/jpeg" },
                                                     { "jpeg", "image/jpeg" },
                                                     { "png", "image/x-png" },
                                                     {
                                                         "docx",
                                                         "application/vnd.openxmlformats-officedocument.wordprocessingml.document"
                                                     },
                                                     { "doc", "application/msword" },
                                                     { "pdf", "application/pdf" },
                                                     { "txt", "text/plain" },
                                                     { "rtf", "application/rtf" }
                                                 };
            if (fileExtensionToContentType.ContainsKey(fileExtension.Trim()))
            {
                return fileExtensionToContentType[fileExtension.Trim()];
            }

            return "application/octet-stream";
        }

        /// <summary>
        /// Copies the characters of a string into a array of bytes.
        /// </summary>
        /// <param name="input">The input string</param>
        /// <returns>An array of bytes which containng the copied characters.</returns>
        public static byte[] ToByteArray(this string input)
        {
            var bytesArray = new byte[input.Length * sizeof(char)];
            Buffer.BlockCopy(input.ToCharArray(), 0, bytesArray, 0, bytesArray.Length);
            return bytesArray;
        }
    }
}
