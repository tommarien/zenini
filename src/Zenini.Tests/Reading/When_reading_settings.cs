using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading
{
    [TestFixture]
    public class When_reading_settings : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[Section]");
        }

        [Test]
        public void it_ignores_commented_settings()
        {
            Source.AppendLine(";test=value");

            IIniSettings settings = ReadFromSource();
            ISection section = settings["Section"];

            section.ShouldBeEmpty();
        }

        [Test]
        public void it_ignores_leading_whitespace_on_value()
        {
            Source.AppendLine("test=  value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_leading_whitespaces_on_key()
        {
            Source.AppendLine("  test=value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_trailing_whitespace_on_value()
        {
            Source.AppendLine("test=value  ");

            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("test").ShouldBe("value");
        }

        [Test]
        public void it_ignores_trailing_whitespaces_on_key()
        {
            Source.AppendLine("test   =value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("test").ShouldBe("value");
        }

        [Test]
        public void it_reads_the_setting()
        {
            Source.AppendLine("test=value");

            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("test").ShouldBe("value");
        }
    }
}