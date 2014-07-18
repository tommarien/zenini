using System.Text;
using NSubstitute;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;
using Zenini.Tests.TestFiles;

namespace Zenini.Tests.Provider
{
    [TestFixture]
    public class Providing_settings_from_file_specifying_encoding
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
            Provider.FromFile(TestFile.Named("Empty.ini"), Encoding.UTF8).ShouldBeSameAs(reader.SettingsToReturn);
        }

        [Test]
        public void reads_file_using_specified_encoding()
        {
            Provider.FromFile(TestFile.Named("Empty.ini"), Encoding.UTF7);

            reader.UsedEncoding.ShouldBe(Encoding.UTF7);
        }
    }
}