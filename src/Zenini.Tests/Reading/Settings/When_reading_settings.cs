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
        public void it_returns_the_value()
        {
            IIniSettings settings = ReadFromSource();

            settings["Section"].Get("Enable").ShouldBe("true");
        }
    }
}