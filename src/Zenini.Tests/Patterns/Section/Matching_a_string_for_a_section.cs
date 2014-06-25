using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Zenini.Core.Patterns;

namespace Zenini.Tests.Patterns.Section
{
    [TestFixture]
    public class Matching_a_string_for_a_section
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
        public void returns_true_for(string line)
        {
            Pattern.Matches(line).ShouldBe(true);
        }
    }
}