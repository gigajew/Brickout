using Brickout.Core;
using Brickout.Core.Entities;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

/* 
 * Created by gigajew (c) 2021
 */

namespace Brickout
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        public GraphicsDeviceManager graphics;
        public SpriteBatch spriteBatch;

        private List<Entity> entities = new List<Entity>();
        private List<Brick> bricks = new List<Brick>();

        private Ball ball;
        private Paddle paddle;
        public Random random = new Random(Guid.NewGuid().GetHashCode());

        public const int bounce_speed = 4;

        public GameState CurrentGameState = GameState.Paused; 

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            graphics.IsFullScreen = false;
            graphics.PreferredBackBufferHeight = 340;
            graphics.PreferredBackBufferWidth = 610;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            //entities.Add(new Ball(this));
            //entities.Add(new Paddle(this));

            ball = new Ball(this);
            ball.Width = 6;
            ball.Height = 6;
            ball.ResetDirection(bounce_speed);
            ball.Reset();

            paddle = new Paddle(this);
            paddle.Width = 50;
            paddle.Height = 10;
            paddle.Reset();

            Components.Add(ball);
            Components.Add(paddle);

            CreateBricks();
        }

        /// <summary>
        /// Used to create a bunch of bricks
        /// </summary>
        private void CreateBricks()
        {
            Viewport viewport = GraphicsDevice.Viewport;
            int rows = 6;
            int brickWidth = 50;
            int brickHeight = 20;


            // columns
            for (int i = 0; i < (viewport.Width / brickWidth); i++)
            {
                // rows
                for (int j = 1; j < 6 + 1; j++)
                {
                    Brick brick = new Brick(this);
                    brick.Width = brickWidth; brick.Height = brickHeight;
                    brick.Position.X = i * brickWidth + i;
                    brick.Position.Y = j * brickHeight + j;
                    bricks.Add(brick);
                }
            }


            foreach (var brick in bricks)
            {
                Components.Add(brick);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            if( CurrentGameState == GameState.Paused )
            {
                if( Mouse.GetState().LeftButton == ButtonState.Pressed )
                {
                    CurrentGameState = GameState.Playing;
                }

                base.Update(gameTime);
                return; 
            }

            // TODO: Add your update logic here
            foreach (var entity in entities)
            {
                entity.Update(gameTime);
            }

            for (int i =0; i < bricks.Count; i ++)
            {
                if (ball.Colliding(bricks[i]))
                {
                    Components.Remove(bricks[i]);
                    bricks.RemoveAt(i);
                    //paddle.Width += 1;

                    ball.Direction.Y = bounce_speed;
                }
            }

            // Check paddle collision
            if( ball.Colliding(paddle ) )
            {
                ball.Direction.Y = -bounce_speed;
            }

            // Check wall collision
            if ( ball.Position.X <=0)
            {
                ball.Direction.X = bounce_speed;
            }

            // Check wall collision
            if (ball.Position.X >= GraphicsDevice.Viewport.Width - ball.Width)
            {
                ball.Direction.X = -bounce_speed;
            }

            if(ball.Position.Y >= GraphicsDevice.Viewport.Height )
            {
                // loose 
            }

            ball.Position.X += ball.Direction.X  ;
            ball.Position.Y += ball.Direction.Y  ;

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);



            // TODO: Add your drawing code here
            foreach (var entity in entities)
            {
                entity.Draw(gameTime);
            }

            base.Draw(gameTime);
        }
    }
}
