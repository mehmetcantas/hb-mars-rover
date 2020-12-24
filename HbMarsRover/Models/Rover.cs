using System;
using HbMarsRover.Enums;

namespace HbMarsRover
{
    // Rover(s) position represented by x,y,z values (z coordinates for directions)
    // Sample input => x:0 y:0 z:N
    // Directions (Z coordinates) =>  N : North || E : East || W : West || S : South
    // Command messages => L : Left || R : Right || M : Forward
    // Two lines input per Rover:
    //    1.  1 2 N (rover position)
    //    2.  LMLMLMLMM (rover commands)
    
    public class Rover
    {
        public int XCoordinate { get; private set; }
        public int YCoordinate { get; private set; }
        public Direction Direction { get; private set; }
        

        #region Methods
        public void LaunchRover(Plateau plateau, string coordinates)
        {
            var launchLocation = coordinates.Split(" ");

            XCoordinate = int.Parse(launchLocation[0]);
            YCoordinate = int.Parse(launchLocation[1]);
            Direction = (Direction) Enum.Parse(typeof(Direction), launchLocation[2].ToUpper());

            if (YCoordinate > plateau.Height || YCoordinate < 0)
                throw new Exception("Rover cannot be launched on this coordinates");

            if (XCoordinate > plateau.Width || XCoordinate < 0)
                throw new Exception("Rover cannot be launched on this coordinates");
        }

        public void TurnLeft()
        {
            switch (Direction)
            {
                case Direction.N: // While you facing North and if you turn left you facing to West
                    Direction = Direction.W;
                    break;

                case Direction.S: // While you facing South and if you turn left you facing to East
                    Direction = Direction.E;
                    break;

                case Direction.W: // While you facing West and if you turn left you facing to South
                    Direction = Direction.S;
                    break;

                case Direction.E: // While you facing East and if you turn left you facing to North
                    Direction = Direction.N;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }
        }

        public void TurnRight()
        {
            switch (Direction)
            {
                case Direction.N: // While you facing North and if you turn right you facing to East
                    Direction = Direction.E;
                    break;

                case Direction.S: // While you facing South and if you turn right you facing to West
                    Direction = Direction.W;
                    break;

                case Direction.W: // While you facing West and if you turn right you facing to North
                    Direction = Direction.N;
                    break;

                case Direction.E: // While you facing East and if you turn right you facing to South
                    Direction = Direction.S;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }
        }

        public void MoveForward(Plateau plateau)
        {
            switch (Direction)
            {
                case Direction.N: // While you facing North and if you turn right you facing to East
                    if ((YCoordinate + 1) > plateau.Height)
                        throw new Exception("Rover cannot be move any further on the Y axis");

                    YCoordinate += 1;
                    break;

                case Direction.S: // While you facing South and if you turn right you facing to West
                    if ((YCoordinate - 1) < 0)
                        throw new Exception("Rover cannot be move any further on Y axis");

                    YCoordinate -= 1;
                    break;

                case Direction.W: // While you facing West and if you turn right you facing to North
                    if ((XCoordinate - 1) < 0)
                        throw new Exception("Rover cannot be move any further on the X axis");
                    XCoordinate -= 1;
                    break;

                case Direction.E: // While you facing East and if you turn right you facing to South
                    if ((XCoordinate + 1) > plateau.Width)
                        throw new Exception("Rover cannot be move any further on the X axis");
                    XCoordinate += 1;
                    break;
                default:
                    throw new ArgumentException("Direction is invalid");
            }
        }

        public void MoveToLocation(Plateau plateau, string commands)
        {
            var seperatedCommands = commands.ToCharArray();
            foreach (var item in seperatedCommands)
            {
                switch (item)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'M':
                        MoveForward(plateau);
                        break;
                    default:
                        throw new ArgumentException("Location command unrecognized");
                }
            }
        }
        #endregion
        
    }
}