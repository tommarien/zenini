using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading
{
    [TestFixture]
    public class When_reading_settings_that_occur_more_then_once_with_different_casing : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
            Source.AppendLine("key1=value1");
            Source.AppendLine("Key1=value2");
        }

        [Test]
        public void casing_is_ignored_and_the_last_value_wins()
        {
            IIniSettings settings = ReadFromSource();
            settings["Section"].Get("key1").ShouldBe("value2");
        }
    }
}