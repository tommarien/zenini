using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zenini.Core.Patterns;
using Zenini.Model;

namespace Zenini.Readers
{
    public class DefaultSettingsReader : ISettingsReader
    {
        private readonly SectionPattern _sectionPattern = new SectionPattern();
        private readonly StringComparer _stringComparer;

        public DefaultSettingsReader()
            : this(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DefaultSettingsReader(StringComparer stringComparer)
        {
            _stringComparer = stringComparer;
        }

        public IIniSettings Read(TextReader reader)
        {
            var sections = new Dictionary<string, Section>(_stringComparer);

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (_sectionPattern.Matches(line))
                {
                    var section = new Section(_sectionPattern.Extract(line));

                    if (!sections.ContainsKey(section.Name))
                        sections.Add(section.Name, section);
                }
            }

            return new IniSettings(sections.ToDictionary(pair => pair.Key, pair => (ISection) pair.Value));
        }
    }
}