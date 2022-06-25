namespace Ancient.Ecs.Test.TestSubjects.Systems;
public class NameSystem : EcsSystem
{
    public NameSystem(EntityManager entityManager, EventManager eventManager) 
        : base(entityManager, eventManager)
    {
        SubscribeEvent<FirstNameChangedEvent>();
    }

    public override void HandleEvent(IEcsEvent ecsEvent)
    {
        if (ecsEvent is FirstNameChangedEvent nameChangedEvent)
        {
            var nameComponent = EntityManager.GetComponent<NameComponent>(nameChangedEvent.EntityId);

            if (nameComponent is not null)
                nameComponent.FirstName = "Test successful";
        }
    }
}
