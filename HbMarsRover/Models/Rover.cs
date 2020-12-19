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
        public int XCoordinate { get; set; }
        public int YCoordinate { get; set; }
        public Direction Direction { get; set; }
    }
}