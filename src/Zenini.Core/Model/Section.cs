﻿using System;

namespace Zenini.Model
{
    public class Section : ISection
    {
        public Section(string name)
        {
            if (name == null) throw new ArgumentNullException("name");

            Name = name;
        }

        public string Name { get; private set; }

        public override string ToString()
        {
            return string.Format("{0}: {1}", GetType().Name, Name);
        }
    }
}