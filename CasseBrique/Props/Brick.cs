using CasseBrique.GameObjects;
using CasseBrique.Scenes;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Props
{
    public class Brick : SpriteGameObject
    {
        public Brick(Scene root, Vector2 position) : base(root, position)
        {
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("Brick");
            this.position = position;
        }

        public override void Update(float dt)
        {

        }
        public override void OnCollide(SpriteGameObject other)
        {
            this.Enable = false;
            this.isFree = true;
        }
    }
}
