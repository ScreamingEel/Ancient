namespace Ancient.Ecs;
public class EntityManagerConfiguration
{
    internal readonly Dictionary<string, Dictionary<int, IEntityComponent>> ComponentSets;

    public EntityManagerConfiguration()
    {
        ComponentSets = new();
    }

    public void AddComponentSet<T>() where T : IEntityComponent
    {
        ComponentSets.Add(typeof(T).Name, new Dictionary<int, IEntityComponent>());
    }
}
