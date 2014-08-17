using System.Collections.Generic;

namespace Zenini
{
    public interface IIniSettings : IEnumerable<ISection>
    {
        ISection this[string name] { get; }
    }
}