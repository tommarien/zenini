using System.Collections.Generic;
using NUnit.Framework;
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
            Section = new Section("A given section", new Dictionary<string, string>());
        }

        public Section Section { get; set; }

        [Test]
        public void has_a_name()
        {
            Section.Name.ShouldBe("A given section");
        }

        [Test]
        public void has_a_readable_toString_representation()
        {
            Section.ToString().ShouldBe("Section: A given section");
        }
    }
}