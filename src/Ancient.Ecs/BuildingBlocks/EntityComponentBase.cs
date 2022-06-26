namespace Ancient.Ecs;
public abstract class EntityComponentBase : IEntityComponent
{
    public int EntityId { get; internal set; }
}
