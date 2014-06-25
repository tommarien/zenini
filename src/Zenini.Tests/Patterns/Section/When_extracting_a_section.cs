using NUnit.Framework;
using Shouldly;

namespace Zenini.Core.Patterns.Section
{
    [TestFixture]
    public class When_extracting_a_section
    {
        [SetUp]
        public void Setup()
        {
            Pattern = new SectionPattern();
        }

        public SectionPattern Pattern { get; set; }

        [Test]
        public void it_returns_null_if_it_does_not_match()
        {
            Pattern.Extract("This is no section]").ShouldBe(null);
        }

        [Test]
        public void it_returns_the_section()
        {
            Pattern.Extract("[SectionA]").ShouldBe("SectionA");
        }

        [Test]
        public void it_returns_the_section_with_no_leading_spaces()
        {
            Pattern.Extract("[ SectionA]").ShouldBe("SectionA");
        }

        [Test]
        public void it_returns_the_section_with_no_trailing_spaces()
        {
            Pattern.Extract("[SectionA ]").ShouldBe("SectionA");
        }

        [Test]
        public void it_returns_empty_string_if_section_is_empty()
        {
            Pattern.Extract("[]").ShouldBeEmpty();
        }
    }
}