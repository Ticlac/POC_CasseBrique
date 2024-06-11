﻿using CasseBrique.GameObjects;
using CasseBrique.Scenes;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CasseBrique.Props
{
    public class Ball : SpriteGameObject
    {
        private Vector2 velocity;
        private Vector2 direction;
        private float speed;
        private Rectangle bounds;
        private float radius => texture.Width * .5f;
        private int bounceCounter = 0;

        public Ball(Scene root, Vector2 direction, Rectangle bounds) : base(root)
        {
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("Ball");
            this.position = ServiceLocator.Get<IScreenService>().Center;
            this.offset = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            this.bounds = bounds;
            this.direction = direction;
            this.speed = 400f;
            this.velocity = Vector2.Zero;

        }

        public override void Update(float dt)
        {
            Move(dt);
            Bounce();
        }

        //public override void Draw(SpriteBatch sb)
        //{
        //    sb.Draw(texture, position, null, color, rotation, offset, scale, SpriteEffects.None, 0);
        //}

        public void Move(float dt)
        {
            //Remettre dans un cercle de rayon 1
            direction.Normalize();
            velocity = direction * speed;
            position += velocity * dt;
        }

        public void Bounce()
        {
            if (position.X > bounds.Right - radius)
            {
                position.X = bounds.Right - radius;
                direction.X *= -1;
            }
            else if (position.X < bounds.Left + radius)
            {
                position.X = bounds.Left + radius;
                direction.X *= -1;
            }
            if (position.Y > bounds.Bottom - radius)
            {
                position.Y = bounds.Bottom - radius;
                direction.Y *= -1;
            }
            else if (position.Y < bounds.Top + radius)
            {
                position.Y = bounds.Top + radius;
                direction.Y *= -1;
            }
        }

    }
}
