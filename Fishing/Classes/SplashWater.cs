using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using System.Diagnostics;
using Windows.Gaming.Input;

namespace Fishing.Classes
{
    internal class SplashWater
    {
        private Texture2D texture;
        private Vector2 position =new Vector2();
        private int currentFrame;//нынышний кадр
        private int countframes;//кол-во кадров
        private int widthFrame;//ширина
        private int heightFrame;//высота
        private bool loop;//зацикливание
        private float duration;//длительность в мс
        private float durationOneFrame;//задержка одного кадра
        private double totalduration;//итоговая задержка
        private Rectangle rectangle;
        private bool isVisible = false;

        public bool IsVisible { get { return isVisible; } set { isVisible = value; } }
        
        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SplashWater()
        {
            ConfigAnimation();
        }

        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("water");
        }
        public void Update(GameTime gameTime)
        {
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (isVisible)
            {
                if (capabilities.IsConnected)
                {
                    GamePad.SetVibration(PlayerIndex.One, 1f, 1f);
                }
                rectangle = new Rectangle(currentFrame * widthFrame, 0,
               widthFrame, heightFrame);

                totalduration += gameTime.ElapsedGameTime.TotalMilliseconds;

                if (totalduration >= durationOneFrame)
                {
                    currentFrame++;
                    totalduration = 0;
                }
            }

            // end animation and looping animation
            if (currentFrame == countframes)
            {
                if (capabilities.IsConnected)
                {
                    GamePad.SetVibration(PlayerIndex.One,0f,0f);
                }
                isVisible = false;
                ConfigAnimation();
            }
        }
        public void Draw(SpriteBatch spriteBatch)
        {
            if (isVisible)
            {
                spriteBatch.Draw(texture, position, rectangle, Color.White);
            }
        }
        private void ConfigAnimation()
        {
            currentFrame = 0;//нынышний кадр
            countframes = 8;//кол-во кадров
            widthFrame = 1055 / 8;//ширина
            heightFrame = 98;//высота
            loop = true;//зацикливание
            duration = 600;//длительность в мс     будет уменьшаться взависимости от сложности
            durationOneFrame = duration / countframes;//задержка одного кадра
            totalduration = 0;//итоговая задержка
        }
    }
}
