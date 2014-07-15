using System.IO;
using Zenini.Core.Patterns;
using Zenini.Model;

namespace Zenini.Readers
{
    public class CaseSensitiveSettingsReader : ISettingsReader
    {
        private readonly SectionPattern _sectionPattern = new SectionPattern();

        public IIniSettings Read(TextReader reader)
        {
            var settings = new IniSettings();

            string line;
            while ((line = reader.ReadLine()) != null)
            {
                if (_sectionPattern.Matches(line))
                {
                    var section = new Section(_sectionPattern.Extract(line));

                    settings.AddSection(section);
                }
            }


            return settings;
        }
    }
}