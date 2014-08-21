using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading.Settings
{
    [TestFixture]
    public class When_reading_settings_of_reoccurring_section : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
            Source.AppendLine("key1=value1");
            Source.AppendLine("[Section]");
            Source.AppendLine("key2=value2");
        }

        [Test]
        public void they_complement_eachother()
        {
            IIniSettings settings = ReadFromSource();
            settings["Section"].Select(s => s.Key).ShouldBe(new[] {"key1", "key2"});
        }
    }
}