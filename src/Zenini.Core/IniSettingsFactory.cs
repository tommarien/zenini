using System.Collections.Generic;
using System.IO;
using System.Text;
using Zenini.Core.Patterns;
using Zenini.Model;

namespace Zenini
{
    public class IniSettingsFactory
    {
        private readonly SectionPattern _sectionPattern = new SectionPattern();

        public IIniSettings FromFile(string fileName)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                return FromStream(fs);
            }
        }

        public IIniSettings FromStream(Stream stream)
        {
            return FromStream(stream, null);
        }

        public IIniSettings FromStream(Stream stream, Encoding encoding)
        {
            StreamReader reader = encoding == null ? new StreamReader(stream, true) : new StreamReader(stream, encoding);

            var sections = new HashSet<ISection>();

            try
            {
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();

                    if (_sectionPattern.Matches(line))
                    {
                        sections.Add(new Section(_sectionPattern.Extract(line)));
                    }
                }
            }
            finally
            {
                reader.Dispose();
            }

            return new IniSettings(sections);
        }
    }
}