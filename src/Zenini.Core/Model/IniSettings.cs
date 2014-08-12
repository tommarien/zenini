using System.Collections;
using System.Collections.Generic;

namespace Zenini.Model
{
    public class IniSettings : IIniSettings
    {
        private readonly IDictionary<string, ISection> _sections;

        public IniSettings(IDictionary<string, ISection> sections)
        {
            _sections = sections;
        }

        public IEnumerator<ISection> GetEnumerator()
        {
            return _sections.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public ISection this[string name]
        {
            get { return _sections.ContainsKey(name) ? _sections[name] : Section.Empty; }
        }
    }
}