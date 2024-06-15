using CasseBrique.GameObjects;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Scenes
{
    public abstract class Scene
    {
        private List<GameObject> gameObjects = new List<GameObject>();
        public virtual void Load() { }

        public virtual void Unload() { }

        public virtual void Update(float dt)
        {
            foreach(var obj in gameObjects)
                if (obj.Enable)
                    obj.Update(dt);


            for (int i = gameObjects.Count - 1; i >= 0; i--)
            {
                if (gameObjects[i].isFree)
                {
                    gameObjects[i].OnFree();
                    gameObjects.RemoveAt(i);
                }
            }

        }
        public void Draw(SpriteBatch sb)
        {
            foreach (var obj in gameObjects)
            {
                if (obj.Enable)
                    obj.Draw(sb);
            }
        }

        public void AddGameObject(GameObject obj)
        {
            obj.Start();
            gameObjects.Add(obj);
        }

        public List<T> GetGameObjects<T>()
        {
            var returnGameObjects = new List<T>();

            foreach (GameObject gameObject in gameObjects)
                // si gameobject est de type T ==> typedGameObject = T
                if (gameObject is T typedGameObject)
                    returnGameObjects.Add(typedGameObject);

            return returnGameObjects;
        }

    }
}
