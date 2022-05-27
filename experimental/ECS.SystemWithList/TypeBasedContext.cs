using Ancient.ECS;

namespace ECS.Experimental
{
    internal class TypeBasedContext : IDisposable
    {
        internal Dictionary<Type, List<ISystem>> _componentsToSystems = new Dictionary<Type, List<ISystem>>();

        internal BankSystem bankSystem = new();
        internal FruitSystem fruitSystem = new();
        internal MoneyFruitSystem moneyFruitSystem = new();

        public TypeBasedContext()
        {
            _componentsToSystems.Add(typeof(MoneyComponent), new List<ISystem>
            {
                bankSystem,
                moneyFruitSystem
            });
            //_componentsToSystems.Add(typeof(FruitComponent), new List<ISystem>
            //{
            //    fruitSystem,
            //    moneyFruitSystem
            //});
        }

        public void Dispose()
        {
            _componentsToSystems = null;
        }

        internal void AddComponent<T>(T component) where T : IComponent
        {
            var systems = _componentsToSystems.GetValueOrDefault(typeof(T));
            if (systems is null)
                return;

            foreach (var system in systems)
                system.AddComponent(component);
        }
    }
}
