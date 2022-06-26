namespace Ancient.Ecs;
public class EventManager : IEventManager
{
    private readonly Dictionary<string, HashSet<EcsSystem>> _eventSets;

    public EventManager()
    {
        _eventSets = new Dictionary<string, HashSet<EcsSystem>>();
    }

    public void Subscribe<T>(EcsSystem ecsSystem) where T : IEcsEvent
    {
        var eventName = GetEventName<T>();

        if (_eventSets.ContainsKey(eventName))
            _eventSets[eventName].Add(ecsSystem);
        else
            _eventSets[eventName] = new HashSet<EcsSystem> { ecsSystem };
    }

    public void RemoveSubscription<T>(EcsSystem ecsSystem) where T : IEcsEvent
    {
        var eventSet = GetEventSet<T>();
        eventSet?.Remove(ecsSystem);
    }

    public void InvokeEvent<T>(T ecsEvent) where T : IEcsEvent
    {
        var eventSet = GetEventSet<T>();

        if (eventSet is null)
            return;

        foreach (var system in eventSet)
            system.HandleEvent(ecsEvent);
    }

    private string GetEventName<T>() => typeof(T).Name;

    private HashSet<EcsSystem>? GetEventSet<T>()
    {
        string eventName = GetEventName<T>();

        return _eventSets.ContainsKey(eventName) ? _eventSets[eventName] : null;
    }
}