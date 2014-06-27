﻿using System.Text.RegularExpressions;

namespace Zenini.Core.Patterns
{
    public class SectionPattern
    {
        private static readonly Regex SectionRegex = new Regex(@"\A\[(.*)\]\s*\z", RegexOptions.Compiled);

        public bool Matches(string value)
        {
            return SectionRegex.IsMatch(value);
        }

        public string Extract(string value)
        {
            string sectionName = null;

            MatchCollection collection = SectionRegex.Matches(value);

            if (collection.Count == 1)
            {
                sectionName = collection[0].Groups[1].Value.Trim();
            }

            return sectionName;
        }
    }
}