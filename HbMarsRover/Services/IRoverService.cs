namespace HbMarsRover.Services
{
    public interface IRoverService
    {
        Rover TurnLeft(Rover rover);
        Rover TurnRight(Rover rover);
        Rover MoveForward(Rover rover);

        Rover MoveToLocation(Rover rover,string commands);
    }
}