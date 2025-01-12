using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace tetris.domain
{
	internal class Piece
	{
		public int[,] Matrix { get; init; }
		public int ColourId { get; init; }
		private static Random random = new Random();
		public int LeftOffset { get; init; }
		public int RightOffset { get; init; }

		public Piece(PieceNames Name)
		{
			ColourId = random.Next() % 6 + 1;
			switch (Name)
			{
				case PieceNames.l:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ 0, ColourId, 0, 0 },
							{ 0, ColourId, 0, 0 },
							{ 0, ColourId, 0, 0 }
						};
						this.LeftOffset = 1;
						this.RightOffset = 2;
						break;
					}
				case PieceNames.o:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ 0, ColourId, ColourId, 0 },
							{ 0, ColourId, ColourId, 0 },
							{ 0, 0, 0, 0 }
						};
						this.LeftOffset = 1;
						this.RightOffset = 1;
						break;
					}
				case PieceNames.s:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ 0, ColourId, ColourId, 0 },
							{ ColourId, ColourId, 0, 0 },
							{ 0, 0, 0, 0 }
						};
						this.LeftOffset = 0;
						this.RightOffset = 1;
						break;
					}
				case PieceNames.z:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ ColourId, ColourId, 0, 0 },
							{ 0, ColourId, ColourId, 0 },
							{ 0, 0, 0, 0 }
						};
						this.LeftOffset = 1;
						this.RightOffset = 1;
						break;
					}
				case PieceNames.L:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ ColourId, 0, 0, 0 },
							{ ColourId, 0, 0, 0 },
							{ ColourId, ColourId, 0, 0 }
						};
						this.LeftOffset = 0;
						this.RightOffset = 2;
						break;
					}
				case PieceNames.J:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ 0, ColourId, 0, 0 },
							{ 0, ColourId, 0, 0 },
							{ ColourId, ColourId, 0, 0 }
						};
						this.LeftOffset = 0;
						this.RightOffset = 2;
						break;
					}
				case PieceNames.T:
					{
						Matrix = new int[4, 4]
						{
							{ 0, 0, 0, 0 },
							{ 0, 0, 0, 0 },
							{ ColourId, ColourId, ColourId, 0 },
							{ 0, ColourId, 0, 0 }
						};
						this.LeftOffset = 0;
						this.RightOffset = 1;
						break;
					}
			}
		}
	}
}
