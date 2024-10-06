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
		private int appleNumber;

		private Vector2 applePosition;
		private Random random = new Random();
		private SpriteFont _font;
		private int segmentSize = 20;

		private int randomMessage;

		private List<string> strings;

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
			this.appleNumber = 0;
			int startX = (this.windoWidth - this.tableWidth) / 2 + (random.Next(0, (this.tableWidth / this.segmentSize)) * this.segmentSize);
			int startY = (this.windoHeight - this.tableHeight) / 2 + (random.Next(0, (this.tableHeight / this.segmentSize)) * this.segmentSize);
			this.snake = new Snake(startX, startY, this.segmentSize);
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
				if (state.IsKeyDown(Keys.Up) && snake.Direction != new Vector2(0, 1)) // Prevent reversing
				{
					snake.Direction = new Vector2(0, -1);
				}
				else if (state.IsKeyDown(Keys.Down) && snake.Direction != new Vector2(0, -1))
				{
					snake.Direction = new Vector2(0, 1);
				}
				else if (state.IsKeyDown(Keys.Left) && snake.Direction != new Vector2(1, 0))
				{
					snake.Direction = new Vector2(-1, 0);
				}
				else if (state.IsKeyDown(Keys.Right) && snake.Direction != new Vector2(-1, 0))
				{
					snake.Direction = new Vector2(1, 0);
				}

				this.snake.Move();
				if (this.isSnakeDead())
				{
					this.snake.Kill();
				}
				if (Vector2.Distance(this.snake.Body[0], applePosition) < this.segmentSize)
				{
					this.snake.Grow();
					this.SpawnApple();
				}

				this.moveTimer = 0;
			}
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CadetBlue);
			this._spriteBatch.Begin();
			this._spriteBatch.Draw(pixel, new Rectangle(this.windoWidth / 2 - this.tableWidth / 2,
														this.windoHeight / 2 - this.tableHeight / 2,
														this.tableWidth,
														this.tableHeight), Color.LightBlue);
			//for (int i = 0; i < 9; i++)
			//{
			//	this._spriteBatch.Draw(pixel, new Rectangle(this.windoWidth / 2 - this.tableWidth / 2,
			//												this.windoHeight / 2 - this.tableHeight / 2 + this.tableHeight * i / 16,
			//												this.tableWidth,
			//												1), Color.White);
			//	this._spriteBatch.Draw(pixel, new Rectangle(this.windoWidth / 2 - this.tableWidth / 2,
			//												this.windoHeight / 2 + this.tableHeight * i / 16,
			//												this.tableWidth,
			//												1), Color.White);
			//	this._spriteBatch.Draw(pixel, new Rectangle(this.windoWidth / 2 - this.tableWidth / 2 + this.tableWidth * i / 16,
			//												this.windoHeight / 2 - this.tableHeight / 2,
			//												1,
			//												this.tableHeight), Color.White);
			//	this._spriteBatch.Draw(pixel, new Rectangle(this.windoWidth / 2 + this.tableWidth * i / 16,
			//												this.windoHeight / 2 - this.tableHeight / 2,
			//												1,
			//												this.tableHeight), Color.White);
			//}

			foreach (var segment in snake.Body)
			{
				_spriteBatch.Draw(pixel, new Rectangle((int)segment.X, (int)segment.Y, this.segmentSize, this.segmentSize), Color.Green);
			}

			_spriteBatch.Draw(appleImage, new Rectangle((int)applePosition.X, (int)applePosition.Y, this.segmentSize, this.segmentSize), Color.White);

			if (this.isSnakeDead())
			{
				
				_spriteBatch.DrawString(_font, strings.ElementAt(this.randomMessage) + "\nPress R to restart", new Vector2(10, 10), Color.White);
			}
			_spriteBatch.DrawString(_font, "Score: " + (this.snake.Body.Count - 1) , new Vector2(10, 100), Color.White);


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
			int tableLeft = (this.windoWidth - this.tableWidth) / 2;
			int tableRight = tableLeft + this.tableWidth;
			int tableTop = (this.windoHeight - this.tableHeight) / 2;
			int tableBottom = tableTop + this.tableHeight;

			for (int i = 2; i < snake.Body.Count; i++)
			{
				if (head == snake.Body[i])
					return true; 
			}

			return head.X < tableLeft || head.X >= tableRight || head.Y < tableTop || head.Y >= tableBottom;
		}

		private void RestartGame()
		{
			int startX = (this.windoWidth - this.tableWidth) / 2 + (random.Next(0, (this.tableWidth / this.segmentSize)) * this.segmentSize);
			int startY = (this.windoHeight - this.tableHeight) / 2 + (random.Next(0, (this.tableHeight / this.segmentSize)) * this.segmentSize);
			this.snake = new Snake(startX, startY, this.segmentSize);

			this.SpawnApple();

			this.randomMessage = this.random.Next(0, this.strings.Count);

			this.moveTimer = 0;
		}
	}
}
