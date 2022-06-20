namespace Ancient.ECS
{
    public class Entity
    {
        public IReadOnlyCollection<IComponent> Components => _components.AsReadOnly();

        public object Id { get; set; }

        private readonly List<IComponent> _components;

        public Entity()
        {
            _components = new List<IComponent>();
        }
    }
}
