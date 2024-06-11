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
            BounceOnBounds();
            OutOfBounds();
        }

        //TODO : methode de collision generique avec d'autres spriteGameObjects : <T>

        private void OutOfBounds()
        {
            //check si on est sous les limites de l'ecran
            if (position.Y > bounds.Bottom - 100f)
            {
                // TODO :
                // envoyer un message outOfBounds
                // recoller la balle au pad
            }
        }

        private void Move(float dt)
        {
            //Remettre dans un cercle de rayon 1
            direction.Normalize();
            velocity = direction * speed;
            position += velocity * dt;
        }

        private void BounceOnBounds()
        {
            if (position.X > bounds.Right - offset.X)
            {
                position.X = bounds.Right - offset.X;
                direction.X *= -1;
            }
            else if (position.X < bounds.Left + offset.X)
            {
                position.X = bounds.Left + offset.X;
                direction.X *= -1;
            }

            if (position.Y < bounds.Top + offset.Y)
            {
                position.Y = bounds.Top + offset.Y;
                direction.Y *= -1;
            }
        }

    }
}