using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace ShootingGuys
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D target1Sprite;
		private Texture2D crosshairSprite;
		private SpriteFont font;

		private MouseState mouseState;
		private bool mouseReleased = false;

		private Vector2 targetPosition = new Vector2(200, 200);
		private int targetRadius = 90;

		private int randomX;
		private int randomY;

		private Random random = new Random();

		private int score = 0;
		private double timer = 10;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = false;
		}

		protected override void Initialize()
		{
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			this.target1Sprite = Content.Load<Texture2D>("target");
			this.crosshairSprite = Content.Load<Texture2D>("crosshair");
			this.font = Content.Load<SpriteFont>("FontD");
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			if (this.timer > 0)
			{
				this.timer -= gameTime.ElapsedGameTime.TotalSeconds;
			}
			else this.timer = 0;
			this.mouseState = Mouse.GetState();
			if (this.mouseState.LeftButton == ButtonState.Pressed && this.mouseReleased)
			{

				if (Vector2.Distance(this.targetPosition, this.mouseState.Position.ToVector2()) < this.targetRadius && this.timer > 0)
				{
					this.score++;
					this.randomX = random.Next(0 + this.targetRadius, GraphicsDevice.Viewport.Width - this.targetRadius);
					this.randomY = random.Next(0 + this.targetRadius, GraphicsDevice.Viewport.Height - this.targetRadius);
					this.targetPosition = new Vector2(this.randomX, this.randomY);
				}
				this.mouseReleased = false;
			}
			if (this.mouseState.LeftButton == ButtonState.Released)
			{
				this.mouseReleased = true;
			}

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			if (this.timer > 0)
				GraphicsDevice.Clear(Color.White);
			else
				GraphicsDevice.Clear(Color.Red);
			this._spriteBatch.Begin();
			if (this.timer > 0)
				this._spriteBatch.Draw(this.target1Sprite, new Vector2(this.targetPosition.X - this.targetRadius, this.targetPosition.Y - this.targetRadius), Color.White);
			this._spriteBatch.Draw(this.crosshairSprite, new Vector2(this.mouseState.Position.X - 25, this.mouseState.Position.Y - 25), Color.White);
			this._spriteBatch.DrawString(this.font, "Score: " + this.score + "\nTime:  " + (int)this.timer, new Vector2(10, 10), Color.Black);
			if (this.timer <= 0)
				this._spriteBatch.DrawString(this.font, "Better luck next time!", new Vector2(10, GraphicsDevice.Viewport.Height / 2), Color.Black);

			this._spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
