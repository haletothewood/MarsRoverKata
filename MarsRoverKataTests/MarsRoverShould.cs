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
        [TestCase("L", "W")]
        [TestCase("LL", "S")]
        [TestCase("LLL", "E")]
        [TestCase("LLLL", "N")]
        public void TurnLeft(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }

        [TestCase("R", "E")]
        [TestCase("RR", "S")]
        [TestCase("RRR", "W")]
        [TestCase("RRRR", "N")]
        public void TurnRight(string input, string output)
        {
            MarsRover marsRover = new MarsRover();
            marsRover.Execute(input).ShouldBe(output);
        }
    }
}
