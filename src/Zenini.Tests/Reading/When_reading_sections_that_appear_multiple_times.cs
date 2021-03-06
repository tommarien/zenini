﻿using System.Linq;
using NUnit.Framework;
using Shouldly;

namespace Zenini.Tests.Reading
{
    [TestFixture]
    public class When_reading_sections_that_appear_multiple_times : SettingsReaderFixture
    {
        protected override void AfterSetup()
        {
            Source.AppendLine("[SectionOne]");
            Source.AppendLine("[SectionTwo]");
            Source.AppendLine("[SectionOne]");
        }

        [Test]
        public void it_merges_the_sections()
        {
            IIniSettings settings = ReadFromSource();

            settings.Count(s => s.Name == "SectionOne").ShouldBe(1);
        }
    }
}