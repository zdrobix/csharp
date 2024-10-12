using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Linq;

namespace CrashingPlanes
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D osamaSprite;
		private Texture2D sadamSprite;
		private Texture2D twintSprite;

		private SpriteFont gameFont;

		Osama player = new Osama();
		Controller controller = new Controller();

		private double timer = 0;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = false;
		}

		protected override void Initialize()
		{
			this._graphics.PreferredBackBufferWidth = 1100;
			this._graphics.PreferredBackBufferHeight = 670;
			this._graphics.ApplyChanges();
			base.Initialize();
		}

		protected override void LoadContent()
		{
			this._spriteBatch = new SpriteBatch(GraphicsDevice);
			this.sadamSprite = Content.Load<Texture2D>("sadam");
			this.osamaSprite = Content.Load<Texture2D>("osama");
			this.twintSprite = Content.Load<Texture2D>("twint");
			this.gameFont = Content.Load<SpriteFont>("FontD");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if ( this.controller.isInGame())
				this.timer += gameTime.ElapsedGameTime.TotalSeconds;
			this.player.shipUpdate(gameTime);
			this.controller.controllerUpdate(gameTime);
			foreach (var sadam in this.controller.getSadamList())
			{
				sadam.sadamUpdate(gameTime);
				if (this.player.didItCollide(sadam.getDrawPosition()))
				{
					this.controller.endGame();
					this.player.die();
					this.timer = 0;
				}
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			this._spriteBatch.Begin();
			this._spriteBatch.Draw(this.twintSprite, new Vector2(0, 0), Color.White);

			if (!this.controller.isInGame())
			{
				var message = "Press Enter to revive Osama!";
				var size = gameFont.MeasureString(message);
				this._spriteBatch.DrawString(this.gameFont, message, new Vector2(GraphicsDevice.Viewport.Width / 2 - size.X / 2, GraphicsDevice.Viewport.Height / 2), Color.Red);

			}
			else this.player.revive();

			if ( this.player.isDead())
				this._spriteBatch.Draw(this.osamaSprite, this.player.getRealPosition(), Color.Red);
			else  this._spriteBatch.Draw(this.osamaSprite, this.player.getRealPosition(), Color.White);

			foreach (var sadam in this.controller.getSadamList())
				this._spriteBatch.Draw(this.sadamSprite, sadam.getDrawPosition(), Color.White);
			if (this.timer != 0)
				this._spriteBatch.DrawString(this.gameFont, "Score: " + (int)this.timer, new Vector2(10, 10), Color.White);
			this._spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
