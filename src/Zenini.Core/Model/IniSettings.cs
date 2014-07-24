using System.Collections.Generic;
using System.Linq;

namespace Zenini.Model
{
    public class IniSettings : IIniSettings
    {
        private readonly HashSet<ISection> _sections = new HashSet<ISection>();

        public ISection[] Sections
        {
            get { return _sections.ToArray(); }
        }

        public bool AddSection(ISection section)
        {
            return _sections.Add(section);
        }
    }
}