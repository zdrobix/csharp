
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
			table.AddPiece(new Piece(PieceNames.o), 0);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.o), 2);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.o), 4);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.o), 6);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.o), 8);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.T), 7);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();
			table.AddPiece(new Piece(PieceNames.T), 4);
			Debug.WriteLine("Added o piece");
			table.DebugWriteTable();

			var result = table.GetFullRow();

			foreach (var row in result)
			{
				Debug.WriteLine("Deleting row " + row);
				table.DeleteRow(row);
				table.DebugWriteTable();
				table.MoveRowsDownByOne(row);
				Debug.WriteLine("Moving rows down from " + row);
				table.DebugWriteTable();
			}
		}
	}
}


//using var game = new tetris.Game1();
//game.Run();
