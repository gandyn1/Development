using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace EnititySearch.Keywords.DataType
{
    public class Number : DataTypeBase 
    {        
        public Number() : base("Number") { }

        public override List<KeywordValue> Find(string Text)
        {
            return this.Match(Text, Utility.RegularExpressions.regexNumber);                        
        }
    }
}
