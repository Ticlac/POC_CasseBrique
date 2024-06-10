using CasseBrique.GameObjects;
using CasseBrique.Props;
using CasseBrique.Scenes.Interfaces;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
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
        private Random random = new Random();
        public override void Load()
        {
            //AddGameObject(new Ball(this, Vector2.One, ServiceLocator.Get<IScreenService>().Bounds));
            //CreateBalls(100, ServiceLocator.Get<IScreenService>().Bounds);

            AddGameObject(new Pad(this, ServiceLocator.Get<IScreenService>().Bounds));
        }

        private void CreateBalls(int amount, Rectangle bounds)
        {
            for (int i = 0; i < amount; i++)
                CreateBall(bounds);
        }

        private void CreateBall(Rectangle bounds)
        {
            var ball = new Ball(this, getRandomDirection(), bounds);
            ball.position = getRandomPosition(bounds);
            AddGameObject(ball);
        }

        private Vector2 getRandomDirection()
        {
            // random entre -1;1
            float x = (float)(random.NextDouble() * 2 - 1);
            float y = (float)(random.NextDouble() * 2 - 1);
            Vector2 direction = new Vector2(x, y);
            return Vector2.Normalize(direction); 
        }
        private Vector2 getRandomPosition(Rectangle bounds)
        {
            
            float x = (float)(bounds.Left + random.NextDouble() * bounds.Width);
            float y = (float)(bounds.Top + random.NextDouble() * bounds.Height);
            return new Vector2(x, y);
        }

    }
}
