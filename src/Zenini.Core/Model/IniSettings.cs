using System.Collections.Generic;

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
    }
}