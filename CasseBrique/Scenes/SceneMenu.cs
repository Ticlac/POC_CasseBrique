using CasseBrique.Scenes.Interfaces;
using CasseBrique.Services;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Scenes
{
    public class SceneMenu : Scene
    {
        public override void Update(float dt)
        {
            Debug.WriteLine("Update Scene Menu");
            if (Keyboard.GetState().IsKeyDown(Keys.Enter))
                ServiceLocator.Get<IScenesManager>().LoadScene("Game");

            base.Update(dt);
        }
    }
}
