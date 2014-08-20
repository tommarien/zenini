﻿using System.Collections.Generic;

namespace Zenini
{
    public interface ISection : IEnumerable<KeyValuePair<string, string>>
    {
        string Name { get; }
        string Get(string key);
    }
}