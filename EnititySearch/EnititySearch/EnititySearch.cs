using System;
using System.Collections.Generic;
using System.Linq;
using EnititySearch.Keywords;
using EnititySearch.Keywords.DataType;
using EnititySearch.Keywords.Functions;
using EnititySearch.Keywords.Conditional;
using EnititySearch.Keywords.Relational;
using EnititySearch.Keywords.Field;

namespace EnititySearch
{
    public class SearchEngine
    {
        public List<Field> Fields = new List<Field>();

        public String Search(String Text)
        {
            var KeywordsFound = KeywordBase.getKeywordValues(Text, KeywordBase.getDerivedClasses().Union(Fields).ToList());

            if (KeywordsFound.Count > 0)
            {
                KeywordsFound.Sort();
            }

            string value = "";
           
            if (KeywordsFound.Count > 0)
            {
                foreach (var keyword in KeywordsFound)
                    value += keyword.Value.ToString() + " ";

                value = value.TrimEnd();
            }

            return value;
        }

        public void addField(String Name, List<String> Alias = null)
        {
            Fields.Add(new Field(Name, Alias));
        }
    }
}
