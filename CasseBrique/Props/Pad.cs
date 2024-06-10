using CasseBrique.GameObjects;
using CasseBrique.Scenes;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Props
{
    internal class Pad : SpriteGameObject
    {
        private float speed;
        private Vector2 targetPosition;
        private Rectangle bounds;
        public Pad(Scene root, Rectangle bounds) : base(root)
        {
            texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("paddleBlu");
            this.offset = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
            this.bounds = bounds;
            this.targetPosition = new Vector2(bounds.Center.X, bounds.Bottom - texture.Height * .5f);
            this.position = targetPosition;
            this.speed = 800f;
        }

        public override void Update(float dt)
        {
            var keyboardinfo = Keyboard.GetState();
            if (keyboardinfo.IsKeyDown(Keys.Left))
                targetPosition.X -= speed * dt;
            if (keyboardinfo.IsKeyDown(Keys.Right))
                targetPosition.X += speed * dt;

            //blocage sur une certaine position
            targetPosition = Vector2.Clamp(targetPosition,
                                            new Vector2(bounds.Left + offset.X, position.Y),
                                            new Vector2(bounds.Right - offset.X, position.Y));

            //aspect smooth du deplacement
            position = Vector2.Lerp(position, targetPosition, .1f);

        }
    }
}
