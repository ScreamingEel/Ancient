using Ancient.ECS;

namespace ECS.Experimental.Systems
{
    internal class MoneyFruitSystem : ISystem
    {
        internal List<MoneyComponent> money = new();
        internal List<FruitComponent> fruits = new();

        public void AddComponent(IComponent component)
        {
            if (component is MoneyComponent moneyComponent)
                money.Add(moneyComponent);
            else if (component is FruitComponent fruitComponent)
                fruits.Add(fruitComponent);
        }
    }
}
