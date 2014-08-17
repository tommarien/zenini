using System.IO;

namespace Zenini
{
    public interface ISettingsReader
    {
        IIniSettings Read(TextReader reader);
    }
}