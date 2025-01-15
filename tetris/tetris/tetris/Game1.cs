using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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


		private Table GameTable;
		private Piece currentPiece;
		private SpriteFont _font;

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
			Debug.WriteLine("Generated piece.");
			this.windoWidth = GraphicsDevice.Viewport.Width;
			this.windoHeight = GraphicsDevice.Viewport.Height;
			this.currentPiece = new Piece((PieceNames)random.Next(0, Enum.GetValues(typeof(PieceNames)).Length), this.windoWidth / 2, this.windoHeight / 2 - tableHeight / 2);
			this._font = Content.Load<SpriteFont>("FontD");
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

			var keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.Left) && releasedLeft && currentPiece.Position.X > this.windoWidth / 2 - this.tableWidth / 2)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X - this.pieceSize, currentPiece.Position.Y);
				this.releasedLeft = false;
			}
			if (keyboardState.IsKeyDown(Keys.Right) && releasedRight && currentPiece.Position.X < this.windoWidth / 2 + this.tableWidth / 2 - this.currentPiece.NrCols * this.pieceSize)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X + this.pieceSize, currentPiece.Position.Y);
				this.releasedRight = false;
			}
			if (keyboardState.IsKeyDown(Keys.Down) && this.releasedDown)
			{
				this.GameTable.AddPiece(currentPiece, (((int)currentPiece.Position.X - (this.windoWidth / 2 - this.tableWidth / 2)) / this.pieceSize) % 10);
				this.currentPiece = new Piece((PieceNames)random.Next(0, Enum.GetValues(typeof(PieceNames)).Length), this.windoWidth / 2, this.windoHeight / 2 - tableHeight / 2);
				this.releasedDown = false;
			}
			if (keyboardState.IsKeyDown(Keys.Up) && this.releasedUp)
			{
				this.currentPiece.Rotate();
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
			if (timeSinceLastMove >= moveDelay)
			{
				currentPiece.Position = new Vector2(currentPiece.Position.X, currentPiece.Position.Y + this.pieceSize);
				timeSinceLastMove = 0;
			}

			this.GameTable.GetFullRow().ForEach(
				x => { this.GameTable.DeleteRow(x); this.GameTable.MoveRowsDownByOne(x); this.score += 100; }
			);
			
			base.Update(gameTime);
		}

		protected override void Draw(GameTime gameTime)
		{
			this._spriteBatch.Begin();
			GraphicsDevice.Clear(Color.White);
			for (int i = 0; i < 20; i++)
			{
				int xpos = this.windoWidth / 2 - this.tableWidth / 2;
				int ypos = this.windoHeight / 2 - this.tableHeight /2 + i * this.pieceSize;
				Debug.WriteLine($"table {xpos} {ypos}");

				for (int j = 0; j < 10; j++)
				{
					switch (this.GameTable.MatrixTable[i, j])
					{
						case 0:
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Black);
							break;									
						case 1:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.BlueViolet);
							break;										
						case 2:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Indigo);
							break;										
						case 3:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.MediumOrchid);
							break;										
						case 4:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.MediumPurple);
							break;										
						case 5:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Purple);
							break;										
						case 6:											
							this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Violet);
							break;
					}
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
							Debug.WriteLine($"piece {xpos} {ypos}");
							switch (this.currentPiece.Matrix[i, j])
							{
								case 1:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.BlueViolet);
									break;
								case 2:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Indigo);
									break;
								case 3:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.MediumOrchid);
									break;
								case 4:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.MediumPurple);
									break;
								case 5:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Purple);
									break;
								case 6:
									this._spriteBatch.Draw(pixel, new Rectangle(xpos, ypos, this.pieceSize, this.pieceSize), Color.Violet);
									break;
							}
						}
			}
			this._spriteBatch.DrawString(_font, "Score: " + this.score, new Vector2(0, this.windoHeight / 2), Color.Black);
			base.Draw(gameTime);
			this._spriteBatch.End();
		}
	}
}
