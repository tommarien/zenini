using System.Text;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;
using Zenini.Tests.TestFiles;

namespace Zenini.Tests.Provider
{
    [TestFixture]
    public class Providing_settings_from_file
    {
        [SetUp]
        public void Setup()
        {
            reader = new FakeSettingsReader
                {
                    SettingsToReturn = Substitute.For<IIniSettings>()
                };

            Provider = new IniSettingsProvider(reader);
        }

        public FakeSettingsReader reader { get; set; }
        public IniSettingsProvider Provider { get; set; }

        [Test]
        public void auto_detects_file_encoding_utf16()
        {
            Provider.FromFile(TestFile.Named("Empty_utf16.ini"));

            reader.UsedEncoding.ShouldBe(Encoding.Unicode);
        }

        [Test]
        public void auto_detects_file_encoding_utf8()
        {
            Provider.FromFile(TestFile.Named("Empty_utf8.ini"));

            reader.UsedEncoding.ShouldBe(Encoding.UTF8);
        }

        [Test]
        public void returns_expected_settings()
        {
            Provider.FromFile(TestFile.Named("Empty_utf8.ini")).ShouldBeSameAs(reader.SettingsToReturn);
        }
    }
}