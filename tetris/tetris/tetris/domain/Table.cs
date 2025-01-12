using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tetris.domain
{
	internal class Table
	{
		public int[,] MatrixTable { get; }

		public Table() {
			this.MatrixTable = new int[20, 10];
		}

		public void AddPiece (Piece piece, int columnIndex)
		{
			int rowPlace = -1;
			int leftColumn = columnIndex + piece.LeftOffset;
			int rightColumn = columnIndex + 4 - piece.RightOffset - 1;
			for (int row = 19; row >= 0; row--)
			{
				bool canPlace = true;
				for (int col = leftColumn; col <= rightColumn; col++)
				{
					for (int i = 0; i < 4; i++)
					{
						if (piece.Matrix[0, col - leftColumn] != 0)
						{
							int boardRow = row - i;
							if (boardRow < 0 || boardRow >= 20 || col < 0 || col >= 10 || MatrixTable[boardRow, col] != 0)
							{
								canPlace = false;
								break;
							}
						}
					}
					if (!canPlace)
						break;
				}
				if (canPlace)
				{
					rowPlace = row;
					break;
				}
			}
			if (rowPlace == -1) throw new Exception("Game over");

			for (int i = 0; i < 4; i++)
			{
				for (int j = leftColumn; j <= rightColumn; j++)
				{
					if (piece.Matrix[i, j - leftColumn] != 0)
						this.MatrixTable[rowPlace - i, j] = piece.ColourId;
				}
			}
		} 


	}
}
