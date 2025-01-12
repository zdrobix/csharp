
using System;
using System.Diagnostics;
using tetris.domain;

namespace tetris
{
	internal class Application
	{
		public static void Main (string[] args)
		{
			Table table = new Table();
			Debug.WriteLine("new Line");
			for ( int i = 0; i < 20; i ++)
			{
				string line = "";
				for ( int j = 0; j < 10; j ++)
					line += table.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}
			table.AddPiece(new Piece(PieceNames.o), 5);
			Debug.WriteLine("Added o piece");
			for (int i = 0; i < 20; i++)
			{
				string line = "";
				for (int j = 0; j < 10; j++)
					line += table.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}
			table.AddPiece(new Piece(PieceNames.T), 3);
			Debug.WriteLine("Added another piece");
			for (int i = 0; i < 20; i++)
			{
				string line = "";
				for (int j = 0; j < 10; j++)
					line += table.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}
			Debug.WriteLine("Added another piece");
			table.AddPiece(new Piece(PieceNames.J), 3);
			for (int i = 0; i < 20; i++)
			{
				string line = "";
				for (int j = 0; j < 10; j++)
					line += table.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}
			Debug.WriteLine("Added another piece");
			table.AddPiece(new Piece(PieceNames.L), 1);

			for (int i = 0; i < 20; i++)
			{
				string line = "";
				for (int j = 0; j < 10; j++)
					line += table.MatrixTable[i, j] + " ";
				Debug.WriteLine(line);
			}

		}
	}
}


//using var game = new tetris.Game1();
//game.Run();
