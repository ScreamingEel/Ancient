using Ancient.Demo.Platformer.Common;
using Ancient.Demo.Platformer.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ancient.Demo.Platformer
{
    public class PlatformerGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch? _spriteBatch;
        private Color _drawColor = Color.CornflowerBlue;

        private List<Entity> _entities;

        public PlatformerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            _entities = new List<Entity>();
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new(GraphicsDevice);

            Slime slime = new Slime();
            slime.SetTexture(_spriteBatch, Content);
            _entities.Add(slime);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > 30)
                _drawColor = Color.Black;

            foreach (var entity in _entities)
                if (entity is IUpdatableEntity updatableEntity)
                    updatableEntity.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_drawColor);

            _spriteBatch!.Begin(samplerState: SamplerState.PointClamp);

            foreach (var entity in _entities)
                if (entity is IDrawableEntity drawableEntity)
                    drawableEntity.Draw(gameTime);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
