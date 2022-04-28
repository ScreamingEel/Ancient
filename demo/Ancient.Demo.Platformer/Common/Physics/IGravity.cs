namespace Ancient.Demo.Platformer.Common.Physics
{
    public interface IGravity
    {
        Vector2 Acceleration { get; set; }
        Vector2 Velocity { get; set; }
    }
}
