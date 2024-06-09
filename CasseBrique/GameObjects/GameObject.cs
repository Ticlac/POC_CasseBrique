using CasseBrique.Scenes;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.GameObjects
{
    public abstract class GameObject
    {
        private bool enable;
        public bool isFree { get; set; }
        public Scene root { get; private set; }
        public bool Enable { 
            get { return enable;} 
            set {
                if (enable != value)
                {
                    enable = value;
                    if (enable) OnEnable();
                    else OnDisable();
                }
            }
        }

        public GameObject(bool enable, Scene root)
        {
            this.enable = enable;
            this.root = root;
        }

        public virtual void Update(float dt)
        {

        }
        public virtual void Draw(SpriteBatch sb)
        {

        }

        protected virtual void OnEnable() { }
        protected virtual void OnDisable() { }
        public virtual void Start() { }
        public virtual void OnFree() { }
    }
}
