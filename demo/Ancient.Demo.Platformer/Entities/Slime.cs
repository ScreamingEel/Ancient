using Ancient.Demo.Platformer.Common;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ancient.Demo.Platformer.Entities
{
    public class Slime : Entity, IDrawableEntity, IUpdatableEntity
    {
        public Texture2D? Texture => _texture;

        private Texture2D? _texture;
        private SpriteBatch? _spriteBatch;

        private Vector2 _slimePosition;
        float _slimeSpeed;

        public Slime()
        {
            _slimePosition = new Vector2(1920 / 2, 1080 / 2);
            _slimeSpeed = 300f;
        }

        public void Draw(GameTime gameTime)
        {
            if (_spriteBatch is not null)
                _spriteBatch.Draw(_texture, _slimePosition, null, Color.White, 0,
                    new Vector2(_texture!.Width / 2, _texture.Height / 2), 8, SpriteEffects.None, 0);
        }

        public void SetTexture(SpriteBatch spriteBatch, ContentManager contentManager)
        {
            _spriteBatch = spriteBatch;
            _texture = contentManager.Load<Texture2D>("Sprites\\Slime");
        }

        public void Update(GameTime gameTime)
        {
            var keystate = Keyboard.GetState();


            if (keystate.IsKeyDown(Keys.W))
                _slimePosition.Y -= _slimeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keystate.IsKeyDown(Keys.S))
                _slimePosition.Y += _slimeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keystate.IsKeyDown(Keys.A))
                _slimePosition.X -= _slimeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (keystate.IsKeyDown(Keys.D))
                _slimePosition.X += _slimeSpeed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
    }
}
