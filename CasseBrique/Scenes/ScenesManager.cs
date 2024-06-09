using CasseBrique.Scenes.Interfaces;
using CasseBrique.Services;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CasseBrique.Scenes
{
    public sealed class ScenesManager : IScenesManager
    {
        private Scene currentScene;

        public ScenesManager()
        {
            ServiceLocator.Register<IScenesManager>(this);
        }

        public void LoadScene<T>() where T : Scene, new()
        {
            var type = typeof(T);
            if (currentScene != null)
                currentScene.Unload();

            currentScene = new T();
            currentScene.Load();
        }

        public void Update(float dt) =>  currentScene?.Update(dt);
        public void Draw(SpriteBatch sb) => currentScene?.Draw(sb);
    }
}
