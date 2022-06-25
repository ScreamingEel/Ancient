namespace Ancient.Ecs;
public abstract class EcsSystem
{
    protected readonly EntityManager EntityManager;
    private readonly EventManager EventManager;

    protected EcsSystem(EntityManager entityManager, EventManager eventManager)
    {
        EntityManager = entityManager;
        EventManager = eventManager;
    }

    protected void SubscribeEvent<T>() where T : IEcsEvent
    {
        EventManager.Subscribe<T>(this);
    }

    protected void RemoveEventSubscribtion<T>() where T : IEcsEvent
    {
        EventManager.RemoveSubscription<T>(this);
    }

    public virtual void HandleEvent(IEcsEvent ecsEvent)
    {
    }
}
