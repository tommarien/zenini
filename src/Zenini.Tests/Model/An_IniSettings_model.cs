using System.Linq;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Model
{
    [TestFixture]
    public class An_IniSettings_model
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