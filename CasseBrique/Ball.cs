using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CasseBrique
{
    public class Ball
    {
        private Vector2 position;
        private Texture2D texture;
        private Vector2 velocity;
        private Color color;

        public Ball()
        {
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("Ball");
            this.position = ServiceLocator.Get<IScreenService>().Center;
            this.color = Color.White;
        }

        public void Shoot(Vector2 direction, float speed)
        {
            velocity = direction * speed;
        }

        public void Update(float dt)
        {
            position += velocity * dt;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, position, color);
        }
    }
}
