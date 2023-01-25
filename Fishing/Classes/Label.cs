using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Fishing.Classes
{
    internal class Label
    {
        private SpriteFont font;
        private SpriteFont spriteFont;
        private Color color;
        private Vector2 position;
        private string text;

        public SpriteFont Font { get { return font; } }
        public SpriteFont SpriteFont { get { return spriteFont; } }
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

        public Label()
        {
            position = new Vector2();
            text = "label1";
            color = Color.White;
        }

        public Label(string text, Vector2 position, Color color)
        {
            this.text = text;
            this.position = position;
            this.color = color;
        }

        public void LoadContent(ContentManager content)
        {
            font = content.Load<SpriteFont>("MenuFont");
            spriteFont = content.Load<SpriteFont>("InfoFont");
        }

         public void Draw(SpriteBatch spriteBatch,bool a)
        {
            spriteBatch.DrawString(spriteFont, text, position, color);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawString(font, text, position, color);
        }
    }
}
