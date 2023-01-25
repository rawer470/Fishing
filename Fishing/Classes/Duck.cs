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
    class Duck 
    {
        private Vector2 position;
        private Texture2D texture;
        private int speed = 1;
        private int side = 1;


        public Duck()
        {
            position.Y += 75;
        }


        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("Duck");
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (side == 1)
            {
                SpriteEffects effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);
            }
            else
            {
                SpriteEffects effects = SpriteEffects.None;
                spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);
            }
        }

        public void Update()
        {
            if (side == 1)
            {
                position.X += speed;

            }
            else
            {
                position.X -= speed;
            }


            if (position.X <= -200)
            {
                side = 1;
                

            }

            if (position.X >= 1320)
            {
                side = 2;
                
            }
        }






    }
}
