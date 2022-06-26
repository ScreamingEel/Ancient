namespace Ancient.Ecs.Test.TestSubjects.Systems;
public class NameSystem : EcsSystem
{
    private readonly string _changeNameTo;

    public NameSystem(IEntityManager entityManager, IEventManager eventManager, 
        string changeNameTo = "") 
        : base(entityManager, eventManager)
    {
        _changeNameTo = changeNameTo;
        SubscribeEvent<FirstNameChangedEvent>();
    }

    public override void HandleEvent(IEcsEvent ecsEvent)
    {
        if (ecsEvent is FirstNameChangedEvent nameChangedEvent)
        {
            var nameComponent = EntityManager.GetComponent<NameComponent>(nameChangedEvent.EntityId);

            if (nameComponent is not null)
                nameComponent.FirstName = _changeNameTo;
        }
    }

    public void RemoveSubscription()
    {
        RemoveEventSubscribtion<FirstNameChangedEvent>();
    }
}
