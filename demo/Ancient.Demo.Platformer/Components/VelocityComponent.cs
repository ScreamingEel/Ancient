namespace Ancient.Demo.Platformer.Components;
public class VelocityComponent : IEntityComponent
{
    public Vector2 Velocity { get; set; }

    public VelocityComponent(Vector2 velocity)
    {
        Velocity = velocity;
    }
}
