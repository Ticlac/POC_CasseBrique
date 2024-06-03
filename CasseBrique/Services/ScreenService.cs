using Microsoft.Xna.Framework;
using System.Dynamic;

namespace CasseBrique.Services
{
    public class ScreenService
    {
        public ScreenService(int width, int height)
        {
            ServiceLocator.Register<ScreenService>(this);
            SetSize(width, height);
        }

        public int width => ServiceLocator.Get<GraphicsDeviceManager>().PreferredBackBufferWidth;
        public int height => ServiceLocator.Get<GraphicsDeviceManager>().PreferredBackBufferHeight;
        public Vector2 topLeft => Vector2.Zero;
        public Vector2 botRight => new Vector2(width, height);
        public Vector2 center => botRight * .5f;

        public void SetSize(int width, int height)
        {
            var graphics = ServiceLocator.Get<GraphicsDeviceManager>();
            graphics.PreferredBackBufferWidth = width;
            graphics.PreferredBackBufferHeight = height;
            graphics.ApplyChanges();
        }


    }
}
