using System;
namespace HbMarsRover
{
    class Program
    {
        /*
         * A rover's position and location is represented by a combination of x and y co-ordinates
         * a letter representing one of the four cardinal compass points.
         * example position might be 0, 0, N, which means the rover is in the bottom left corner and facing North.
         * L : Left
         * R : Right
         * M : Forward (one grid point)
         * Each rover will be finished sequentially, which means that the second rover won't start to move until the first one has finished moving.
         * output for each rover should be its final co-ordinates and heading.
         */
        static void Main(string[] args)
        {
            var plateau = new Plateau();
            plateau.SetHeight(5);
            plateau.SetWidth(5);

            var firstRover = new Rover();

            firstRover.LaunchRover(plateau, "1 2 N");

            firstRover.MoveToLocation(plateau, "LMLMLMLMM");

            Console.WriteLine(
                $"First rover final coordinates : {firstRover.XCoordinate} {firstRover.YCoordinate} {firstRover.Direction}");

            var secondRover = new Rover();

            secondRover.LaunchRover(plateau, "3 3 E");
            secondRover.MoveToLocation(plateau, "MMRMMRMRRM");

            Console.WriteLine(
                $"Second rover final coordinates : {secondRover.XCoordinate} {secondRover.YCoordinate} {secondRover.Direction}");

            Console.ReadLine();
        }
    }
}