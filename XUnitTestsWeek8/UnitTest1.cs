using System;
using Week8Project.Data;
using Week8Project.Controllers;
using Week8Project.Models;
using Xunit;

namespace XUnitTestsWeek8
{
    public class UnitTest1
    {

        private readonly PokemonDbContext _context;

        [Fact]
        public void TestGetSpecies()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
            testMon.Species = "Pikachu";
            //Act
            string testString = testMon.Species;

            //Assert
            Assert.Equal(testMon.Species, "Pikachu");

        }

        [Fact]
        public void TestGetType()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
            testMon.Type = "Grass";
            //Act
            string testString = testMon.Type;

            //Assert
            Assert.Equal(testMon.Type, "Grass");

        }

        [Fact]
        public void TestSetSpecies()
        {
            //Arrange
            Pokemon testMon = new Pokemon();

            //Act
            testMon.Species = "Pikachu";

            //Assert
            Assert.Equal(testMon.Species, "Pikachu");

        }

        [Fact]
        public void TestSetType()
        {
            //Arrange
            Pokemon testMon = new Pokemon();
       
            //Act
            testMon.Type = "Grass";

            //Assert
            Assert.Equal(testMon.Type, "Grass");

        }
    }
}
