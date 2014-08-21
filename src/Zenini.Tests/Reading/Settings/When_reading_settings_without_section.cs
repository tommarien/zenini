using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading.Settings
{
    [TestFixture]
    public class When_reading_settings_without_section : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("key1=value1");
            Source.AppendLine("key2=value2");
        }

        [Test]
        public void it_correctly_adds_the_settings_under_the_default_section_name()
        {
            IIniSettings settings = ReadFromSource();

            ISection defaultSection = settings[string.Empty];

            defaultSection.Count().ShouldBe(2);
        }
    }
}