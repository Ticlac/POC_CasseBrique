﻿using CasseBrique.Services;
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

        public Ball(Vector2 position)
        {
            this.texture = ServiceLocator.Get<AssetService>().Get<Texture2D>("Ball");
            this.position = position;
            this.color = Color.White;
        }

        public void shoot(Vector2 direction, float speed)
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
