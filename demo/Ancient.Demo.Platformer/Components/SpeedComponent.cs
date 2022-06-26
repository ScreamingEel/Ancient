namespace Ancient.Demo.Platformer.Components;
public class SpeedComponent : IEntityComponent
{
    public float Speed { get; set; }

    public SpeedComponent(float speed)
    {
        Speed = speed;
    }
}
