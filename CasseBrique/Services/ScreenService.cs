using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using System.Dynamic;

namespace CasseBrique.Services
{
    public sealed class ScreenService : IScreenService
    {
        private GraphicsDeviceManager graphicsDeviceManager;
        public ScreenService(GraphicsDeviceManager graphicsDeviceManager)
        {
            this.graphicsDeviceManager = graphicsDeviceManager;
            ServiceLocator.Register<IScreenService>(this);
        }

        //Semi constantes ==> Possible de les setter
        public int Width => this.graphicsDeviceManager.PreferredBackBufferWidth;
        public int Height => this.graphicsDeviceManager.PreferredBackBufferHeight;
        public int Top => 0;
        public int Left => 0;
        public Vector2 TopLeft => Vector2.Zero;
        public Vector2 BotRight => new Vector2(Width, Height);
        public Vector2 Center => BotRight * .5f;
        public Rectangle Bounds => new Rectangle(Top, Left, Width, Height);

        public void SetSize(int width, int height)
        {
            this.graphicsDeviceManager.PreferredBackBufferWidth = width;
            this.graphicsDeviceManager.PreferredBackBufferHeight = height;
            this.graphicsDeviceManager.ApplyChanges();
        }


    }
}
