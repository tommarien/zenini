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
            sectionOne = new Section("SectionOne");
            sectionTwo = new Section("SectionTwo");

            settings = new IniSettings(new[] {sectionOne, sectionTwo});
        }

        private ISection sectionOne;
        private ISection sectionTwo;

        private IIniSettings settings;

        [Test]
        public void has_an_indexer_that_ignores_string_casing()
        {
            settings["Sectionone"].ShouldBeSameAs(sectionOne);
        }

        [Test]
        public void has_an_indexer_that_returns_an_empty_section_if_none_match()
        {
            settings["sectionthree"].ShouldBeSameAs(Section.Empty);
        }

        [Test]
        public void has_an_indexer_to_return_a_section()
        {
            settings["SectionOne"].ShouldBeSameAs(sectionOne);
        }

        [Test]
        public void is_a_container_of_settings()
        {
            settings.Count().ShouldBe(2);
        }
    }
}