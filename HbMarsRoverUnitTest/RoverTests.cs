using System;
using FluentAssertions;
using HbMarsRover;
using HbMarsRover.Enums;
using Xunit;

namespace HbMarsRoverUnitTest
{
    public class RoverTests
    {
        [Fact]
        public void Should_Success_Rover_Launch()
        {
            var rover = new Rover();

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            rover.LaunchRover(plateau, "1 2 N");

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.N);
        }

        [Fact]
        public void Should_Success_Rover_Turn_Left()
        {
            var rover = new Rover();
            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            rover.LaunchRover(plateau, "1 2 N");
            rover.TurnLeft();

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.W);
        }

        [Fact]
        public void Should_Success_Rover_Turn_Right()
        {
            var rover = new Rover();

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            rover.LaunchRover(plateau, "1 2 N");
            rover.TurnRight();

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.E);
        }

        [Fact]
        public void Should_Success_Rover_Move_Forward()
        {
            var rover = new Rover();

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            rover.LaunchRover(plateau, "1 2 N");
            rover.MoveForward(plateau);

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(3);
            rover.Direction.Should().Be(Direction.N);
        }

        [Theory]
        [InlineData("1 2 N", "LMLMLMLMM", "1 3 N")]
        [InlineData("3 3 E", "MMRMMRMRRM", "5 1 E")]
        public void Should_Success_Rover_Move_To_Location(string initialRoverLocation, string commands,
            string expectedFinalLocation)
        {
            var rover = new Rover();

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            rover.LaunchRover(plateau, initialRoverLocation);
            rover.MoveToLocation(plateau, commands);

            rover.XCoordinate.Should().Be(int.Parse(expectedFinalLocation.Split(" ")[0]));
            rover.YCoordinate.Should().Be(int.Parse(expectedFinalLocation.Split(" ")[1]));
            rover.Direction.Should()
                .Be((Direction) Enum.Parse(typeof(Direction), expectedFinalLocation.Split(" ")[2].ToUpper()));
        }
    }
}