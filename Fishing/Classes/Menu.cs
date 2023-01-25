using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Fishing.Classes;


namespace Fishing.Classes
{
    internal class Menu
    {
        private List<Label> items;
        private string[] texts = { "Play", "Info", "Exit" };
        private Color color;
        private Color colorSelected;

        private int selected = 0;
        private KeyboardState keyboard; // состояние клавиатуры в данный момент
        private KeyboardState prevKeyboard;  // прошлое состояние клавиатуры
        private bool down = false;
        private bool up = false;
        private bool non = false;
        private Vector2 position;


        public Menu()
        {
            items = new List<Label>();
            color = Color.White;
            colorSelected = Color.Red;

            Vector2 item_position = position;

            for (int i = 0; i < texts.Length; i++)
            {
                Label label = new Label(texts[i], item_position, color);

                items.Add(label);

                item_position.Y += 100;
            }
        }


        public void LoadContent(ContentManager manager)
        {
            foreach (var item in items)
            {
                item.LoadContent(manager);
                item.X = 1170 / 2 - item.Size.X / 2;
                item.Y = item.Y + item.Size.Y + 200 / 2;

            }
        }
        public void Update()
        {
           Leska.start = false;
            keyboard = Keyboard.GetState();

            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
                GamePadState state = GamePad.GetState(PlayerIndex.One);



                if (state.IsButtonDown(Buttons.DPadDown)&&(!down || non))  //Down
                {

                    if (selected < items.Count - 1)
                    {
                        items[selected].Color = color;
                        selected++;
                    }
                    else
                    {
                        items[selected].Color = color;
                        selected = 0;
                    }
                    down = true;
                    up = false;
                    non = false;
                }


                if (state.IsButtonDown(Buttons.DPadUp)&&(!up || non))  //Up
                {
                    if (selected > 0)
                    {
                        items[selected].Color = color;
                        selected--;
                    }
                    down = false;
                    up = true;
                    non = false;
                }
                if (state.IsButtonUp(Buttons.DPadUp) && state.IsButtonUp(Buttons.DPadDown))
                {
                    non = true;
                }
                if (state.IsButtonDown(Buttons.A))
                {
                    if (items[selected].Text == "Play")
                    {
                        Game1.gameType = GameType.Game;
                    }
                    else if (items[selected].Text == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (items[selected].Text == "Info")
                    {
                        Game1.gameType = GameType.Info;

                    }
                }


            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Down) && (keyboard != prevKeyboard))
                {
                    if (selected < items.Count - 1)
                    {
                        items[selected].Color = color;
                        selected++;
                    }
                    else
                    {
                        items[selected].Color = color;
                        selected = 0;
                    }
                }

                // Up
                if (keyboard.IsKeyDown(Keys.Up) && (keyboard != prevKeyboard))
                {
                    if (selected > 0)
                    {
                        items[selected].Color = color;
                        selected--;
                    }
                }


                if (keyboard.IsKeyDown(Keys.Enter))
                {
                    if (items[selected].Text == "Play")
                    {
                        Game1.gameType = GameType.Game;
                    }
                    else if (items[selected].Text == "Exit")
                    {
                        Environment.Exit(0);
                    }
                    else if (items[selected].Text == "Info")
                    {
                        Game1.gameType = GameType.Info;

                    }
                }
                prevKeyboard = keyboard;
            }
            // Down

        }
        public void Draw(SpriteBatch spriteBatch)
        {
            items[selected].Color = colorSelected;
            items.ForEach(item => item.Draw(spriteBatch));
        }
    }
}
