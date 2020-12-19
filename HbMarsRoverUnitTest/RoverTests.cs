using System;
using FluentAssertions;
using HbMarsRover;
using HbMarsRover.Enums;
using HbMarsRover.Services;
using Xunit;

namespace HbMarsRoverUnitTest
{
    public class RoverTests
    {
        [Fact]
        public void Should_Success_Create_Rover()
        {
            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.N);
        }

        [Fact]
        public void Should_Success_Rover_Launch()
        {
            var roverService = new RoverService();

            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            roverService.LaunchRover(rover, plateau, "1 2 N");

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.N);
        }

        [Fact]
        public void Should_Success_Rover_Turn_Left()
        {
            var roverService = new RoverService();

            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            roverService.LaunchRover(rover, plateau, "1 2 N");
            roverService.TurnLeft(rover);

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.W);
        }

        [Fact]
        public void Should_Success_Rover_Turn_Right()
        {
            var roverService = new RoverService();

            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            roverService.LaunchRover(rover, plateau, "1 2 N");
            roverService.TurnLeft(rover);

            rover.XCoordinate.Should().Be(1);
            rover.YCoordinate.Should().Be(2);
            rover.Direction.Should().Be(Direction.E);
        }

        [Fact]
        public void Should_Success_Rover_Move_Forward()
        {
            var roverService = new RoverService();

            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            roverService.LaunchRover(rover, plateau, "1 2 N");

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
            var roverService = new RoverService();

            var rover = new Rover
            {
                Direction = Direction.N,
                XCoordinate = 1,
                YCoordinate = 2
            };

            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            roverService.LaunchRover(rover, plateau, initialRoverLocation);
            roverService.MoveToLocation(rover, plateau, commands);

            rover.XCoordinate.Should().Be(int.Parse(expectedFinalLocation.Split(" ")[0]));
            rover.YCoordinate.Should().Be(int.Parse(expectedFinalLocation.Split(" ")[1]));
            rover.Direction.Should()
                .Be((Direction) Enum.Parse(typeof(Direction), expectedFinalLocation.Split(" ")[2].ToUpper()));
        }
    }
}