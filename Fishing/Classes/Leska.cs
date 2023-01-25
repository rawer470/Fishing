
using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Fishing.Classes;
namespace Fishing.Classes
{
    class Leska
    {
        private Vector2 position;
        private Vector2 Fispos;
        public static bool start=false;
        private Texture2D texture;
        private Rectangle rectangle;
        private int length = 0;
        private bool leskaup = false;
        private bool isVisible;
        private bool leskadown = false;
        private bool loop = false;
        private Hook hook = new Hook();
        public Hook Hook { get { return hook; } set { hook = value; } }
        public Rectangle Rectangle
        {
            get { return rectangle; }
            set { rectangle = value; }
        }
        public bool Leskaup { get { return leskaup; } set { leskaup = value; } }
        public bool Leskadown { get { return leskadown; } set { leskadown = value; } }
        public bool IsVisible
        {
            get
            {
                return isVisible;
            }
            set
            {
                isVisible = value;
            }
        }
        public bool Loop
        {
            get { return loop; }
        }
        public Leska(Fisher fisher)
        {
            rectangle = new Rectangle((int)fisher.Position.X + 250, (int)fisher.Position.Y + 200, 10, 10);
            Hook.Position = new Vector2(rectangle.X, rectangle.Y + rectangle.Height - 5);
            //Debug.rectangles.Add(rectangle);
        }
        public void LoadContent(ContentManager manager)
        {
            texture = manager.Load<Texture2D>("leska");
        }
        public void Update(Fisher fisher)
        {
            KeyboardState keyboard = Keyboard.GetState();
            
            hook.Position = new Vector2(rectangle.X, rectangle.Y + rectangle.Height - 5);
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);
                if (state.IsButtonUp(Buttons.A))
                {
                    start = true;
                }
                if (state.IsButtonDown(Buttons.A) && !leskaup && start)
                {
                    loop = true;
                    leskadown = true;
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Space) && !leskaup)
                {
                    loop = true;
                    leskadown = true;
                }
            }

            if (leskadown == true)
            {
                length += 5;
                if (length >= 790)
                {
                    leskadown = false;
                    leskaup = true;
                }
            }
            if (leskadown == false && leskaup)
            {
                length -= 5;
                if (length <= 50 && loop)
                {
                    loop = false;
                    leskadown = false;
                    leskaup = false;
                }
            }
            Fispos = fisher.Position;
        
        }
        public void Draw(SpriteBatch sprite)
        {
            //sprite.Draw(texture, position, rectangle,Color.White);
            Vector2 targetLink = new Vector2(Fispos.X + 345, Fispos.Y + 50);
            rectangle = new Rectangle((int)targetLink.X, (int)targetLink.Y, 3, length);
            sprite.Draw(texture, rectangle, null, Color.White);

            //Debug.Draw(sprite, rectangle);
        }
    }
}
