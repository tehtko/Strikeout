using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Diagnostics;

namespace Strikeout
{
    internal class ScoreComponent : DrawableGameComponent
    {
        private Game game;
        private SpriteBatch spriteBatch;
        private SpriteFont regularFont;
        public int elapsed { get; set; } = 0;
        private Color regularColor = Color.Black;
        public int score { get; set; }
        private Vector2 position;

        public ScoreComponent(Game game,
            SpriteBatch spriteBatch,
            SpriteFont regularFont,
            Vector2 position,
            int score) : base(game)
        {
            this.game = game;
            this.spriteBatch = spriteBatch;
            this.regularFont = regularFont;
            this.position = position;
            this.score = score;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(regularFont, $"Time: {elapsed}",
                        new Vector2(20, 10), regularColor);
            spriteBatch.DrawString(regularFont, $"Score: {score}",
                        position, regularColor);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
