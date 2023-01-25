
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
    class Back
    {
        public Vector2 position;
        public Texture2D texture;


        public Back()
        {

        }


        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("Back");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, Color.White);
        }

        public void Update()
        {

        }
    }
}
