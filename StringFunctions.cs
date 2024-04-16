using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kuittisovellus
{
    public static class StringFunctions
    {
        public static string RemoveNonNumbersRetainDot(string s)
        {
            return Regex.Replace(s, "[^0-9.]", string.Empty);
        }

    }
}
