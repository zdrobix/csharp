using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.IO;
using System.Text.Json;
using System.Xml.Linq;
using System.Threading;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace snake_
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;
		private Texture2D pixel;
		private Texture2D appleImage;

		private int tableWidth;
		private int tableHeight;

		private int windoWidth;
		private int windoHeight;

		private double moveTimer;
		private double moveInterval = 0.1;

		private Snake snake;
		private Snake snakeCopy;

		private Vector2 applePosition;
		private Random random = new Random();
		private SpriteFont _font;
		private int segmentSize = 20;

		private int randomMessage;

		private List<string> strings;
		private Table table;

		public Game1()
		{
			this._graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			this.tableHeight = 300;
			this.tableWidth = 300;
			this.windoWidth = GraphicsDevice.Viewport.Width;
			this.windoHeight = GraphicsDevice.Viewport.Height;
			this.table = new Table(new Tuple<int, int>(this.windoWidth, this.windoHeight), new Tuple<int, int>(this.tableWidth, this.tableHeight));
			int startX = (this.windoWidth - this.tableWidth) / 2;
			int startY = (this.windoHeight - this.tableHeight) / 2;
			this.snake = new Snake(startX, startY, this.segmentSize);
			this.snakeCopy = new Snake(startX + this.tableWidth, startY, this.segmentSize);
			this.snakeCopy.hide();
			this.SpawnApple();
			this._font = Content.Load<SpriteFont>("FontD");
			using (var sr = new StreamReader("Q:\\info\\c# projects\\snake_\\snake_\\snake_\\messages.txt"))
			{
				this.strings = sr.ReadToEnd()
							  .Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
							  .ToList();
			}
			this.randomMessage = this.random.Next(0, this.strings.Count);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			this._spriteBatch = new SpriteBatch(GraphicsDevice);
			this.pixel = new Texture2D(GraphicsDevice, 1, 1);
			this.appleImage = Content.Load<Texture2D>("apple");
			pixel.SetData(new[] { Color.White });
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			if (this.isSnakeDead())
			{
				KeyboardState state = Keyboard.GetState();
				if (state.IsKeyDown(Keys.R))
				{
					this.RestartGame();
				}
				return;
			}


			this.moveTimer += gameTime.ElapsedGameTime.TotalSeconds;

			if (this.moveTimer >= this.moveInterval && !this.isSnakeDead())
			{
				KeyboardState state = Keyboard.GetState();
				if (state.IsKeyDown(Keys.Up) && snake.Direction != new Vector2(0, 1))
				{
					snake.Direction = new Vector2(0, -1);
					snakeCopy.Direction = new Vector2(0, -1);
				}
				else if (state.IsKeyDown(Keys.Down) && snake.Direction != new Vector2(0, -1))
				{
					snake.Direction = new Vector2(0, 1);
					snakeCopy.Direction = new Vector2(0, 1);
				}
				else if (state.IsKeyDown(Keys.Left) && snake.Direction != new Vector2(1, 0))
				{
					snake.Direction = new Vector2(-1, 0);
					snakeCopy.Direction = new Vector2(-1, 0);
				}
				else if (state.IsKeyDown(Keys.Right) && snake.Direction != new Vector2(-1, 0))
				{
					snake.Direction = new Vector2(1, 0);
					snakeCopy.Direction = new Vector2(1, 0);
				}

				this.snake.Move();
				this.snakeCopy.Move();
				if (this.isSnakeDead())
				{
					this.snake.Kill();
					this.snakeCopy.Kill();
				}
				if (Vector2.Distance(this.snake.Body[0], applePosition) < this.segmentSize || Vector2.Distance(this.snakeCopy.Body[0], applePosition) < this.segmentSize)
				{
					this.snake.Grow();
					this.snakeCopy.Grow();
					this.SpawnApple();
				}

				this.moveTimer = 0;
			}

			if (this.table.canTeleport(new Tuple<float, float>(Snake.whichVisible(this.snake, this.snakeCopy).Body[0].X, Snake.whichVisible(this.snake, this.snakeCopy).Body[0].Y), this.snake.level()))
				Snake.flipBothSnakes(this.snake, this.snakeCopy);

			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CadetBlue);
			this._spriteBatch.Begin();
			this.table.designMap(this._spriteBatch, this.pixel, this.snake.level());
			this.snake.drawSnake(this._spriteBatch, this.pixel, Snake.whichVisible(this.snake, this.snakeCopy));

			this._spriteBatch.Draw(appleImage, new Rectangle((int)applePosition.X, (int)applePosition.Y, this.segmentSize, this.segmentSize), Color.White);

			if (this.isSnakeDead())
				this._spriteBatch.DrawString(_font, strings.ElementAt(this.randomMessage) + "\nPress R to restart", new Vector2(10, 10), Color.White);
			
			this._spriteBatch.DrawString(_font, "Score: " + (this.snake.Body.Count - 1), new Vector2(10, 100), Color.White);
			this._spriteBatch.End();
			base.Draw(gameTime);

		}

		private void SpawnApple()
		{
			int tableLeft = (this.windoWidth - this.tableWidth) / 2;
			int tableTop = (this.windoHeight - this.tableHeight) / 2;

			int x = (random.Next(0, (this.tableWidth / this.segmentSize))) * this.segmentSize + tableLeft;
			int y = (random.Next(0, (this.tableHeight / this.segmentSize))) * this.segmentSize + tableTop;

			applePosition = new Vector2(x, y);
		}
		
		private bool isSnakeDead()
		{
			Vector2 head = snake.Body[0];
			for (int i = 2; i < snake.Body.Count; i++)
			{
				if (head == snake.Body[i])
					return true;
			}
			
			return table.isDead(new Tuple<float, float>(head.X, head.Y), this.snake.level());
		}
		private void RestartGame()
		{
			int startX = (this.windoWidth - this.tableWidth) / 2;
			int startY = (this.windoHeight - this.tableHeight) / 2;
			this.snake = new Snake(startX, startY, this.segmentSize);
			this.snakeCopy = new Snake(startX + this.tableWidth, startY, this.segmentSize);

			this.SpawnApple();

			this.randomMessage = this.random.Next(0, this.strings.Count);

			this.moveTimer = 0;
		}
	}
}
