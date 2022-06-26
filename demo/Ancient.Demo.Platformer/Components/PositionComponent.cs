namespace Ancient.Demo.Platformer.Components;
public class PositionComponent : IEntityComponent
{
    public Vector2 Position { get; set; }

    public PositionComponent(Vector2 position)
    {
        Position = position;
    }
}
