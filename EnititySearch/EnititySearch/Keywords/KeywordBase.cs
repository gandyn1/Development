using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EnititySearch.Keywords.DataType;
using System.Text.RegularExpressions;

namespace EnititySearch.Keywords
{
    public abstract class KeywordBase
    {
        public String Name { get; set; }
        public List<String> Alias { get; set; }

        public KeywordBase(String Name)
        {
            this.Name = Name;
            this.Alias = new List<string>();
            
            using (var Entities = new EnititySearchDBEntities1()){
                var list = Entities.Keywords.ToList().Where(o => o.Name == Name);
                if(list.Count() > 0)
                    this.Alias = list.First().Aliases.Select(o => o.Name).ToList();
            }

            this.Alias.Add(Name);
        }

        /// <summary>
        /// Default Find will search value for Alias's
        /// </summary>
        public virtual List<KeywordValue> Find(String Text)
        {
            List<KeywordValue> List = new List<KeywordValue>();            
            Text = Text.ToLower();

            foreach (var alias in this.Alias.OrderByDescending(o => o.Length).Select(o => o.ToLower()).Distinct())
            {
                if (Text.StartsWith(String.Format("{0} ", alias)))
                    List.Add(new KeywordValue(alias, 0, this));

                if (Text.EndsWith(String.Format(" {0}", alias)))
                    List.Add(new KeywordValue(alias, Text.Length - alias.Length, this));

                foreach (Match match in Regex.Matches(Text, String.Format(" {0} ", alias), RegexOptions.IgnoreCase))
                    List.Add(new KeywordValue(alias.Trim(), match.Index, this));
            } 
              
            return List;
        }

        #region "Helper"
        protected List<KeywordValue> Match(String Text, String Pattern)
        {
            List<KeywordValue> List = new List<KeywordValue>();

            foreach (Match match in Regex.Matches(Text, Pattern, RegexOptions.IgnoreCase))
                List.Add(new KeywordValue(match.ToString(), match.Index, this));

            return List;
        }
        #endregion

        #region Static

        public static List<KeywordBase> getDerivedClasses()
        {
            var value = new List<KeywordBase>();

            var types = AppDomain.CurrentDomain.GetAssemblies().ToList()
                .SelectMany(s => s.GetTypes())
                .Where(p => !p.IsAbstract && typeof(KeywordBase).IsAssignableFrom(p) &&
                        !typeof(Field.Field).IsAssignableFrom(p));

            foreach (var type in types)
                value.Add((KeywordBase)Activator.CreateInstance(type));

            return value;
        }

        public static List<KeywordValue> getKeywordValues(String Text)
        {
            return getKeywordValues(Text, getDerivedClasses());
        }

        public static List<KeywordValue> getKeywordValues(String Text, List<KeywordBase> Keywords)
        {
            var value = new List<KeywordValue>();

            foreach (var Keyword in Keywords)
                value = value.Union(Keyword.Find(Text)).ToList();

            return value;
        }

        #endregion
    }
}
