using System.Collections.Generic;
using MarsRoverKata;
using NUnit.Framework;
using Shouldly;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverShould
    {
        private MarsRover _marsRover;
        [SetUp]
        public void InitializeTests()
        {
            var grid = new Grid(10,10);
            _marsRover = new MarsRover(grid);
        }

        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        public void TurnLeft(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void TurnRight(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("M", "1:0:N")]
        [TestCase("MM", "2:0:N")]
        [TestCase("MMM", "3:0:N")]
        [TestCase("MMMM", "4:0:N")]
        public void Move(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("MRM", "1:1:E")]
        [TestCase("MRMLM", "2:1:N")]
        [TestCase("MRRMLM", "0:1:E")]
        [TestCase("MMMMMMRMMLMM", "8:2:N")]
        [TestCase("MRLRLLLMLMMMMMMMLL", "0:7:W")]
        public void MoveInTheRightDirection(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("MMMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMMMMMMMMMMMMM", "0:0:N")]
        public void WrapAroundIfMovingPastMaxHeight(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("RRM", "10:0:S")]
        [TestCase("RRMMMMMMMMMMMM", "10:0:S")]
        public void WrapAroundIfMovingBelowMaxHeight(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("RMMMMMMMMMMM", "0:0:E")]
        [TestCase("RMMMMMMMMMMMMMMMMMMMMMM", "0:0:E")]
        public void WrapAroundIfMovingEastBeyondWidth(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("LM", "0:10:W")]
        [TestCase("LMMMMMMMMMMMM", "0:10:W")]
        public void WrapAroundIfMovingWestBeyondWidth(string input, string output)
        {
            _marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("MRMMMM", 1, 1, "O:1:0:E")]
        [TestCase("MMMMRLLMRMMM", 6, 10, "O:5:10:N")]
        public void ReportAnObstacleIfEncountered(string input, int x, int y, string output)
        {
            var obstacles = new List<Coordinate> {new Coordinate(x, y), new Coordinate(10, 10)};
            var grid = new Grid(10, 10, obstacles);
            var marsRover = new MarsRover(grid);
            marsRover.Execute(input).ShouldBe(output);
        }

        [Test]
        public void DontReportAnObstacleIfNotEncountered()
        {
            var obstacles = new List<Coordinate> {new Coordinate(1, 1)};
            var grid = new Grid(10, 10, obstacles);
            var marsRover = new MarsRover(grid);
            marsRover.Execute("MMMMRMMLMM").ShouldNotStartWith("O:");
        }
    }
}
