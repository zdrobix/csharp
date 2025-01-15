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
			for (int row = 20 - piece.NrLines; row >= 0; row--)
			{
				bool canPlace = true;

				for (int j = columnIndex; j < columnIndex + piece.NrCols; j++)
				{
					for ( int i =  row; i < row + piece.NrLines; i ++)
					{
						if (piece.Matrix[i - row, j - columnIndex] * this.MatrixTable[i, j] != 0)
						{
							canPlace = false;
							break;
						}
					}
				}
				if (canPlace)
				{
					rowPlace = row;
					break;
				}
			}
			for (int j = columnIndex; j < columnIndex + piece.NrCols; j++)
			{
				for (int i = rowPlace; i < rowPlace + piece.NrLines; i++)
				{
					this.MatrixTable[i, j] += piece.Matrix[i - rowPlace, j - columnIndex];
				}
			}
		} 

		public List<int> GetFullRow ()
		{
			List<int> rows = new List<int>();
			for ( int i = 0; i < 20; i ++ )
			{
				bool isFull = true;
				for ( int j = 0; j < 10; j ++ )
					if (this.MatrixTable[i, j] == 0)
					{
						isFull = false;
						break;
					}
				if (isFull) rows.Add(i);
			}
			return rows;
		}

		public void DeleteRow (int row)
		{
			for (int j = 0; j < 10; j++)
				this.MatrixTable[row, j] = 0;
		}

		public void MoveRowsDownByOne (int row)
		{
			for (int i = row; i > 0; i --)
			{
				for (int j = 0; j < 10; j ++)
					this.MatrixTable[i, j] = this.MatrixTable[i - 1, j];
			}
		}

		public void DebugWriteTable ()
		{
			for (int i = 0; i < 20; i++)
			{
				string line = "";
				for (int j = 0; j < 10; j++)
					line += this.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}
		}
	}
}
