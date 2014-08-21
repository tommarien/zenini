using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading.Settings
{
    [TestFixture]
    public class When_reading_settings_that_occur_more_then_once : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
            Source.AppendLine("key1=value1");
            Source.AppendLine("key1=value2");
        }

        [Test]
        public void the_last_value_wins()
        {
            IIniSettings settings = ReadFromSource();
            settings["Section"].GetSetting("key1").ShouldBe("value2");
        }
    }
}