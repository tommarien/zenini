using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Zenini.Model
{
    public class Section : ISection
    {
        private readonly Dictionary<string, string> _values = new Dictionary<string, string>();

        public Section(string name)
            : this(name, null)
        {
        }

        public Section(string name, IDictionary<string, string> values)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;

            if (values != null)
                _values = new Dictionary<string, string>(values);
        }

        public bool IsEmpty
        {
            get { return !this.Any(); }
        }

        public string Name { get; private set; }

        public string GetValue(string key)
        {
            return _values[key];
        }

        public bool Equals(ISection other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return string.Equals(Name, other.Name);
        }

        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return _values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            var other = obj as ISection;
            return other != null && Equals(other);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}