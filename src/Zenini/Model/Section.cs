﻿using System.Collections;
using System.Collections.Generic;

namespace Zenini.Model
{
    public class Section : ISection
    {
        public const string DefaultSectionName = "";

        public static readonly ISection Empty = new NullSection();
        private readonly IDictionary<string, string> _values;

        public Section(string name, IDictionary<string, string> values)
        {
            Name = name ?? DefaultSectionName;
            _values = values;
        }

        public string Name { get; private set; }

        public string GetValue(string key)
        {
            string value;
            _values.TryGetValue(key, out value);
            return value;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Set(string key, string value)
        {
            _values[key] = value;
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetType().Name, Name);
        }
    }

    internal class NullSection : ISection
    {
        public string Name
        {
            get { return "#Empty#"; }
        }

        public string GetValue(string key)
        {
            return null;
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            yield break;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetType().Name, Name);
        }
    }
}