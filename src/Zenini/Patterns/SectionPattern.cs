using System.Text.RegularExpressions;

namespace Zenini.Patterns
{
    public class SectionPattern
    {
        private static readonly Regex SectionRegex = new Regex(@"\A\[(.*)\]\s*\z", RegexOptions.Compiled);

        public virtual bool Matches(string line)
        {
            return SectionRegex.IsMatch(line);
        }

        public virtual string Extract(string line)
        {
            string sectionName = null;

            MatchCollection collection = SectionRegex.Matches(line);

            if (collection.Count == 1)
            {
                sectionName = collection[0].Groups[1].Value.Trim();
            }

            return sectionName;
        }
    }
}