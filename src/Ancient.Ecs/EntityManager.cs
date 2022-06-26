namespace Ancient.Ecs;
public class EntityManager : IEntityManager
{
    private readonly HashSet<int> _entities;
    private readonly Dictionary<string, Dictionary<int, IEntityComponent>> _entityComponents;

    public EntityManager(EntityManagerConfiguration? configuration = null)
    {
        _entities = new();

        if (configuration is null)
        {
            _entityComponents = new();
            return;
        }

        _entityComponents = configuration.ComponentSets;
    }

    public int CreateEntity()
    {
        int id = Enumerable.Range(0, int.MaxValue)
            .Except(_entities)
            .First();

        _entities.Add(id);

        return id;
    }

    public void RemoveEntity(int entityId)
    {
        _entities.Remove(entityId);
    }

    public int CountEntities() => _entities.Count;

    /// <exception cref="ComponentSetNotExistException" />
    public void AddComponent<T>(int entityId, T component) where T : IEntityComponent
    {
        var componentSet = GetComponentSet<T>();

        if (component is EntityComponentBase componentBase)
            componentBase.EntityId = entityId;

        componentSet[entityId] = component;
    }

    public void RemoveComponent<T>(int entityId) where T : IEntityComponent
    {
        var componentSet = GetComponentSet<T>();
        if (componentSet.ContainsKey(entityId))
            componentSet.Remove(entityId);
    }

    /// <exception cref="ComponentSetNotExistException" />
    public T? GetComponent<T>(int entityId) where T : IEntityComponent
    {
        var componentSet = GetComponentSet<T>();
        return componentSet.ContainsKey(entityId) ? (T)componentSet[entityId] : default(T);
    }

    /// <exception cref="ComponentSetNotExistException" />
    public IEnumerable<T> GetAllComponents<T>() where T : IEntityComponent
    {
        var componentSet = GetComponentSet<T>();
        return componentSet.Values.Cast<T>();
    }

    private Dictionary<int, IEntityComponent> GetComponentSet<T>()
    {
        string componentName = typeof(T).Name;
        return _entityComponents.ContainsKey(componentName) ? _entityComponents[componentName] : 
            throw new ComponentSetNotExistException(componentName);
    }
}
