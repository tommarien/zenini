﻿using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Model.Sections
{
    [TestFixture]
    public class A_section
    {
        [SetUp]
        public void Setup()
        {
            Section = new Section("A given section");
        }

        public Section Section { get; set; }

        [Test]
        public void retains_its_name()
        {
            Section.Name.ShouldBe("A given section");
        }
    }
}