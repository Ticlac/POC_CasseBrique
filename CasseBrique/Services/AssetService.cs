using CasseBrique.Services.Interfaces;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services
{
    public class AssetService : IAssetService
    {
        Dictionary<string, object> _assets = new Dictionary<string, object>();
        private ContentManager contentManager;

        public AssetService(ContentManager contentManager)
        {
            this.contentManager = contentManager;
            ServiceLocator.Register<IAssetService>(this);
        }

        public void Load<T>(string name) 
        {
            if (_assets.ContainsKey(name))
                throw new InvalidOperationException($"AssetService : Asset {name} already loaded");
            _assets[name] = this.contentManager.Load<T>(name); 
        }

        public T Get<T>(string name)
        {
            if (!_assets.ContainsKey(name))
                throw new InvalidOperationException($"AssetService : Asset {name} does not exist");
            return (T)_assets[name];
        }
    }
}
