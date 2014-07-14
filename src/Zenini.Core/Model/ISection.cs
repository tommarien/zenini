using System;
using System.Collections.Generic;

namespace Zenini.Model
{
    public interface ISection : IEquatable<ISection>, IEnumerable<KeyValuePair<string, string>>
    {
        bool IsEmpty { get; }
        string Name { get; }

        string GetValue(string key);
    }
}