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
    public class HardBrick : Brick
    {
        public HardBrick(Scene root, Vector2 position) : base(root, position)
        {
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("RedBrick");
            this.damageToBreak = 2;
        }

        public override void OnCollide(SpriteGameObject other)
        {
            this.damageToBreak--;
            if (this.damageToBreak <= 0)
            {
                this.Enable = false;
                this.isFree = true;
                Bonus bonus = new Bonus(root, this.position);

                ServiceLocator.Get<GameController>().SetBonus(bonus);
            }
        }
    }
}
