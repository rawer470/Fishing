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
    class Fish
    {
        protected Vector2 position;
        protected Texture2D texture;
        protected int speed;
        // protected bool isVisible = true;
        protected Rectangle rectangle;
        protected int site;
        protected int side;
        protected int numtexture;
        protected int rar;
        protected int rer;
        public bool cotch;
        public bool onhook = false;
        private bool correct = false;
        protected float povorot = 0;
        private SpriteEffects effects;

        public Rectangle Rectangle
        {
            get
            {
                return rectangle;
            }
        }
        public Vector2 Position { get { return position; } }
        public int Width
        {
            get
            {
                return rectangle.Width;
            }
        }

        public int Hight
        {
            get
            {
                return rectangle.Height;
            }
        }

        /*  public bool IsVisible
          {
              get
              {
                  return isVisible;       без этого работает но рыбы всё равно пропадают (магия никак иначе)
              }
              set
              {
                  isVisible = value;
              }

          }*/


        public Fish()
        {
            Random random = new Random();
            speed = random.Next(2, 5);
            site = random.Next(1, 3);
            side = random.Next(1, 3);
            numtexture = random.Next(1, 5);
            rar = random.Next(6632, 7633);
            rer = random.Next(0, 101);
            if (site == 1)
            {
                this.position.X = random.Next(200, 400);
            }
            else
            {
                this.position.X = random.Next(600, 800);
            }
            this.position.Y = random.Next(400, 730);
        }


        public virtual void LoadContent(ContentManager manager)
        {
            if (numtexture == 1)
            {
                texture = manager.Load<Texture2D>("Fish Black");
            }
            else if (numtexture == 2)
            {
                texture = manager.Load<Texture2D>("Fish Grey");
            }
            else if (numtexture == 3)
            {
                texture = manager.Load<Texture2D>("Fish orange");
            }
            else if (numtexture == 4)
            {
                texture = manager.Load<Texture2D>("Fish White");
            }
            else if (rar == 7632)
            {
                texture = manager.Load<Texture2D>("Sapog");
            }
            else if (rer == 42)
            {
                texture = manager.Load<Texture2D>("Danechka");
            }
        }
        public virtual void Draw(SpriteBatch spriteBatch)
        {
            //  Debug.Draw(spriteBatch, rectangle);
            if (side == 1 && !cotch)
            {
                effects = SpriteEffects.FlipHorizontally;
                spriteBatch.Draw(texture, position, null, Color.White, povorot, Vector2.Zero, 1f, effects, 1f);
            }
            else if (side == 2 && !cotch)
            {
                effects = SpriteEffects.None;
                spriteBatch.Draw(texture, position, null, Color.White, povorot, Vector2.Zero, 1f, effects, 1f);
            }
            //SpriteEffects effects = SpriteEffects.FlipHorizontally;
            //spriteBatch.Draw(texture, position, null, Color.White, 0f, Vector2.Zero, 1f, effects, 1f);
        }
        public virtual void Update(Hook hook,Leska leska)
        {

            Random random = new Random();
            if (onhook)
            {
                if (!correct)
                {
                    if (side == 1)
                    {
                        position.Y += texture.Height+20;
                        position.X = hook.Position.X - 20;
                    }
                    else
                    {
                   
                        position.X = hook.Position.X + 45;
                    }

                    correct = true;
                }

                rectangle = new Rectangle();
                speed = 0;
                if (side == 1)
                {
                    povorot = -1.57f;
                }
                else
                {
                    povorot = 1.57f;
                }

                if (position.Y >= 100)
                {
                    position.Y -= 5;
                }
                else
                {
                    cotch = true;
                }
            }
            if (!onhook)
            {
                rectangle = new Rectangle((int)position.X,
               (int)position.Y, texture.Width, texture.Height);
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
        }
    }
}
