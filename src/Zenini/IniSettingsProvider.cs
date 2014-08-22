using System.IO;
using System.Text;

namespace Zenini
{
    public class IniSettingsProvider
    {
        private readonly ISettingsReader _settingsReader;

        public IniSettingsProvider(ISettingsReader settingsReader)
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

        public IIniSettings FromFile(string fileName, Encoding encoding)
        {
            using (FileStream fs = File.OpenRead(fileName))
            {
                return FromStream(fs, encoding);
            }
        }

        public IIniSettings FromStream(Stream stream)
        {
            using (var sr = new StreamReader(stream, true))
            {
                return _settingsReader.Read(sr);
            }
        }

        public IIniSettings FromStream(Stream stream, Encoding encoding)
        {
            using (var sr = new StreamReader(stream, encoding, false))
            {
                return _settingsReader.Read(sr);
            }
        }
    }
}