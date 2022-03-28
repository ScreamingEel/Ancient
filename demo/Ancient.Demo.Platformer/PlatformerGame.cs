using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Ancient.Demo.Platformer
{
    public class PlatformerGame : Game
    {
        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch? _spriteBatch;
        private Color _drawColor = Color.CornflowerBlue;

        public PlatformerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new(GraphicsDevice);

            base.LoadContent();
        }

        protected override void Update(GameTime gameTime)
        {
            if (gameTime.TotalGameTime.Seconds > 30)
                _drawColor = Color.Black;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_drawColor);

            base.Draw(gameTime);
        }
    }
}
