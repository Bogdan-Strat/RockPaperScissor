using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissor.ExtensionMethods
{
    public static class StringExtensions
    {
        public static string CapitalizeFirstLetter(this string str)
        {
            return $"{char.ToUpper(str[0])}{str.Substring(1)}";
        }
    }
}
