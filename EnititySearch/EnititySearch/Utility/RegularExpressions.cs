using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnititySearch.Utility
{
    public static class RegularExpressions
    {        
        public const string notPrecededByNonWhiteSpace = "(?<!\\S)";

        public const string nonFollowedByNonWhiteSpace = "(?!\\S)";

        public const string regexNumber = notPrecededByNonWhiteSpace + "-?(\\d{1,3},(\\d{3},)*\\d{3}|\\d+)(.\\d+)?" + nonFollowedByNonWhiteSpace;
    }
}
