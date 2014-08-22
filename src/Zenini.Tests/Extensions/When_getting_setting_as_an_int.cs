using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Extensions
{
    [TestFixture]
    public class When_getting_setting_as_an_int
    {
        [SetUp]
        public void Setup()
        {
            _values = new Dictionary<string, string>();

            Section = new Section("A Section", _values);
        }

        private Dictionary<string, string> _values;

        public ISection Section { get; set; }


        [Test]
        public void it_returns_a_negative_value()
        {
            _values.Add("Interval", "-1");

            Section.GetValueAsInt("Interval").ShouldBe(-1);
        }

        [Test]
        public void it_returns_a_positive_value()
        {
            _values.Add("Interval", "1");

            Section.GetValueAsInt("Interval").ShouldBe(1);
        }

        [Test]
        public void it_returns_null_if_value_does_not_exist()
        {
            Section.GetValueAsInt("Interval").ShouldBe(null);
        }

        [Test]
        public void it_throws_formatexception_if_value_is_not_an_integer()
        {
            _values.Add("Interval", "test");

            var exception = Should.Throw<FormatException>(() => Section.GetValueAsInt("Interval"));
            exception.Message.ShouldBe("Input string was not in a correct format.");
        }
    }
}