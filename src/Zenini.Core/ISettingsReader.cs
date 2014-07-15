using System.IO;
using Zenini.Model;

namespace Zenini
{
    public interface ISettingsReader
    {
        IIniSettings Read(TextReader reader);
    }
}