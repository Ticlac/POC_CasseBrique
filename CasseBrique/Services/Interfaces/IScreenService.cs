using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services.Interfaces
{
    public interface IScreenService
    {
        //Semi constantes
        int Width { get; }
        int Height { get; }
        int Top { get; }
        int Left { get; }
        Vector2 TopLeft { get; }
        Vector2 BotRight { get; }
        Vector2 Center { get; }
        Rectangle Bounds {get;}

    }
}
