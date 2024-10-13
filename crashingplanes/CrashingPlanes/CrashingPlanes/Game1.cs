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
		private Texture2D sadamAliveSprite;
		private Texture2D twintSprite;
		private Texture2D planeSprite;
		private Texture2D hidingSpot;
		private Texture2D arabText;

		private SpriteFont gameFont;
		private SpriteFont gameFontSmall;

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
			this.sadamAliveSprite = Content.Load<Texture2D>("sadamalive");
			this.osamaSprite = Content.Load<Texture2D>("osama");
			this.twintSprite = Content.Load<Texture2D>("twint");
			this.planeSprite = Content.Load<Texture2D>("plane");
			this.hidingSpot = Content.Load<Texture2D>("hidingspot");
			this.arabText = Content.Load<Texture2D>("arabtext");
			this.gameFont = Content.Load<SpriteFont>("FontD");
			this.gameFontSmall = Content.Load<SpriteFont>("FontDsmall");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if (this.controller.isInGame())
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
			if (this.player.getPlaneList().Count() > 0)
				foreach (var plane in this.player.getPlaneList())
					if (!plane.getReachedTarget())
					{
						plane.Update();
						this.controller.checkSadamState(plane);
					}
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			this._spriteBatch.Begin();
			this._spriteBatch.Draw(this.twintSprite, new Vector2(0, 0), Color.White);

			if (!this.controller.isInGame())
			{
				this._spriteBatch.Draw(this.hidingSpot, new Vector2(0, 0), Color.White);
				var message = "Don't let Sadam Hussein into the hiding spot!";
				var size = gameFont.MeasureString(message);
				this._spriteBatch.DrawString(this.gameFont, message, new Vector2(GraphicsDevice.Viewport.Width / 2 - size.X / 2, GraphicsDevice.Viewport.Height / 2 - 300), Color.Red);
				this._spriteBatch.Draw(this.arabText, new Vector2(GraphicsDevice.Viewport.Width / 2 - size.X / 2, GraphicsDevice.Viewport.Height / 2 - 300), Color.White);

			}
			else this.player.revive();

			if (this.player.getPlaneList().Count() > 0)
				foreach (var plane in this.player.getPlaneList()){
					if (!plane.getReachedTarget())
						this._spriteBatch.Draw(this.planeSprite, plane.getPosition(), Color.White);
				}
			if ( this.player.isDead())
				this._spriteBatch.Draw(this.osamaSprite, this.player.getRealPosition(), Color.Red);
			else  this._spriteBatch.Draw(this.osamaSprite, this.player.getRealPosition(), Color.White);

			foreach (var sadam in this.controller.getSadamList())
				if (sadam.isDead())
					this._spriteBatch.Draw(this.sadamSprite, sadam.getDrawPosition(), Color.White);
				else this._spriteBatch.Draw(this.sadamAliveSprite, sadam.getDrawPosition(), Color.White);
			if (this.timer != 0 && this.controller.isInGame())
				this._spriteBatch.DrawString(this.gameFontSmall, "Score: " + (int)this.timer 
														+ "\nHusseins sent back: " + this.controller.getSadamRevived() , 
														new Vector2(10, 10), Color.White);
			this._spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
