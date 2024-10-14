using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

using Comora;
using System.Linq;

namespace rpg
{	
	public enum Direction
	{
		Left, Up, Down, Right
	}

	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D playerSprite;
		private Texture2D walkUp;
		private Texture2D walkDown;
		private Texture2D walkLeft;
		private Texture2D walkRight;

		private Texture2D background;
		private Texture2D ball;
		private Texture2D skull;

		Player player = new Player();
		Camera camera;

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			this._graphics.PreferredBackBufferWidth = 1280;
			this._graphics.PreferredBackBufferHeight = 720;
			this._graphics.ApplyChanges();
			this.camera = new Camera(this._graphics.GraphicsDevice);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);

			this.playerSprite = Content.Load<Texture2D>("player/player");
			this.walkLeft = Content.Load<Texture2D>("player/walkLeft");
			this.walkDown = Content.Load<Texture2D>("player/walkDown");
			this.walkUp = Content.Load<Texture2D>("player/walkUp");
			this.walkRight = Content.Load<Texture2D>("player/walkRight");

			this.background = Content.Load<Texture2D>("background");
			this.skull = Content.Load<Texture2D>("skull");
			this.ball = Content.Load<Texture2D>("ball");

			this.player.animations.Add( new SpriteAnimation(this.walkLeft, 4, 8));
			this.player.animations.Add( new SpriteAnimation(this.walkUp, 4, 8));
			this.player.animations.Add( new SpriteAnimation(this.walkDown, 4, 8));
			this.player.animations.Add( new SpriteAnimation(this.walkRight, 4, 8));

			this.player.animation = this.player.animations.ElementAt(0);
			Enemy.enemies.Add(new Enemy(new Vector2(100, 100), skull));
			Enemy.enemies.Add(new Enemy(new Vector2(700, 200), skull));
		}


		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();
			this.player.Update(gameTime);
			if (!this.player.dead)
				Controller.Update(gameTime, this.skull);
			this.camera.Position = this.player.getPosition();
			this.camera.Update(gameTime);
			foreach (var projectile in Projectile.projectiles)
				projectile.Update(gameTime);
			foreach (var enemy in Enemy.enemies)
			{
				if (!this.player.dead)
					enemy.Update(gameTime, this.player.getPosition());
				if (Vector2.Distance(enemy.getPosition(), this.player.getPosition()) < 32 + enemy.radius)
					this.player.dead = true;
			}
			foreach (var projectile in Projectile.projectiles)
				foreach (var enemy in Enemy.enemies)
					if (Vector2.Distance(projectile.getPosition(), enemy.getPosition()) < enemy.radius + projectile.radius)
					{
						projectile.setColided();
						enemy.setDead(true);
					}

			Projectile.projectiles.RemoveAll(p => p.getColided());
			Enemy.enemies.RemoveAll(e => e.getDead());
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);
			this._spriteBatch.Begin(this.camera);
			this._spriteBatch.Draw(this.background, new Vector2(-500, -500), Color.White);
			foreach (var projectile in Projectile.projectiles)
				this._spriteBatch.Draw(this.ball, new Vector2(projectile.getPosition().X - 48, projectile.getPosition().Y - 48), Color.White);
			foreach (var enemy in Enemy.enemies)
				enemy.animation.Draw(this._spriteBatch);
			if (!player.dead)
				this.player.animation.Draw(this._spriteBatch);
			this._spriteBatch.End();
			base.Draw(gameTime);
		}
	}
}
