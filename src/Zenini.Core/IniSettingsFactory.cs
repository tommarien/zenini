using System.IO;
using System.Text;
using Zenini.Model;
using Zenini.Readers;

namespace Zenini
{
    public class IniSettingsFactory
    {
        private readonly ISettingsReader _settingsReader;

        public IniSettingsFactory()
            : this(new CaseSensitiveSettingsReader())
        {
        }

        public IniSettingsFactory(ISettingsReader settingsReader)
        {
            _settingsReader = settingsReader;
        }

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

            try
            {
                return _settingsReader.Read(reader);
            }
            finally
            {
                reader.Dispose();
            }
        }
    }
}