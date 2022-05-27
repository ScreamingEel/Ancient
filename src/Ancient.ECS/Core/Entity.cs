namespace Ancient.ECS
{
    public class Entity
    {
        public IReadOnlyCollection<IComponent> Components => _components.AsReadOnly();

        private readonly List<IComponent> _components;

        public Entity()
        {
            _components = new List<IComponent>();
        }
    }
}
