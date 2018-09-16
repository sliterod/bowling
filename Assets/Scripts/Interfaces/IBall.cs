public interface IBall
{
    void Rotate(float direction);

    void MoveSideways(float direction);

    void SetThrust(float thrust);

    void Throw();
}