using CasseBrique.GameObjects;
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
        public override void Load()
        {
            AddGameObject(new Ball(this, Vector2.One, ServiceLocator.Get<IScreenService>().Bounds));
        }
    }
}
