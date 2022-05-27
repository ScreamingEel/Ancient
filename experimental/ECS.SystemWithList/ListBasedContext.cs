using Ancient.ECS;

namespace ECS.Experimental
{
    internal class ListBasedContainer<T> where T : IComponent
    {
        readonly List<ISystem> _systems = new List<ISystem>();

        internal ListBasedContainer(List<ISystem> systems)
        {
            foreach (var system in systems)
                _systems.Add(system);
        }

        internal void AddComponent(T component)
        {
            foreach (var system in _systems)
                system.AddComponent(component);
        }
    }
}
