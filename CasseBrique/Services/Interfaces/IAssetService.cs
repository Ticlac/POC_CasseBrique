using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services.Interfaces
{
    public interface IAssetService
    {
        public T Get<T>(string name);
    }
}
