using System.Text.RegularExpressions;

namespace Zenini.Patterns
{
    public class SectionPattern
    {
        private static readonly Regex SectionRegex = new Regex(@"\A\[([^;]*)\]\s*;?.*\z", RegexOptions.Compiled);

        public virtual bool Matches(string line)
        {
            return SectionRegex.IsMatch(line);
        }

        public virtual string Extract(string line)
        {
            MatchCollection collection = SectionRegex.Matches(line);

            string sectionName = collection[0].Groups[1].Value.Trim();

            return sectionName;
        }
    }
}