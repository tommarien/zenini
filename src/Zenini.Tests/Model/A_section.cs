using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Model
{
    [TestFixture]
    public class A_section
    {
        [SetUp]
        public void Setup()
        {
            Section = new Section("A given section", new Dictionary<string, string>());
            Section.Set("name", "value");
            Section.Set("other", "valuey");
        }

        public Section Section { get; set; }

        [Test]
        public void has_a_get_method_that_retrieves_a_setting()
        {
            Section.Get("name").ShouldBe("value");
        }

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

        [Test]
        public void is_a_container_of_settings()
        {
            Section.Count().ShouldBe(2);
        }
    }
}