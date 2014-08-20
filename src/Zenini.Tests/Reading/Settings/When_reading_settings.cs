using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading.Settings
{
    public class When_reading_settings : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
            Source.AppendLine("Enable=true");
        }

        [Test]
        public void it_reads_the_setting()
        {
            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("Enable").ShouldBe("true");
        }

        [Test]
        public void it_ignores_leading_whitespaces_on_key()
        {
            Source.AppendLine("  Test=value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("Test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_trailing_whitespaces_on_key()
        {
            Source.AppendLine("Test   =value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("Test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_leading_whitespace_on_value()
        {
            Source.AppendLine("Test=  value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("Test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_trailing_whitespace_on_value()
        {
            Source.AppendLine("Test=value  ");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("Test").ShouldBe("value");
        }
    }
}