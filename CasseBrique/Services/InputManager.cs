﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CasseBrique.Services
{
    public static class InputManager
    {
        public static bool LeftClicked = false;

        private static MouseState ms = new MouseState(), oms;

        public static void Update()
        {
            oms = ms;
            ms = Mouse.GetState();
            LeftClicked = ms.LeftButton != ButtonState.Pressed && oms.LeftButton == ButtonState.Pressed;
            // true On left release like Windows buttons
        }
        public static bool Hover(Rectangle r)
        {
            return r.Contains(new Vector2(ms.X, ms.Y));
        }
    }
}
