using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zenini.Model
{
    public class IniSettings : IIniSettings
    {
        private readonly HashSet<ISection> _sections = new HashSet<ISection>();

        public ISection this[string name]
        {
            get { return _sections.FirstOrDefault(x => x.Name == name) ?? new Section(name); }
        }

        public IEnumerator<ISection> GetEnumerator()
        {
            return _sections.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool AddSection(ISection section)
        {
            return _sections.Add(section);
        }
    }
}