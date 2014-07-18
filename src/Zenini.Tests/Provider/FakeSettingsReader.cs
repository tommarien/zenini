using System.IO;
using System.Text;
using Zenini.Model;

namespace Zenini.Tests.Provider
{
    public class FakeSettingsReader : ISettingsReader
    {
        public Encoding UsedEncoding { get; set; }
        public IIniSettings SettingsToReturn { get; set; }

        public IIniSettings Read(TextReader reader)
        {
            StreamReader sr = (StreamReader) reader;
            if (sr != null)
            {
                UsedEncoding = sr.CurrentEncoding;
            }

            return SettingsToReturn;
        }
    }
}