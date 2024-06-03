﻿using CasseBrique.Scenes;
using CasseBrique.Services;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CasseBrique
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private AssetService _assetService;
        private ScreenService _screeService;
        private ScenesManager _SceneManager;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            ServiceLocator.Register<ContentManager>(Content);
            ServiceLocator.Register<GraphicsDeviceManager>(_graphics);
            _assetService = new AssetService();
            _screeService = new ScreenService(1920, 1080);
            _SceneManager = new ScenesManager();

            //TODO : Key = Type + instantiation au chargement de la nouvelle scene 
            _SceneManager.RegisterScene("Game", new SceneGame());



            base.Initialize();
        }

        protected override void LoadContent()
        {
            // TODO: use this.Content to load your game content here
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _assetService.Load<Texture2D>("Ball");

            // Load de la premiere scene apres avoir charger toutes les textures.
            _SceneManager.LoadScene("Game");
        }

        protected override void Update(GameTime gameTime)
        {

            // TODO: Add your update logic here

            float dt = (float)gameTime.ElapsedGameTime.TotalSeconds;

            _SceneManager.Update(dt);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            _SceneManager.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
