using Plants_vs_Zombies.GameManagement;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using plants_vs_zombies.States;

namespace Plants_vs_Zombies
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Plants_vs_Zombies : GameEnvironment
    {

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            screen = new Point(1024, 626);
            ApplyResolutionSettings();
            GameStateManager.AddGameState("playingState", new PlayingState());
            GameStateManager.AddGameState("GameOverState", new GameOverState());
            GameStateManager.SwitchTo("playingState");
            //GameStateManager.SwitchTo("GameOverState");


            // TODO: use this.Content to load your game content here
        }

    }
}
