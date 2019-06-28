using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MarsRoverKata;
using NUnit.Framework;
using Shouldly;

namespace MarsRoverKataTests
{
    [TestFixture]
    public class MarsRoverShould
    {
        [TestCase("L", "0:0:W")]
        [TestCase("LL", "0:0:S")]
        [TestCase("LLL", "0:0:E")]
        [TestCase("LLLL", "0:0:N")]
        public void TurnLeft(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("R", "0:0:E")]
        [TestCase("RR", "0:0:S")]
        [TestCase("RRR", "0:0:W")]
        [TestCase("RRRR", "0:0:N")]
        public void TurnRight(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("M", "1:0:N")]
        [TestCase("MM", "2:0:N")]
        [TestCase("MMM", "3:0:N")]
        [TestCase("MMMM", "4:0:N")]
        public void Move(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("MRM", "1:1:E")]
        [TestCase("MRMLM", "2:1:N")]
        [TestCase("MRRMLM", "0:1:E")]
        [TestCase("MMMMMMRMMLMM", "8:2:N")]
        [TestCase("MRLRLLLMLMMMMMMMLL", "0:7:W")]
        public void MoveInTheRightDirection(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("MMMMMMMMMMM", "0:0:N")]
        [TestCase("MMMMMMMMMMMMMMMMMMMMMM", "0:0:N")]
        public void WrapAroundIfMovingPastMaxHeight(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("RRM", "10:0:S")]
        [TestCase("RRMMMMMMMMMMMM", "10:0:S")]
        public void WrapAroundIfMovingBelowMaxHeight(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("RMMMMMMMMMMM", "0:0:E")]
        [TestCase("RMMMMMMMMMMMMMMMMMMMMMM", "0:0:E")]
        public void WrapAroundIfMovingEastBeyondWidth(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("LM", "0:10:W")]
        [TestCase("LMMMMMMMMMMMM", "0:10:W")]
        public void WrapAroundIfMovingWestBeyondWidth(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }
    }
}
