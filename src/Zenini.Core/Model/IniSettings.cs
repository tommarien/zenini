using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zenini.Model
{
    public class IniSettings : IIniSettings
    {
        private readonly List<ISection> _sections;

        public IniSettings(IEnumerable<ISection> sections)
        {
            _sections = new List<ISection>(sections);
        }

        public ISection[] Sections
        {
            get { return _sections.ToArray(); }
        }

        public IEnumerator<ISection> GetEnumerator()
        {
            return _sections.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ISection this[string name]
        {
            get { return _sections.FirstOrDefault(s => string.Equals(s.Name, name, StringComparison.OrdinalIgnoreCase)); }
        }
    }
}