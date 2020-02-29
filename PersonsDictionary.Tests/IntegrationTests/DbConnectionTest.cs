using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using PersonsDictionary.Persistence;

namespace PersonsDictionary.Tests.Integration
{
    public class DbConnectionTest
    {
        #region Constants
        private const string ConnectionString = @"Server=KVIZHINADZE;Database=PersonsDictionary;Trusted_Connection=True;";
        #endregion

        #region Tests
        [Fact]
        public void Can_Connect_To_Db()
        {
            Action action = () =>
            {
                using (var context = new ApplicationDbContext(ConnectionString))
                {
                    var persons = context.Persons.ToList();
                }
            };

            action.Should().NotThrow();            
        }

        #endregion
    }
}
