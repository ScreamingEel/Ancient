namespace Ancient.Demo.Platformer.Components;
public class AccelerationComponent : IEntityComponent
{
    public Vector2 Acceleration { get; set; }

    public AccelerationComponent(Vector2 acceleration)
    {
        Acceleration = acceleration;
    }
}
