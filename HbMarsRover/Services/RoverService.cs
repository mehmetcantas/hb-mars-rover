using System;

namespace HbMarsRover.Services
{
    public class RoverService : IRoverService
    {
        public Rover TurnLeft(Rover rover)
        {
            switch (rover.Direction)
            {
                case "N": // While you facing North and if you turn left you facing to West
                    rover.Direction = "W";
                    break;
                
                case "S": // While you facing South and if you turn left you facing to East
                    rover.Direction = "E";
                    break;
                
                case "W": // While you facing West and if you turn left you facing to South
                    rover.Direction = "S";
                    break;
                
                case "E": // While you facing East and if you turn left you facing to North
                    rover.Direction = "N";
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
                
                case "N": // While you facing North and if you turn right you facing to East
                    rover.Direction = "E";
                    break;
                
                case "S": // While you facing South and if you turn right you facing to West
                    rover.Direction = "W";
                    break;
                
                case "W": // While you facing West and if you turn right you facing to North
                    rover.Direction = "N";
                    break;
               
                case "E":  // While you facing East and if you turn right you facing to South
                    rover.Direction = "S";
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }

            return rover;
        }

        public Rover MoveForward(Rover rover)
        {
            switch (rover.Direction)
            {
                
                case "N": // While you facing North and if you turn right you facing to East
                    rover.YCoordinate += 1;
                    break;
                
                case "S": // While you facing South and if you turn right you facing to West
                    rover.YCoordinate -= 1;
                    break;
                
                case "W": // While you facing West and if you turn right you facing to North
                    rover.XCoordinate -= 1;
                    break;
               
                case "E":  // While you facing East and if you turn right you facing to South
                    rover.XCoordinate += 1;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }

            return rover;
        }


        public Rover MoveToLocation(Rover rover , string commands)
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
                        MoveForward(rover);
                        break;
                    default:
                        throw new ArgumentException("Location command unrecognized");
                }
            }

            return rover;
        }
    }
}