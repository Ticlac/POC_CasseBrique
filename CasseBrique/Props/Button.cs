using CasseBrique.GameObjects;
using CasseBrique.Scenes;
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
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Props
{
    public enum SceneType
    {
        MENU,
        GAME,
        VICTORY,
        OVER
    }
    public class Button : SpriteGameObject
    {

        private string text;
        private SceneType destScene;
        public Button(Scene root, SceneType destScene, string text, Vector2 position) : base(root, position)
        {
            this.position = position;
            this.destScene = destScene;
            this.texture = ServiceLocator.Get<IAssetService>().Get<Texture2D>("RectangleButton");
            this.text = text;
        }

        private void CheckOnClick()
        {
            // si click du bouton dans un rectangle contenant :
            // changement de scène
            if(InputManager.LeftClicked)
            {
                Debug.WriteLine("leftPressed " + DateTime.Now);
                if(InputManager.Hover(this.collider))
                    switch (this.destScene)
                    {
                        case SceneType.MENU:
                            ServiceLocator.Get<IScenesManager>().LoadScene<SceneMenu>();
                            break;
                        case SceneType.GAME:
                            ServiceLocator.Get<IScenesManager>().LoadScene<SceneGame>();
                            break;
                        case SceneType.VICTORY:
                            ServiceLocator.Get<IScenesManager>().LoadScene<SceneGame>();
                            break;
                        case SceneType.OVER:
                            ServiceLocator.Get<IScenesManager>().LoadScene<SceneDefaite>();
                            break;

                        default:
                            break;

                    }
            }

        }

        public override void Update(float dt)
        {
            CheckOnClick();
            base.Update(dt);
        }
    }
}
