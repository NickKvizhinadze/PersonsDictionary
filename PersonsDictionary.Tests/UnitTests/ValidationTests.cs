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
        [Theory]
        [InlineData("nick", true)]
        [InlineData("nickა", false)]
        [InlineData("nick1", false)]
        public void Only_English_Letters_Should_Return_True(string name, bool result)
        {
            var checkResult = name.IsWithEnglishLetters();
            result.Should().Be(checkResult);
        }

        [Theory]
        [InlineData("ნიკა", true)]
        [InlineData("ნიკაn", false)]
        [InlineData("ნიკა1", false)]
        public void Only_Georgian_Letters_Should_Return_True(string name, bool result)
        {
            var checkResult = name.IsWithGeorgianLetters();
            result.Should().Be(checkResult);
        }
        #endregion
    }
}
