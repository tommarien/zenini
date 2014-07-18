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
        public FakeSettingsReader reader { get; set; }
        public IniSettingsProvider Provider { get; set; }

        [SetUp]
        public void Setup()
        {
            reader = new FakeSettingsReader
            {
                SettingsToReturn = Substitute.For<IIniSettings>()
            };

            Provider = new IniSettingsProvider(reader);
        }

        [Test]
        public void returns_expected_settings()
        {
            Provider.FromFile(TestFile.Named("Empty.ini")).ShouldBeSameAs(reader.SettingsToReturn);
        }

        [Test]
        public void auto_detects_file_encoding()
        {
            Provider.FromFile(TestFile.Named("Empty.ini"));

            reader.UsedEncoding.ShouldBe(Encoding.UTF8);
        }
    }
}