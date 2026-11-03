using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Topic_4___Star_Class
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        Texture2D shipTexture;
        Texture2D starTexture;
        Rectangle window;
        Rectangle shipRect;
        Random generator;
        Vector2 shipSpeed;
        KeyboardState keyboardState;
        int shipState;

        Star star1;

        List<Star> stars;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            window = new Rectangle(0, 0, 800, 600);
            _graphics.PreferredBackBufferWidth = window.Width;
            _graphics.PreferredBackBufferHeight = window.Height;
            _graphics.ApplyChanges();

            generator = new Random();

            shipRect = new Rectangle(50, 250, 150, 40);
            
            shipState = 5;

            base.Initialize();

            int size;
            stars = new List<Star>();
            for (int i = 0; i < 150; i++)
            {
                size = generator.Next(1, 4);
                int x, y;
                x = generator.Next(window.Width);
                y = generator.Next(window.Height);
                Rectangle star = new Rectangle(x, y, size, size);
                stars.Add(new Star(starTexture, star, new Vector2(-2, 0)));
            }


            star1 = new Star(starTexture, new Rectangle(100, 100, 2, 2), new Vector2(-2, 0));

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            starTexture = Content.Load<Texture2D>("Images/circle (1)");
            shipTexture = Content.Load<Texture2D>("Images/enterprise");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            star1.Update();

            keyboardState = Keyboard.GetState();
            shipSpeed = Vector2.Zero;

            foreach (Star star in stars)
            {
                star.Update();
                if (star.Location.Right < 0)
                    star.X = window.Width;
            }

            if (keyboardState.IsKeyDown(Keys.W))
            {
                shipSpeed.Y -= shipState;
            }
            if (keyboardState.IsKeyDown(Keys.S))
            {
                shipSpeed.Y += shipState;
            }
            if (keyboardState.IsKeyDown(Keys.A))
            {
                shipSpeed.X -= shipState;
            }
            if (keyboardState.IsKeyDown(Keys.D))
            {
                shipSpeed.X += shipState;
            }



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            star1.Draw(_spriteBatch);

            foreach (var star in stars)
                star.Draw(_spriteBatch);

            _spriteBatch.Draw(shipTexture, shipRect, Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
