using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Helpers
{
    public static class StringHelper
    {
        /// <summary>
        /// Indicates whether this string is null or an System.String.Empty string.
        /// </summary>
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
    }
}
