using System;

namespace Zenini.Model
{
    public class Section : ISection
    {
        private readonly string _name;

        public Section(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        public override string ToString()
        {
            return Name;
        }
    }
}