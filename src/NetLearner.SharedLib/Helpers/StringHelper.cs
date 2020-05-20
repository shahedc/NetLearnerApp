using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace NetLearner.SharedLib.Helpers
{
    public static class StringHelper
    {
        /// Extended version of the string.Contains() method, 
        /// accepting a [StringComparison] object to perform different kind of comparisons
        /// </summary>
        /// source: https://www.ryadel.com/en/asp-net-c-case-insensitive-string-contains-helper-extension-method/
        /// usage: sourceString.Contains("Search-Word", StringComparison.InvariantCultureIgnoreCase);
        public static bool Contains(this string source, string value, StringComparison comparisonType)
        {
            return source?.IndexOf(value, comparisonType) >= 0;
        }

        /// Extended version of the string.Contains() method, 
        /// accepting a [CompareInfo] object to perform different kind of comparisons
        /// and a [CultureInfo] object instance to apply them to the given culture casing rules.
        /// </summary>
        /// source: https://www.ryadel.com/en/asp-net-c-case-insensitive-string-contains-helper-extension-method/
        /// usage: sourceString.Contains("Search-Word", StringComparison.InvariantCultureIgnoreCase, new System.Globalization.CultureInfo("en-US")));

        public static bool Contains(this string source, string value, CompareOptions options, CultureInfo culture)
        {
            return culture.CompareInfo.IndexOf(source, value, options) >= 0;
        }
    }
}
