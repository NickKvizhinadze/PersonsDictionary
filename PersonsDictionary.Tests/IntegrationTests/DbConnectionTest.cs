using System;
using System.Linq;
using Xunit;
using FluentAssertions;
using PersonsDictionary.Persistence;
using PersonsDictionary.Domain.Persons;

namespace PersonsDictionary.Tests.Integration
{
    public class DbConnectionTest
    {
        #region Constants
        private const string ConnectionString = @"Server=den1.mssql8.gear.host;Database=personsdict;User Id=personsdict;Password=Bb4G73u6_vG~;";
        #endregion

        #region Tests
        [Fact]
        public void Can_Connect_To_Db()
        {
            Action action = () =>
            {
                using (var context = new ApplicationDbContext(ConnectionString))
                {
                    var dbSet = context.Set<Person>();
                    var persons = dbSet.ToList();
                }
            };

            action.Should().NotThrow();            
        }

        #endregion
    }
}
