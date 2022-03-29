using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace Ancient.Demo.Platformer.Common
{
    public interface IDrawableEntity
    {
        public Texture2D? Texture { get; }
        public void SetTexture(SpriteBatch spriteBatch, ContentManager contentManager);
        public void Draw(GameTime gameTime);
    }
}
