using Ancient.Demo.Platformer.Systems;
using Microsoft.Xna.Framework.Graphics;

namespace Ancient.Demo.Platformer
{
    public class PlatformerGame : Game
    {
        private readonly IEntityManager _entityManager;
        private readonly IEventManager _eventManager;

        // Entities
        private int _playerEntity;

        // Systems
        private DrawSystem _drawSystem;

        private readonly GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Color _drawColor = Color.CornflowerBlue;
        private bool _showPlayer;

        public PlatformerGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            var entityManagerConfig = new EntityManagerConfiguration();
            entityManagerConfig.AddComponentSet<PositionComponent>();
            entityManagerConfig.AddComponentSet<SpeedComponent>();
            entityManagerConfig.AddComponentSet<TextureComponent>();
            entityManagerConfig.AddComponentSet<AccelerationComponent>();
            entityManagerConfig.AddComponentSet<VelocityComponent>();
            _entityManager = new EntityManager(entityManagerConfig);
            _eventManager = new EventManager();
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1920;
            _graphics.PreferredBackBufferHeight = 1080;
            _graphics.ApplyChanges();

            // Player entity
            _playerEntity = _entityManager.CreateEntity();
            _entityManager.AddComponent(_playerEntity, new PositionComponent(new Vector2(1920 / 2, 1080 / 2)));
            _entityManager.AddComponent(_playerEntity, new SpeedComponent(300f));
            _entityManager.AddComponent(_playerEntity, new AccelerationComponent(new Vector2(0, 1000f)));
            _entityManager.AddComponent(_playerEntity, new VelocityComponent(Vector2.Zero));
            _entityManager.AddComponent(_playerEntity, new TextureComponent(Content.Load<Texture2D>("Sprites/Slime")));

            // Systems
            _drawSystem = new DrawSystem(_entityManager, _eventManager);

            base.Initialize();
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

            if (gameTime.TotalGameTime.Seconds % 5 == 0)
            {
                _entityManager.AddComponent(_playerEntity,
                    new TextureComponent(Content.Load<Texture2D>("Sprites/Slime")));
            }
            else
            {
                _entityManager.RemoveComponent<TextureComponent>(_playerEntity);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(_drawColor);

            _drawSystem.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}
