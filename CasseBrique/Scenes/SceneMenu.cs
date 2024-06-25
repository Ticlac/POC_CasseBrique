using CasseBrique.Props;
using CasseBrique.Scenes.Interfaces;
using CasseBrique.Services;
using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework;
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
        public override void Load()
        {
            AddGameObject(new Button(this, SceneType.GAME, "Start game", ServiceLocator.Get<IScreenService>().Center));
            AddGameObject(new Button(this, SceneType.EXIT, "Quit game", ServiceLocator.Get<IScreenService>().Center + new Vector2(0,100)));
        }
    }
}
