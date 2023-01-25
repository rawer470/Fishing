using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Fishing.Classes
{
    class Win
    {
        private SpriteFont font;
        private int second;
        private Color color;
        private bool win = false;
        private int itogsecond;
        private Vector2 position = Vector2.Zero;
        private string text;
        private int score; 

        public int Score
        {
            get { return score; }
            set { score = value; }
        }

        public Color Color
        {
            get { return color; }
            set { color = value; }
        }

        public string Text
        {
            get { return text; }
            set { text = value; }
        }

        public float X
        {
            get { return position.X; }
            set { position.X = value; }
        }

        public float Y
        {
            get { return position.Y; }
            set { position.Y = value; }
        }

        public Vector2 Size
        {
            get { return font.MeasureString(text); }
        }

        public Win()
        {
            position = new Vector2();
            text = "label1";
            color = Color.Red;
        }

        public Win(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("gameFont");
        }

        public void Update(GameTime time,bool win)
        {
            this.win = win;
            second = (int)time.TotalGameTime.TotalSeconds;
            if (!win)
            {
                itogsecond = second;
                text = second.ToString();
            }
            else
            {
                text = "WIN" + '\n' + itogsecond;
                position.X = 600;
                position.Y = 400;
            }
          
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}
