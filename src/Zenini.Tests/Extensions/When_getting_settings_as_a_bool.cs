using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shouldly;
using Zenini.Model;

namespace Zenini.Tests.Extensions
{
    [TestFixture]
    public class When_getting_settings_as_a_bool
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
        public void it_returns_false_if_value_is_0()
        {
            _values.Add("enable", "0");

            Section.GetValueAsBool("enable").ShouldBe(false);
        }

        [Test]
        public void it_returns_false_if_value_is_False()
        {
            _values.Add("enable", "False");

            Section.GetValueAsBool("enable").ShouldBe(false);
        }

        [Test]
        public void it_returns_false_if_value_is_false()
        {
            _values.Add("enable", "false");

            Section.GetValueAsBool("enable").ShouldBe(false);
        }

        [Test]
        public void it_returns_true_if_value_is_1()
        {
            _values.Add("enable", "1");

            Section.GetValueAsBool("enable").ShouldBe(true);
        }

        [Test]
        public void it_returns_true_if_value_is_True()
        {
            _values.Add("enable", "True");

            Section.GetValueAsBool("enable").ShouldBe(true);
        }

        [Test]
        public void it_returns_true_if_value_is_true()
        {
            _values.Add("enable", "true");

            Section.GetValueAsBool("enable").ShouldBe(true);
        }

        [Test]
        public void it_throws_formatexception_if_value_is_not_a_boolean()
        {
            _values.Add("enable", "test");

            var exception = Should.Throw<FormatException>(() => Section.GetValueAsBool("enable"));
            exception.Message.ShouldBe("String was not recognized as a valid Boolean.");
        }
    }
}