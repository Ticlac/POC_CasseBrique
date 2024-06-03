using CasseBrique.Services;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace CasseBrique.Scenes
{
    public class ScenesManager
    {
        private Scene currentScene;
        private Dictionary<string, Scene> scenes = new Dictionary<string, Scene>();

        public ScenesManager()
        {
            ServiceLocator.Register<ScenesManager>(this);
        }

        public void RegisterScene(string sceneName, Scene scene)
        {
            if(scenes.ContainsKey(sceneName))
                throw new InvalidOperationException($"ScenesManager : {sceneName} already registered");
            scenes[sceneName] = scene;
        }
        public void LoadScene(string sceneName)
        {
            if (!scenes.ContainsKey(sceneName))
                throw new InvalidOperationException($"ScenesManager : {sceneName} not registered");
            if (currentScene != null)
                currentScene.Unload();
            currentScene = scenes[sceneName];
            currentScene.Load();
        }

        public void Update(float dt)
        {
            if (currentScene != null)
                currentScene.Update(dt);
        }
        public void Draw(SpriteBatch sb)
        {
            if (currentScene != null)
                currentScene.Draw(sb);
        }

        public virtual void Unload()
        {

        }

    }
}
