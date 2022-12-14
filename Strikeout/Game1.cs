using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Strikeout
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public SpriteBatch _spriteBatch;
        
        //declare all scenes here
        private StartScene startScene;
        private HelpScene helpScene;
        private ActionScene actionScene;
        private AboutScene aboutScene;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            Shared.stage = new Vector2(_graphics.PreferredBackBufferWidth,
                _graphics.PreferredBackBufferHeight);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            startScene = new StartScene(this);
            this.Components.Add(startScene);
            startScene.show();

            //other scenes will be instantiated here
            helpScene = new HelpScene(this);
            this.Components.Add(helpScene);
            //helpScene.show();

            aboutScene = new AboutScene(this);
            this.Components.Add(aboutScene);

            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);
        }

        /// <summary>
        /// This must be called before showing the StartScene after each game ends,
        /// otherwise enumertaion on each Component in the GameScene class will fail,
        /// since the collection was modified and not restored in time
        /// </summary>
        public void RestartGame()
        {
            this.Components.Remove(actionScene);
            actionScene = new ActionScene(this);
            this.Components.Add(actionScene);
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}