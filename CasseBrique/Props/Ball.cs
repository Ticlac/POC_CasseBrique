using CasseBrique.GameObjects;
using CasseBrique.Scenes;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;


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
        private bool sticked;

        public Ball(Scene root, Rectangle bounds) : base(root)
        {
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("Ball");
            this.position = ServiceLocator.Get<IScreenService>().Center;
            this.offset = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            this.bounds = bounds;
            this.speed = 800f;
            this.velocity = Vector2.Zero;
            this.sticked = true;
        }

        public override void Update(float dt)
        {

            if (sticked)
            {
                var pad = root.GetGameObjects<Pad>()[0];
                this.position = new Vector2(pad.position.X, pad.collider.Y - offset.Y - 10f);
                if (Keyboard.GetState().IsKeyDown(Keys.Space))
                {
                    sticked = false;
                    this.direction = new Vector2(1, -1);
                }
            }
            else
            {
                Move(dt);
                checkCollisionWithObjects<Pad>();
                checkCollisionWithObjects<Brick>();

                BounceOnBounds();
                OutOfBounds();
            }
        }

        //TODO : methode de collision generique avec d'autres spriteGameObjects : <T>

        private void OutOfBounds()
        {
            //check si on est sous les limites de l'ecran
            if (position.Y > bounds.Bottom + 100f)
            {
                ServiceLocator.Get<GameController>().TakeDamage();
                sticked = true;
            }
        }

        private void checkCollisionWithObjects<T>() where T : SpriteGameObject
        {
            // fonction de la class Scene
            var objects = root.GetGameObjects<T>();

            foreach (SpriteGameObject obj in objects)
            {
                if (obj.Enable && obj.collider.Intersects(this.collider))
                {
                    // verification du sens de la collision
                    float deathX = Math.Min(this.collider.Right - obj.collider.Left, obj.collider.Right - this.collider.Left);
                    float deathY = Math.Min(this.collider.Bottom - obj.collider.Top, obj.collider.Bottom - this.collider.Top);

                    //check dou provient la collision
                    if (deathX < deathY)
                    {
                        // par la gauche
                        if (this.collider.Right > obj.collider.Left && this.collider.Left < obj.collider.Left)
                        {
                            this.position.X = obj.collider.Left - this.offset.X;
                            this.direction.X *= -1;
                        }
                        //par la droite
                        else if (this.collider.Left < obj.collider.Right && this.collider.Right > obj.collider.Right)
                        {
                            this.position.X = obj.collider.Right + this.offset.X;
                            this.direction.X *= -1;
                        }
                    }
                    else
                    {
                        //collision par le haut
                        if (this.collider.Bottom > obj.collider.Top && this.collider.Top < obj.collider.Top)
                        {
                            this.position.Y = obj.collider.Top - this.offset.Y;
                            this.direction.Y *= -1;
                        }
                        //par le bas
                        else if (this.collider.Top < obj.collider.Bottom && this.collider.Bottom > obj.collider.Bottom)
                        {
                            this.position.Y = obj.collider.Bottom + this.offset.Y;
                            this.direction.Y *= -1;
                        }
                    }
                    this.direction = Vector2.Normalize(this.direction);
                    obj.OnCollide(this);
                }
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
