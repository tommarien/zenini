using System.Collections.Generic;

namespace Zenini.Model
{
    public interface IIniSettings : IEnumerable<ISection>
    {
        ISection this[string name] { get; }
    }
}