using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace tetris.domain
{
	internal class Piece
	{
		public PieceNames Name { get; init; }
		public int[,] Matrix { get; set; }
		public Vector2 Position { get; set; }
		public int ColourId { get; init; }

		public int NrLines;
		public int NrCols;

		public int Rotation = 0;

		private static Random random = new Random();

		public Piece(PieceNames Name, int x, int y)
		{
			this.Name = Name;
			this.ColourId = random.Next() % 6 + 1;
			this.Position = new Vector2(x, y);
			switch (Name)
			{
				case PieceNames.l:
					{
						Matrix = new int[4, 1]
						{
							{ ColourId},
							{ ColourId },
							{ ColourId},
							{ ColourId}
						};
						this.NrLines = 4;
						this.NrCols = 1;
						
						break;
					}
				case PieceNames.o:
					{
						Matrix = new int[2, 2]
						{
							{ ColourId, ColourId },
							{ ColourId, ColourId }
						};
						this.NrLines = 2;
						this.NrCols = 2;
						break;
					}
				case PieceNames.s:
					{
						Matrix = new int[2, 3]
						{
							{ 0, ColourId, ColourId},
							{ ColourId, ColourId, 0},
						};
						this.NrLines = 2;
						this.NrCols = 3;
						break;
					}
				case PieceNames.z:
					{
						Matrix = new int[2, 3]
						{
							{ ColourId, ColourId, 0},
							{ 0, ColourId, ColourId},
						};
						this.NrLines = 2;
						this.NrCols = 3;
						break;
					}
				case PieceNames.L:
					{
						Matrix = new int[3, 2]
						{
							{ ColourId, 0 },
							{ ColourId, 0 },
							{ ColourId, ColourId }
						};
						this.NrLines = 3;
						this.NrCols = 2;
						break;
					}
				case PieceNames.J:
					{
						Matrix = new int[3, 2]
						{
							{ 0, ColourId },
							{ 0, ColourId},
							{ ColourId, ColourId }
						};
						this.NrLines = 3;
						this.NrCols = 2;
						break;
					}
				case PieceNames.T:
					{
						Matrix = new int[2, 3]
						{
							{ ColourId, ColourId, ColourId },
							{ 0, ColourId, 0 }
						};
						this.NrLines = 2;
						this.NrCols = 3;
						break;
					}
			}
		}

		public Piece Rotate()
		{
			if (this.Name == PieceNames.o)
				return this;
			this.Rotation++;
			var temp = new int[NrCols, NrLines];

			for (int i = 0; i < NrCols; i++)
				for (int j = 0; j < NrLines; j++)
					temp[i, j] = this.Matrix[NrLines - j - 1, i];
			this.Matrix = temp;
			var aux = this.NrCols;
			this.NrCols = NrLines;
			this.NrLines = aux;
			return this;
		}
	}
}
