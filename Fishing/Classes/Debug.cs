using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;

namespace Fishing.Classes
{
    public static class Debug
    {
        public static Texture2D texture;


        public static void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("debug");
        }

        public static void Draw(SpriteBatch spriteBatch, Rectangle rectangle)
        {
            spriteBatch.Draw(texture, rectangle, null, Color.Red);
        }




    }
}
