namespace Ancient.Ecs;
public abstract class EcsSystem
{
    protected readonly IEntityManager EntityManager;
    private readonly IEventManager EventManager;

    protected EcsSystem(IEntityManager entityManager, IEventManager eventManager)
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
