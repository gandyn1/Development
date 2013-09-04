using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnititySearch.Keywords
{
    public class KeywordValue : IComparable
    {
        public Object Value { get; private set; }
        public int Index { get; private set; }
        public KeywordBase Keyword { get; private set; }

        public KeywordValue(Object Value, int Position, KeywordBase Keyword)
        {
            this.Value = Value; this.Index = Position; this.Keyword = Keyword;
        }

        public int CompareTo(Object obj)
        {
            return this.Index.CompareTo(((KeywordValue)obj).Index);
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
