namespace Ancient.Ecs;
public interface IEventManager
{
    public void Subscribe<T>(EcsSystem ecsSystem) where T : IEcsEvent;
    public void RemoveSubscription<T>(EcsSystem ecsSystem) where T : IEcsEvent;
    public void InvokeEvent<T>(T ecsEvent) where T : IEcsEvent;
}
