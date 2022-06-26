namespace Ancient.Ecs.Test.TestSubjects.Events;
public class FirstNameChangedEvent : IEcsEvent
{
    public int EntityId { get; set; }

    public FirstNameChangedEvent(int entityId)
    {
        EntityId = entityId;
    }
}
