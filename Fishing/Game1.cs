using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using Fishing.Classes;

namespace Fishing
{
    public enum GameType { Win, Game, Info, Menu };
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private int scor;
        private Back back = new Back();
        SplashWater splash = new SplashWater();
        private Fisher fisher = new Fisher();
        public static GameType gameType = GameType.Menu;
        private Leska leska;
        private Win win = new Win();
        private Hook hook;
        private bool onhook = false;
        private GamePadState state;
        private List<Fish> fishs = new List<Fish>();
        Menu menu = new Menu();
        SpriteFont font;
        //Degen degen = new Degen();
        private string infoText = "Developers:  Danya Utin, Artem Kolerov";
        Label label;
        Duck duck = new Duck();
     
        private int numberF = 5;
        private int numitog;



        public Game1()
        {
            label = new Label(infoText,new Vector2(250,400),Color.Yellow);
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            leska = new Leska(fisher);
            numitog = numberF * 2;
            hook = new Hook();
            _graphics.PreferredBackBufferWidth = 1200;
            _graphics.PreferredBackBufferHeight = 800;
            _graphics.ApplyChanges();
            base.Initialize();
        }
        protected override void Initialize()
        {
            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            label.LoadContent(Content);
            splash.LoadContent(Content);
            menu.LoadContent(Content);
            fisher.LoadContent(Content);
            leska.LoadContent(Content);
            win.LoadContent(Content);
            back.LoadContent(Content);
            win.LoadContent(Content);
            hook.LoadContent(Content);
            
            //degen.LoadContent(Content)
             font = Content.Load<SpriteFont>("gameFont");
            duck.LoadContent(Content);
            for (int i = 0; i < numberF; i++)
            {
                Fish fish = new Fish();
                fish.LoadContent(Content);
                fishs.Add(fish);
            }
            Debug.LoadContent(Content);
        }
        protected override void Update(GameTime gameTime)
        {
            KeyboardState keyboard = new KeyboardState();
            keyboard = Keyboard.GetState();
            //  if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            //     Exit();
            GamePadCapabilities capabilities = GamePad.GetCapabilities(PlayerIndex.One);
           state = GamePad.GetState(PlayerIndex.One);
            if (capabilities.IsConnected)
            {
               
                if (state.IsButtonDown(Buttons.Start))
                {
                    Game1.gameType = GameType.Menu;
                }
            }
            else
            {
                if (keyboard.IsKeyDown(Keys.Escape))
                {
                    Game1.gameType = GameType.Menu;
                }
            }
            switch (gameType)
            {
                case GameType.Win:
                    win.Update(gameTime, true);
                    break;
                case GameType.Game:
                    UpdateGame(gameTime);
                    break;
                case GameType.Menu:
                    menu.Update();
                    break;
            }
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            _spriteBatch.Begin();


            switch (gameType)
            {
                case GameType.Win:
                    back.Draw(_spriteBatch);
                    win.Draw(_spriteBatch);
                    break;
                case GameType.Game:
                    DrawGame();
                    break;
                case GameType.Menu:
                    back.Draw(_spriteBatch);
                    menu.Draw(_spriteBatch);
                    break;
                case GameType.Info:
                    back.Draw(_spriteBatch);
                   label.Draw(_spriteBatch,true);
                    if (state.IsButtonDown(Buttons.B))
                    {
                        gameType = GameType.Menu;       
                    }
                    break;
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
        public void UpdateGame(GameTime gameTime)
        {
            splash.Update(gameTime);
            UpdateColision();
            ManagerFish();
            for (int i = 0; i < fishs.Count; i++)
            {
                fishs[i].Update(hook, leska);
            }
            fisher.Update(leska);
            leska.Update(fisher);
            hook.Position = leska.Hook.Position;
            win.Update(gameTime, false);
            hook.Update();

            duck.Update();

            //degen.Update();
        }
        public void DrawGame()
        {
            back.Draw(_spriteBatch);
            splash.Draw(_spriteBatch);
            fisher.Draw(_spriteBatch);
            hook.Draw(_spriteBatch);
            for (int i = 0; i < fishs.Count; i++)
            {
                fishs[i].Draw(_spriteBatch);
            }
            win.Draw(_spriteBatch);
            leska.Draw(_spriteBatch);
            duck.Draw(_spriteBatch);
            //degen.Draw(_spriteBatch);
        }
        public void ManagerFish()
        {
            for (int i = 0; i < fishs.Count; i++)
            {
                if (fishs[i].Position.Y <= 230)
                {
                    splash.Position = new Vector2(fisher.Position.X + fisher.Texture.Width - 90, fisher.Position.Y + fisher.Texture.Height - 100);
                    splash.IsVisible = true;
                    fishs[i].cotch = true;
                    hook.Onhook = false;
                }
                if (fishs[i].cotch)
                {
                    fishs.Remove(fishs[i]);
                    numitog--;
                    if (fishs.Count == 0)
                    {
                        gameType = GameType.Win;
                    }
                }
            }
        }
        public void UpdateColision()
        {
            for (int i = 0; i < fishs.Count; i++)
            {
                if (fishs[i].Rectangle.Intersects(hook.Rectangle))
                {


                    if (leska.Leskaup &&!hook.Onhook)
                    {
                        leska.Leskaup = true;
                        leska.Leskadown = false;
                        fishs[i].onhook = true;
                        hook.Onhook = true;
                    }
                    if (leska.Leskadown)
                    {
                        leska.Leskaup = true;
                        leska.Leskadown = false;
                        fishs[i].onhook = true;
                        hook.Onhook = true;
                    }
                    
                    //fishs.Remove(fishs[i]);


                }
            }
        }
    }
}