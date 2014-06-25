using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;

namespace Zenini.Core.Patterns.Section
{
    [TestFixture]
    public class When_matching_a_string_for_a_section
    {
        [SetUp]
        public void Setup()
        {
            Pattern = new SectionPattern();
        }

        public SectionPattern Pattern { get; set; }

        public IEnumerable<string> TestValues
        {
            get
            {
                yield return "[SectionA]";
                yield return "[A Section]";
                yield return "[ A Section]";
                yield return "[A Section ]";
                yield return "[A [special] section]";
            }
        }

        [Test]
        [TestCaseSource("TestValues")]
        public void it_matches_string(string line)
        {
            Pattern.Matches(line).ShouldBe(true);
        }
    }
}