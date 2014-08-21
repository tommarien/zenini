using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Zenini.Model;
using Zenini.Patterns;

namespace Zenini.Readers
{
    public class DefaultSettingsReader : ISettingsReader
    {
        private readonly KeyValuePattern _keyValuePattern = new KeyValuePattern();
        private readonly SectionPattern _sectionPattern = new SectionPattern();

        private readonly StringComparer _stringComparer;

        public DefaultSettingsReader()
            : this(StringComparer.OrdinalIgnoreCase)
        {
        }

        public DefaultSettingsReader(StringComparer stringComparer)
            : this(stringComparer, new SectionPattern(), new KeyValuePattern())
        {
        }

        public DefaultSettingsReader(StringComparer stringComparer, SectionPattern sectionPattern, KeyValuePattern keyValuePattern)
        {
            _stringComparer = stringComparer;
            _sectionPattern = sectionPattern;
            _keyValuePattern = keyValuePattern;
        }

        public IIniSettings Read(TextReader reader)
        {
            var sections = new Dictionary<string, Section>(_stringComparer);

            string line;
            var section = new Section(string.Empty, new Dictionary<string, string>(_stringComparer));

            while ((line = reader.ReadLine()) != null)
            {
                if (_sectionPattern.Matches(line))
                {
                    string sectionName = _sectionPattern.Extract(line);

                    if (!sections.ContainsKey(sectionName))
                        sections.Add(sectionName, new Section(sectionName, new Dictionary<string, string>(_stringComparer)));

                    section = sections[sectionName];
                }
                else if (_keyValuePattern.Matches(line))
                {
                    if (section.Name == Section.DefaultSectionName && !sections.ContainsKey(section.Name))
                        sections.Add(section.Name, section);

                    Tuple<string, string> keyValue = _keyValuePattern.Extract(line);
                    section.Set(keyValue.Item1, keyValue.Item2);
                }
            }

            return new IniSettings(sections.ToDictionary(pair => pair.Key, pair => (ISection) pair.Value));
        }
    }
}