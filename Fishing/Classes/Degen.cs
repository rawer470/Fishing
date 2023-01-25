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
    class Degen  : Fish
    {
        private Vector2 position;
        private Texture2D texture;
        private Rectangle rectangle;
        private int speed = 2;
        private int side = 1;


        public Degen()
        {
            position.Y += 600;
        }


        public override void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("Danechka");
        }

        public  void Update()
        {
            rectangle = new Rectangle((int)position.X,
              (int)position.Y, texture.Width, texture.Height);

            Random random = new Random();

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
                speed = random.Next(2, 4);
                position.Y += 30;

            }

            if (position.X >= 1320)
            {
                side = 2;
                speed = random.Next(2, 4);
                position.Y -= 30;
            }

           
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            if (side == 1 && !cotch)
            {
                SpriteEffects effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture, position, null, Color.White, povorot, Vector2.Zero, 1f, effects, 1f);
            }
            else if (side == 2 && !cotch)
            {
                SpriteEffects effects = SpriteEffects.None;
                spriteBatch.Draw(texture, position, null, Color.White, povorot, Vector2.Zero, 1f, effects, 1f);
            }
        }


    }
}
