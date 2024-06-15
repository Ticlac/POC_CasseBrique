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
using System.Data.Common;
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
            AddGameObject(new Ball(this, ServiceLocator.Get<IScreenService>().Bounds));
            //AddGameObject(new Brick(this, new Vector2(ServiceLocator.Get<IScreenService>().Width * 0.5f + 20, 10)));
            addBricks(ServiceLocator.Get<IScreenService>().Bounds);

        }

        public override void Update(float dt)
        {
            int brickCount = GetGameObjects<Brick>().Count;
            if(brickCount == 0)
            {
                ServiceLocator.Get<GameController>().NextLevel();
                ServiceLocator.Get<IScenesManager>().LoadScene<SceneGame>();
            }
            base.Update(dt);
        }


        private void addBricks(Rectangle bounds)
        {
            int[,] bricksLevel = ServiceLocator.Get<GameController>().getBricksLevel();
            var brickTexture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("Brick");

            int rows = bricksLevel.GetLength(0);
            int columns = bricksLevel.GetLength(1);

            float spaceBetweenBricks = 10f;
            float verticalOffset = 10f;

            float totalWidth = columns * (brickTexture.Width + spaceBetweenBricks) - spaceBetweenBricks;
            //centrage
            float offsetX = (bounds.Width - totalWidth) * 0.5f;

            for (int row = 0; row < rows; row++)
            {
                for (int column = 0; column < columns; column++)
                {
                    if (Convert.ToInt16(bricksLevel[row, column]) == 0) continue; 

                    float x = bounds.X + offsetX + column * (brickTexture.Width + spaceBetweenBricks);
                    float y = bounds.Y + verticalOffset + row * (brickTexture.Height + spaceBetweenBricks);

                    if (Convert.ToInt16(bricksLevel[row, column]) == 1)
                    {
                        Brick brick = new Brick(this, new Vector2(x, y));
                        AddGameObject(brick);
                    }
                    else if (Convert.ToInt16(bricksLevel[row, column]) == 2)
                    {
                        HardBrick brick = new HardBrick(this, new Vector2(x, y));
                        AddGameObject(brick);
                    }
                }

            }
        }


        private void CreateBalls(int amount, Rectangle bounds)
        {
            for (int i = 0; i < amount; i++)
                CreateBall(bounds);
        }

        private void CreateBall(Rectangle bounds)
        {
            var ball = new Ball(this, bounds);
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
