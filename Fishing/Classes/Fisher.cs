using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
namespace Fishing.Classes
{
    class Fisher
    {
        private Vector2 position;

        private Texture2D texture;
        private Rectangle rectangle;
        private bool isVisible;
        private int speed;
        private int score;
        

        public int Score
        {
            get { return score; }
            set { score = value; }
        }
        public Texture2D Texture
        {
            get { return texture; }

        }
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }
        public Rectangle Rectangle
        {
            get; set;
        }



        public Fisher()
        {
            position = new Vector2(0, 75);
            isVisible = true;
            speed = 3;
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("fisher");
        }
        public void Update(Leska leska)
        {
            KeyboardState keyboard = Keyboard.GetState();
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);

                if (capabilities.HasLeftXThumbStick)
                {
                    // Check teh direction in X axis of left analog 

                    if (state.ThumbSticks.Left.X < -0.5f && leska.Loop == false)
                        position.X -= speed;
                    if (state.ThumbSticks.Left.X > 0.5f && leska.Loop == false)
                        position.X += speed;
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Right) && leska.Loop == false)
                {
                    position.X += speed;
                }
                if (keyboard.IsKeyDown(Keys.Left) && leska.Loop == false)
                {
                    position.X -= speed;
                }
            }


            if (position.X <= 0)
            {
                position.X = 0;
            }
            if (position.X + texture.Width >= 1200)
            {
                position.X = 1200 - texture.Width;
            }
        }
        public void Draw(SpriteBatch sprite)
        {
            sprite.Draw(texture, position, Color.White);
        }
    }
}
