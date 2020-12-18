namespace HbMarsRover.Services
{
    public interface IRoverService
    {
        Rover TurnLeft(Rover rover);
        Rover TurnRight(Rover rover);
        Rover MoveForward(Rover rover,Plateau plateau);

        Rover LaunchRover(Rover rover,Plateau plateau,string coordinates);
        Rover MoveToLocation(Rover rover,Plateau plateau,string commands);
    }
}