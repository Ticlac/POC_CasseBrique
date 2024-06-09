using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Scenes.Interfaces
{
    public interface IScenesManager
    {
        void LoadScene<T>() where T : Scene, new();
    }
}
