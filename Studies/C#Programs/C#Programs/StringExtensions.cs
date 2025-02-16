using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Programs
{
    static class StringExtensions
    {
        public static string Shorten(this string text, int length)
        {
            if (text.Length <= length)
            {
                return text;
            }
            else
            {
                return text.Substring(0, length) + "...";
            }
        }
        public static string Shorten(this string text, int length, int start)
        {
            if (text.Length <= length)
            {
                return text;
            }
            else
            {
                return text.Substring(start, length) + "...";
            }
        }
        public static string ReverseString(this string str)
        {
            if (string.IsNullOrEmpty(str) || str.Length == 1)
            {
                return str;
            }

            StringBuilder reversedString = new StringBuilder(str.Length);

            for (int i = str.Length - 1; i >= 0; i--)
            {
                reversedString.Append(str[i]);
            }

            return reversedString.ToString();
        }
        /// <summary>
        /// Removes duplicate entries from a separated string.
        /// </summary>
        /// <param name="input">The input string containing items separated by the specified separator.</param>
        /// <param name="separator">The character used to separate the items (default is ';').</param>
        /// <returns>A string with duplicate items removed. A trailing separator is added if the result is not empty.</returns>
        public static string RemoveDuplicates(string input, char separator = ';')
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }

            string[] items = input.Split(separator);

            HashSet<string> seen = new HashSet<string>();
            List<string> uniqueItems = new List<string>();

            foreach (string item in items)
            {
                if (!string.IsNullOrWhiteSpace(item) && seen.Add(item))
                {
                    uniqueItems.Add(item);
                }
            }

            return uniqueItems.Count > 0 ? string.Join(separator.ToString(), uniqueItems) + separator : string.Empty;
        }

        public static string RemoveDuplicatesWithLinq(string input, char separator = ';')
        {
            if (string.IsNullOrEmpty(input))
                return input;

            var names = input.Split(new char[] { separator }, StringSplitOptions.RemoveEmptyEntries);
            var uniqueNames = names.Distinct();

            return uniqueNames.Any() ? string.Join(separator.ToString(), uniqueNames) + separator : string.Empty;
        }

        public static string RemoveDuplicatesWithList(string input, char separator = ';')
        {
            if (string.IsNullOrEmpty(input))
                return input;

            string[] names = input.Split(separator);
            List<string> uniqueNamesList = new List<string>();

            foreach (var name in names)
            {
                if (!string.IsNullOrWhiteSpace(name) && !uniqueNamesList.Contains(name))
                {
                    uniqueNamesList.Add(name);
                }
            }

            return uniqueNamesList.Count > 0 ? string.Join(separator.ToString(), uniqueNamesList) + separator : string.Empty;
        }

        public static string RemoveDuplicatesWithHashSet(string input, char separator = ';')
        {
            if (string.IsNullOrEmpty(input))
                return input;

            HashSet<string> uniqueNames = new HashSet<string>();

            foreach (var name in input.Split(separator))
            {
                if (!string.IsNullOrWhiteSpace(name))
                {
                    uniqueNames.Add(name);
                }
            }

            return uniqueNames.Count > 0 ? string.Join(separator.ToString(), uniqueNames) + separator : string.Empty;
        }
    }
}
