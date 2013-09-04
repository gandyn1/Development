using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EnititySearch.Keywords.Field
{
    public class Field : KeywordBase
    {
        public Field(String Name, List<String> Alias = null) : base(Name) {
            if (Alias != null) this.Alias = Alias;            
        }
    }
}
