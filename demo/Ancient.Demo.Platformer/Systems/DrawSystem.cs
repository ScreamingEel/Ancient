using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ancient.Demo.Platformer.Systems;
public class DrawSystem : EcsSystem
{
    public DrawSystem(IEntityManager entityManager, IEventManager eventManager) : base(entityManager, eventManager)
    {
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Begin(samplerState: SamplerState.PointClamp);

        foreach (var textureComp in EntityManager.GetAllComponents<TextureComponent>())
        {
            var positionComp = EntityManager.GetComponent<PositionComponent>(textureComp.EntityId);
            var texture = textureComp.Texture;

            if (positionComp is not null)
                spriteBatch.Draw(texture, positionComp.Position, null, Color.White, 0,
                    new Vector2(texture.Width / 2, texture.Height / 2), 8, SpriteEffects.None, 0);
        }

        spriteBatch.End();
    }
}
