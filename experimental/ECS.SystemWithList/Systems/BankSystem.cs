using Ancient.ECS;

namespace ECS.Experimental.Systems
{
    internal class BankSystem : ISystem
    {
        internal List<MoneyComponent> money = new List<MoneyComponent>();
        public void AddComponent(IComponent component)
        {
            money.Add((MoneyComponent)component);
        }
    }
}
