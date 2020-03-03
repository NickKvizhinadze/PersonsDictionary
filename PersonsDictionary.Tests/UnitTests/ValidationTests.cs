using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
using PersonsDictionary.Common.Extensions;
using FluentAssertions;

namespace PersonsDictionary.Tests.UnitTests
{
    public class ValidationTests
    {
        #region Tests
        [Fact]
        public void Only_English_Letters_Should_Return_True()
        {
            string name = "nick";
            var result = name.IsWithEnglishLetters();
            result.Should().BeTrue();
        }

        [Fact]
        public void English_Letters_With_Georgian_Should_Return_False()
        {
            string name = "nickა";
            var result = name.IsWithEnglishLetters();
            result.Should().BeFalse();
        }

        [Fact]
        public void Only_Georgian_Letters_Should_Return_True()
        {
            string name = "ნიკა";
            var result = name.IsWithGeorgianLetters();
            result.Should().BeTrue();
        }

        [Fact]
        public void Georgian_Letters_With_English_Should_Return_False()
        {
            string name = "ნიკაn";
            var result = name.IsWithGeorgianLetters();
            result.Should().BeFalse();
        }
        #endregion
    }
}
