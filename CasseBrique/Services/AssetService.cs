using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services
{
    public class AssetService
    {
        Dictionary<string, object> _assets = new Dictionary<string, object>();

        public AssetService()
        {
            ServiceLocator.Register<AssetService>(this);
        }

        public void Load<T>(string name) => _assets[name] = ServiceLocator.Get<ContentManager>().Load<T>(name);

        public T Get<T>(string name)
        {
            if (!_assets.ContainsKey(name))
                throw new InvalidOperationException($"AssetService : Asset {name} does not exist");
            return (T)_assets[name];
        }
    }
}
