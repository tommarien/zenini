using System.Text.RegularExpressions;

namespace Zenini.Core.Patterns
{
    public class SectionPattern
    {
        private readonly Regex _regex = new Regex(@"\A\[(.*)\]\z", RegexOptions.Compiled);

        public bool Matches(string value)
        {
            return _regex.IsMatch(value);
        }
    }
}