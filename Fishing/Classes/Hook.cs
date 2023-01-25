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
    class Hook
    {
        public Vector2 Position { get; set; } = new Vector2();
        private Rectangle rectangle = new Rectangle();
        private Texture2D texture;
        private bool onhook = false;

        public bool Onhook { get { return onhook; } set { onhook = value; } }
        
        public Rectangle Rectangle { get { return rectangle; } set { rectangle = value; } }
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("hook");
        }
        public void Update()
        {
            
            rectangle = new Rectangle((int)Position.X,
                            (int)Position.Y, texture.Width, texture.Height);
        }
        public void Draw(SpriteBatch sprite)
        {
          //  Debug.Draw(sprite, rectangle);
            sprite.Draw(texture,Position,Color.White);
        }
    }
}
