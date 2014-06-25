using NUnit.Framework;
using Shouldly;
using Zenini.Core.Patterns;

namespace Zenini.Tests.Patterns.Section
{
    [TestFixture]
    public class Extracting_a_section_from_a_string
    {
        [SetUp]
        public void Setup()
        {
            Pattern = new SectionPattern();
        }

        public SectionPattern Pattern { get; set; }

        [Test]
        public void returns_empty_string_if_section_is_empty()
        {
            Pattern.Extract("[]").ShouldBeEmpty();
        }

        [Test]
        public void returns_null_if_it_does_not_match()
        {
            Pattern.Extract("This is no section]").ShouldBe(null);
        }

        [Test]
        public void returns_the_section()
        {
            Pattern.Extract("[SectionA]").ShouldBe("SectionA");
        }

        [Test]
        public void returns_the_section_with_no_leading_spaces()
        {
            Pattern.Extract("[ SectionA]").ShouldBe("SectionA");
        }

        [Test]
        public void returns_the_section_with_no_trailing_spaces()
        {
            Pattern.Extract("[SectionA ]").ShouldBe("SectionA");
        }
    }
}