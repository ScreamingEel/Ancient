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

    public void AddComponent<T>(int entityId, T component) where T : IEntityComponent
    {
        var componentSet = _entityComponents[typeof(T).Name];

        if (componentSet is null)
            return;

        componentSet[entityId] = component;
    }

    public T? GetComponent<T>(int entityId) where T : IEntityComponent
    {
        var component = _entityComponents[typeof(T).Name][entityId];
        return component is null ? default(T) : (T)component;
    }
}
