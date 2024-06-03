using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Scenes
{
    public class SceneGame : Scene
    {
        private Ball ball;

        public override void Load()
        {
            this.ball = new Ball();
            base.Load();
        }
        public override void Update(float dt)
        {
            Debug.WriteLine("Update SceneGame");

            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                ball.Shoot(Vector2.One, 200f);


            ball.Update(dt);
            base.Update(dt);
        }
        public override void Draw(SpriteBatch sb)
        {
            ball.Draw(sb);
            base.Draw(sb);
        }
    }
}
