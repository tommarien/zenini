using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Model
{
    [TestFixture]
    public class An_IniSettings_instance
    {
        [SetUp]
        public void Setup()
        {
            sectionOne = new Section("SectionOne", new Dictionary<string, string>());
            sectionTwo = new Section("SectionTwo", new Dictionary<string, string>());

            var dictionary = new Dictionary<string, ISection>();
            dictionary.Add(sectionOne.Name, sectionOne);
            dictionary.Add(sectionTwo.Name, sectionTwo);

            settings = new IniSettings(dictionary);
        }

        private ISection sectionOne;
        private ISection sectionTwo;

        private IIniSettings settings;

        [Test]
        public void has_an_indexer_that_returns_a_section()
        {
            settings["SectionOne"].ShouldBeSameAs(sectionOne);
        }

        [Test]
        public void has_an_indexer_that_returns_an_empty_section_if_none_match()
        {
            settings["sectionthree"].ShouldBeSameAs(Section.Empty);
        }

        [Test]
        public void is_a_container_of_sections()
        {
            settings.Count().ShouldBe(2);
        }
    }
}