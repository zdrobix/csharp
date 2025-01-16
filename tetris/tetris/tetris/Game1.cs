using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Audio;
using System;
using System.Diagnostics;
using System.Linq;
using tetris.domain;
using static System.Net.Mime.MediaTypeNames;

namespace tetris
{
	public class Game1 : Game
	{
		private GraphicsDeviceManager _graphics;
		private SpriteBatch _spriteBatch;

		private Texture2D pixel;
		private Texture2D block;

		private int windoWidth;
		private int windoHeight;
		private int pieceSize = 20;
		private int tableWidth;
		private int tableHeight;

		private int score = 0;
		private bool gameOver = false;

		private Table GameTable;
		private Piece currentPiece;
		private Piece nextPiece;

		private SpriteFont _font;
		private Song musicBackground;
		private SoundEffect soundEffectPoint;

		private double timeSinceLastMove;
		private double moveDelay = 0.5;
		private bool releasedDown;
		private bool releasedLeft;
		private bool releasedUp;
		private bool releasedRight;

		private Random random = new Random();

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			this.GameTable = new Table();
			tableWidth = 10 * pieceSize;
			tableHeight = 20 * pieceSize;
			this.windoWidth = GraphicsDevice.Viewport.Width;
			this.windoHeight = GraphicsDevice.Viewport.Height;
			this.currentPiece = this.GenerateNewPiece();
			this.nextPiece = this.GenerateNewPiece();
			this._font = Content.Load<SpriteFont>("FontD");
			this.musicBackground = Content.Load<Song>("samplecom");
			this.soundEffectPoint = Content.Load<SoundEffect>("Cymatics - Vocal Chant 63");
			MediaPlayer.IsRepeating = true;
			MediaPlayer.Volume = 0.33f;
			MediaPlayer.Play(this.musicBackground);
			base.Initialize();
		}

		protected override void LoadContent()
		{
			_spriteBatch = new SpriteBatch(GraphicsDevice);
			this.pixel = new Texture2D(GraphicsDevice, 1, 1);
			pixel.SetData(new[] { Color.White });
		}

