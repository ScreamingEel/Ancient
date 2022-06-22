namespace Ancient.Ecs;
public class EntityManager
{
    private readonly HashSet<int> _entities;

    public EntityManager()
    {
        _entities = new HashSet<int>();
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

    #region Debug Methods

    public int CountEntities => _entities.Count;

    #endregion
}
