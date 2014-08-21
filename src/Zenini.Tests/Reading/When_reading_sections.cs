using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Reading
{
    [TestFixture]
    public class When_reading_sections : SettingsReaderFixture
    {
        [Test]
        public void it_extracts_the_section_name()
        {
            Source.AppendLine("[SectionOne]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "SectionOne");
        }

        [Test]
        public void it_extracts_the_section_name_with_spaces()
        {
            Source.AppendLine("[Section One]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "Section One");
        }

        [Test]
        public void it_handles_empty_sections()
        {
            Source.AppendLine("[]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == string.Empty);
        }

        [Test]
        public void it_handles_nested_brackets()
        {
            Source.AppendLine("[[Special]Section]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "[Special]Section");
        }

        [Test]
        public void it_ignores_casing_on_indexer()
        {
            Source.AppendLine("[SectionOne]");

            IIniSettings settings = ReadFromSource();

            settings["sectionone"].ShouldNotBeSameAs(Section.Empty);
        }

        [Test]
        public void it_ignores_commented_sections()
        {
            Source.AppendLine(";[SectionThree]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldNotContain(section => section.Name == "SectionThree");
        }

        [Test]
        public void it_ignores_trailing_spaces_after_bracket()
        {
            Source.AppendLine("[SectionThree]      ");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "SectionThree");
        }

        [Test]
        public void it_trims_leading_spaces_within_brackets()
        {
            Source.AppendLine("[ SectionTwo]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "SectionTwo");
        }

        [Test]
        public void it_trims_trailing_spaces_within_brackets()
        {
            Source.AppendLine("[SectionThree ]");

            IIniSettings settings = ReadFromSource();

            settings.ShouldContain(section => section.Name == "SectionThree");
        }
    }
}