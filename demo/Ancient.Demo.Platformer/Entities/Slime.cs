using Ancient.Demo.Platformer.Common;
using Ancient.Demo.Platformer.Common.Physics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Ancient.Demo.Platformer.Entities
{
    public class Slime : Entity, IDrawableEntity, IUpdatableEntity, IGravity
    {
        public Texture2D? Texture => _texture;

        public Vector2 Acceleration
        {
            get { return _acceleration; }
            set { _acceleration = value; }
        }
        public Vector2 Velocity 
        { 
            get { return _velocity; }
            set { _velocity = value; }
        }

        private Texture2D? _texture;
        private SpriteBatch? _spriteBatch;

        private Vector2 _slimePosition;
        private float _speed;
        private Vector2 _velocity;
        private Vector2 _acceleration = new Vector2(0, 1000f);
        private bool _isJumping;
        private bool _spaceDown = false;

        public Slime()
        {
            _slimePosition = new Vector2(1920 / 2, 1080 / 2);
            _speed = 300f;
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

            _velocity = Vector2.Zero;

            if (keystate.IsKeyDown(Keys.A))
                _velocity.X -= _speed;

            if (keystate.IsKeyDown(Keys.D))
                _velocity.X += _speed;

            HandleJump();

            CalculateGravity(gameTime);

            _velocity += _acceleration * (float)gameTime.ElapsedGameTime.TotalSeconds;
            _slimePosition += _velocity * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void CalculateGravity(GameTime gameTime)
        {
            if (_acceleration.Y < 15000f)
                _acceleration.Y += 100f;

            if (_acceleration.Y > 0)
                _isJumping = false;
        }

        public void HandleJump()
        {
            var keystate = Keyboard.GetState();

            if (_spaceDown && keystate.IsKeyDown(Keys.Space))
                return;
            else
                _spaceDown = false;

            if (!_isJumping && keystate.IsKeyDown(Keys.Space))
            {
                _acceleration.Y = -15000f;
                _isJumping = true;
                _spaceDown = true;
            }
        }
    }
}
