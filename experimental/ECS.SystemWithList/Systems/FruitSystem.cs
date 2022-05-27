using Ancient.ECS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ECS.Experimental.Systems
{
    internal class FruitSystem : ISystem
    {
        internal List<FruitComponent> fruits = new List<FruitComponent>();
        public void AddComponent(IComponent component)
        {
            fruits.Add((FruitComponent)component);
        }
    }
}