		protected override void Update(GameTime gameTime)
		{
			if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			int pieceColumnIndex = (((int)currentPiece.Position.X - (this.windoWidth / 2 - this.tableWidth / 2)) / this.pieceSize) % 10;
			int pieceLineIndex = (((int)currentPiece.Position.Y - (this.windoHeight / 2 - this.tableHeight / 2)) / this.pieceSize) % 20;

			var keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.R) && this.gameOver)
			{
				this.gameOver = false;
				this.GameTable = new Table();
				this.currentPiece = this.GenerateNewPiece();
				this.nextPiece = this.GenerateNewPiece();
				this.score = 0;
			}
			if (keyboardState.IsKeyDown(Keys.Left) && releasedLeft && !this.gameOver && currentPiece.Position.X > this.windoWidth / 2 - this.tableWidth / 2)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X - this.pieceSize, currentPiece.Position.Y);
				this.releasedLeft = false;
			}
			if (keyboardState.IsKeyDown(Keys.Right) && releasedRight && !this.gameOver && currentPiece.Position.X < this.windoWidth / 2 + this.tableWidth / 2 - this.currentPiece.NrCols * this.pieceSize)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X + this.pieceSize, currentPiece.Position.Y);
				this.releasedRight = false;
			}
			if (keyboardState.IsKeyDown(Keys.Down) && this.releasedDown && !this.gameOver)
			{
				try
				{
					this.GameTable.AddPiece(currentPiece, pieceColumnIndex);
					this.currentPiece = this.nextPiece;
					this.nextPiece = this.GenerateNewPiece();
				}
				catch (IndexOutOfRangeException)
				{
					this.gameOver = true;
				}
				this.releasedDown = false;
			}
			if (keyboardState.IsKeyDown(Keys.Up) && this.releasedUp && !this.gameOver)
			{
				this.currentPiece.Rotate();
				while (pieceColumnIndex + this.currentPiece.NrCols > 10)
				{
					currentPiece.Position = new Vector2(currentPiece.Position.X - this.pieceSize, currentPiece.Position.Y);
					pieceColumnIndex = (((int)currentPiece.Position.X - (this.windoWidth / 2 - this.tableWidth / 2)) / this.pieceSize) % 10;
				}
				this.releasedUp = false;
			}

			if (keyboardState.IsKeyUp(Keys.Down))
			{
				this.releasedDown = true;
			}
			if (keyboardState.IsKeyUp(Keys.Left))
			{
				this.releasedLeft = true;
			}
			if (keyboardState.IsKeyUp(Keys.Right))
			{
				this.releasedRight = true;
			}
			if (keyboardState.IsKeyUp(Keys.Up))
			{
				this.releasedUp = true;
			}

			timeSinceLastMove += gameTime.ElapsedGameTime.TotalSeconds;
			if (timeSinceLastMove >= moveDelay && !gameOver)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X, currentPiece.Position.Y + this.pieceSize);
				timeSinceLastMove = 0;
			}

			if (pieceLineIndex == this.GameTable.GetFirstRow(currentPiece, pieceColumnIndex))
			{
				this.GameTable.AddPiece(currentPiece, pieceColumnIndex);
				this.currentPiece = this.nextPiece;
				this.nextPiece = this.GenerateNewPiece();
			}

			if (this.GameTable.GetFirstRow(currentPiece, pieceColumnIndex) == -1) this.gameOver = true;

			this.GameTable.GetFullRow().ForEach(
				x => { 
					this.GameTable.DeleteRow(x); 
					this.GameTable.MoveRowsDownByOne(x); 
					this.score += 100; 
					this.soundEffectPoint.Play(); 
				}
			);
			
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			this._spriteBatch.Begin();
			GraphicsDevice.Clear(new Color(85, 85, 85));
			this._spriteBatch.Draw(this.pixel, 
				new Rectangle(
					this.windoWidth / 2 - this.tableWidth / 2 - this.pieceSize / 2,
					this.windoHeight / 2 - this.tableHeight / 2 - this.pieceSize / 2,
					11 * this.pieceSize,
					21 * this.pieceSize), 
				Color.DarkGray);
			for (int i = 0; i < 20; i++)
			{
				int xpos = this.windoWidth / 2 - this.tableWidth / 2;
				int ypos = this.windoHeight / 2 - this.tableHeight /2 + i * this.pieceSize;
				for (int j = 0; j < 10; j++)
				{
					this.ColourBlock(this.GameTable.MatrixTable[i, j], xpos, ypos, this.pieceSize);
					xpos += this.pieceSize;
				}
			}

			if (currentPiece != null)
			{
				for (int i = 0; i < this.currentPiece.NrLines; i++)
					for (int j = 0; j < this.currentPiece.NrCols; j++)
						if (currentPiece.Matrix[i, j] != 0)
						{
							int xpos = (int)(currentPiece.Position.X + j * this.pieceSize);
							int ypos = (int)(currentPiece.Position.Y + i * this.pieceSize);
							this.ColourBlock(this.currentPiece.Matrix[i, j], xpos, ypos, this.pieceSize);
						}
			}


			this._spriteBatch.Draw(this.pixel,
				new Rectangle(
					this.windoWidth / 2 + this.tableWidth / 2 + 3 * this.pieceSize / 2,
					this.windoHeight / 2 - tableHeight / 2 - this.pieceSize / 2,
					6 * this.pieceSize,
					6 * this.pieceSize),
				Color.DarkGray);
			for (int i = 0; i < 5; i++)
				for (int j = 0; j < 5; j++)
					this.ColourBlock(0, this.windoWidth / 2 + this.tableWidth / 2 + (j + 2) * this.pieceSize, this.windoHeight / 2 - tableHeight / 2 + i * this.pieceSize, this.pieceSize);

			if (nextPiece != null)
			{
				int displayCenterX = this.windoWidth / 2 + this.tableWidth / 2 + (9 * this.pieceSize) / 2;
				int displayCenterY = this.windoHeight / 2 - this.tableHeight / 2 + (5 * this.pieceSize) / 2;
				for (int i = 0; i < this.nextPiece.NrLines; i++)
				{
					for (int j = 0; j < this.nextPiece.NrCols; j++)
					{
						if (nextPiece.Matrix[i, j] != 0)
						{
							int xpos = displayCenterX - (nextPiece.NrCols * this.pieceSize) / 2 + j * this.pieceSize;
							int ypos = displayCenterY - (nextPiece.NrLines * this.pieceSize) / 2 + i * this.pieceSize;
							this.ColourBlock(this.nextPiece.Matrix[i, j], xpos, ypos, this.pieceSize);
						}
					}
				}
			}

			this._spriteBatch.Draw(this.pixel,
				new Rectangle(
					this.windoWidth / 2 + this.tableWidth / 2 + 3 * this.pieceSize / 2,
					this.windoHeight / 2 - tableHeight / 2 + 13 * this.pieceSize / 2,
					6 * this.pieceSize,
					4 * this.pieceSize),
				Color.DarkGray);
			for (int i = 0; i < 3; i++)
				for (int j = 0; j < 5; j++)
					this.ColourBlock(0, this.windoWidth / 2 + this.tableWidth / 2 + (j + 2) * this.pieceSize, this.windoHeight / 2 - tableHeight / 2 + (i + 7) * this.pieceSize, this.pieceSize);



			//temporary ugly text.
			string text = "Score: " + this.score;
			if (this.gameOver)
				text = "Game over!\nPress R to restart.";
			this._spriteBatch.DrawString(_font, text, new Vector2(0, this.windoHeight / 2), Color.White);
			base.Draw(gameTime);
			this._spriteBatch.End();
		}
		private Piece GenerateNewPiece() => new Piece((PieceNames)random.Next(0, Enum.GetValues(typeof(PieceNames)).Length), this.windoWidth / 2, this.windoHeight / 2 - tableHeight / 2);
		private void ColourBlock (int ColourId, int xpos, int ypos, int size)
		{
			switch (ColourId)
			{
				case 0:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), new Color(113, 113, 113));
					break;
				case 1:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.BlueViolet);
					break;
				case 2:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.Indigo);
					break;
				case 3:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.MediumOrchid);
					break;
				case 4:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.MediumPurple);
					break;
				case 5:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.Purple);
					break;
				case 6:
					this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, size, size), Color.Violet);
					break;
			}
		}
	}
}
