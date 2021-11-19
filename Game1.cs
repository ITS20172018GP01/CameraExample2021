using CameraNS;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Sprites;

namespace CameraExample2021
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Texture2D txBackground;
        Texture2D txSprite;
        private SimplePlayer sprite;
        Camera cam;
        Vector2 WorldBound = Vector2.Zero;
        Rectangle WorldRectangle;
        
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
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
            txBackground = Content.Load<Texture2D>("background1");
            txSprite = Content.Load<Texture2D>("chaser");
            sprite = new SimplePlayer(txSprite,
                GraphicsDevice.Viewport.Bounds.Center.ToVector2());

            WorldBound = txBackground.Bounds.Size.ToVector2();
            cam = new Camera(Vector2.Zero, 
                WorldBound
                );
            WorldRectangle = new Rectangle(Point.Zero, WorldBound.ToPoint());
            // TODO: use this.Content to load your game content here
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
            sprite.Update(gameTime);
                cam.follow(sprite.Position, GraphicsDevice.Viewport);
            sprite.Position = Vector2.Clamp(sprite.Position, Vector2.Zero, 
                WorldBound - sprite.Image.Bounds.Size.ToVector2() );
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin(SpriteSortMode.BackToFront,
                                BlendState.AlphaBlend,
                                null, null, null, null, 
                                cam.CurrentCameraTranslation);
            spriteBatch.Draw(txBackground, WorldRectangle, Color.White);
            sprite.draw(spriteBatch);
            spriteBatch.End();
            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
