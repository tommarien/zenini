using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading.Settings
{
    [TestFixture]
    public class When_reading_settings_enclosed_in_quotation_marks : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
        }

        [Test]
        public void it_reads_the_setting_removing_the_quotation_marks()
        {
            Source.AppendLine("key=\"value\"");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("key").ShouldBe("value");
        }

        [Test]
        public void it_preserves_leading_spaces()
        {
            Source.AppendLine("key=\" value\"");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("key").ShouldBe(" value");
        }

        [Test]
        public void it_preserves_trailing_spaces()
        {
            Source.AppendLine("key=\"value \"");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("key").ShouldBe("value ");
        }

        [Test]
        public void it_reads_the_setting_with_an_equals_symbol()
        {
            Source.AppendLine("key=\"value=\"");

            IIniSettings settings = ReadFromSource();

            settings["Section"].GetSetting("key").ShouldBe("value=");
        }
    }
}