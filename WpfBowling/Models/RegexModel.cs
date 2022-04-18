using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WpfBowling.Models
{
    internal class RegexModel
    {
        private static Regex rgx;

        /// <summary>
        /// Gets if input contains 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isDigitChar(string throwScore)
        {
            rgx = new Regex(@"([\d])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains x; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isXChar(string throwScore)
        {
            rgx = new Regex(@"([x])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains /; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isForwardSlashChar(string throwScore)
        {
            rgx = new Regex(@"([/])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains x or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isXOrDigitChar(string throwScore)
        {
            rgx = new Regex(@"([\dx])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains / or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isForwardSlashOrDigitChar(string throwScore)
        {
            rgx = new Regex(@"([\d/])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains / or x; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isForwardSlashOrXChar(string throwScore)
        {
            rgx = new Regex(@"([x/])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }

        /// <summary>
        /// Gets if input contains / or x or 0-9; Ignore Case.
        /// </summary>
        /// <param name="throwScore">The incoming score value(string) to compare.</param>
        public static bool isForwardSlashOrXOrDigitChar(string throwScore)
        {
            rgx = new Regex(@"([\dx/])", RegexOptions.IgnoreCase);
            return rgx.IsMatch(throwScore);
        }
    }
}
