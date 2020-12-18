namespace HbMarsRover.Services
{
    public interface IRoverService
    {
        Rover SpinLeft(Rover rover);
        Rover SpinRight(Rover rover);
        Rover MoveForward(Rover rover);
    }
}