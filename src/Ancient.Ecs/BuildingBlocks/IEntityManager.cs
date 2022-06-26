namespace Ancient.Ecs;
public interface IEntityManager
{
    public int CreateEntity();
    public void RemoveEntity(int entityId);
    public int CountEntities();
    public void AddComponent<T>(int entityId, T component) where T : IEntityComponent;
    public T? GetComponent<T>(int entityId) where T : IEntityComponent;
    public IEnumerable<T> GetAllComponents<T>() where T : IEntityComponent;
}
