using System;
using HbMarsRover.Enums;

namespace HbMarsRover.Services
{
    public class RoverService : IRoverService
    {
        public Rover TurnLeft(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N: // While you facing North and if you turn left you facing to West
                    rover.Direction = Direction.W;
                    break;

                case Direction.S: // While you facing South and if you turn left you facing to East
                    rover.Direction = Direction.E;
                    break;

                case Direction.W: // While you facing West and if you turn left you facing to South
                    rover.Direction = Direction.S;
                    break;

                case Direction.E: // While you facing East and if you turn left you facing to North
                    rover.Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }

            return rover;
        }

        public Rover TurnRight(Rover rover)
        {
            switch (rover.Direction)
            {
                case Direction.N: // While you facing North and if you turn right you facing to East
                    rover.Direction = Direction.E;
                    break;

                case Direction.S: // While you facing South and if you turn right you facing to West
                    rover.Direction = Direction.W;
                    break;

                case Direction.W: // While you facing West and if you turn right you facing to North
                    rover.Direction = Direction.N;
                    break;

                case Direction.E: // While you facing East and if you turn right you facing to South
                    rover.Direction = Direction.S;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }

            return rover;
        }

        public Rover MoveForward(Rover rover, Plateau plateau)
        {
            switch (rover.Direction)
            {
                case Direction.N: // While you facing North and if you turn right you facing to East
                    if ((rover.YCoordinate + 1) > plateau.Width)
                        throw new Exception("Rover cannot be move any further on the Y axis");

                    rover.YCoordinate += 1;
                    break;

                case Direction.S: // While you facing South and if you turn right you facing to West
                    if ((rover.YCoordinate - 1) < 0)
                        throw new Exception("Rover cannot be move any further on Y axis");

                    rover.YCoordinate -= 1;
                    break;

                case Direction.W: // While you facing West and if you turn right you facing to North
                    if ((rover.XCoordinate - 1) < 0)
                        throw new Exception("Rover cannot be move any further on the X axis");
                    rover.XCoordinate -= 1;
                    break;

                case Direction.E: // While you facing East and if you turn right you facing to South
                    if ((rover.XCoordinate + 1) > plateau.Width)
                        throw new Exception("Rover cannot be move any further on the X axis");
                    rover.XCoordinate += 1;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }

            return rover;
        }

        public Rover LaunchRover(Rover rover, Plateau plateau, string coordinates)
        {
            var launchLocation = coordinates.Split(" ");

            rover.XCoordinate = int.Parse(launchLocation[0]);
            rover.YCoordinate = int.Parse(launchLocation[1]);
            rover.Direction = (Direction) Enum.Parse(typeof(Direction), launchLocation[2].ToUpper());

            if (rover.YCoordinate > plateau.Width || rover.YCoordinate < 0)
                throw new Exception("Rover cannot be launched on this coordinates");

            if (rover.XCoordinate > plateau.Height || rover.XCoordinate < 0)
                throw new Exception("Rover cannot be launched on this coordinates");


            return rover;
        }

        public Rover MoveToLocation(Rover rover, Plateau plateau, string commands)
        {
            var seperatedCommands = commands.ToCharArray();
            foreach (var item in seperatedCommands)
            {
                switch (item)
                {
                    case 'L':
                        TurnLeft(rover);
                        break;
                    case 'R':
                        TurnRight(rover);
                        break;
                    case 'M':
                        MoveForward(rover, plateau);
                        break;
                    default:
                        throw new ArgumentException("Location command unrecognized");
                }
            }

            return rover;
        }
    }
}