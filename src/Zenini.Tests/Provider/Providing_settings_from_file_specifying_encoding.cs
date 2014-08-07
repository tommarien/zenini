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
        [SetUp]
        public void Setup()
        {
            Reader = new FakeSettingsReader
                {
                    SettingsToReturn = Substitute.For<IIniSettings>()
                };

            Provider = new IniSettingsProvider(Reader);
        }

        public FakeSettingsReader Reader { get; set; }
        public IniSettingsProvider Provider { get; set; }

        [Test]
        public void reads_file_using_specified_encoding()
        {
            Provider.FromFile(TestFile.Named("Empty_utf8.ini"), Encoding.UTF7);

            Reader.UsedEncoding.ShouldBe(Encoding.UTF7);
        }

        [Test]
        public void returns_expected_settings()
        {
            Provider.FromFile(TestFile.Named("Empty_utf8.ini"), Encoding.UTF8).ShouldBeSameAs(Reader.SettingsToReturn);
        }
    }
}