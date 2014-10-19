using System;
using System.Text.RegularExpressions;

namespace Zenini.Patterns
{
    public class KeyValuePattern
    {
        private static readonly Regex KeyValueRegex = new Regex(@"^\s*(.+?)\s*=\s*?([^;]*)?\s*;?.*$", RegexOptions.Compiled);

        public virtual bool Matches(string line)
        {
            return KeyValueRegex.IsMatch(line);
        }

        public virtual Tuple<string, string> Extract(string line)
        {
            MatchCollection collection = KeyValueRegex.Matches(line);

            string key = collection[0].Groups[1].Value;
            string value = collection[0].Groups[2].Value;

            if (value.StartsWith("\"") && value.EndsWith("\""))
                value = value.Substring(1, value.Length - 2);
            else
            {
                value = value.Trim();
            }

            return new Tuple<string, string>(key, value);
        }
    }
}