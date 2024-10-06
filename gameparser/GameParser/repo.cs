using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GameParser
{
	internal class Repo
	{
		private string filename;
		private List<Game> game_list;

		public Repo ( string _filename )
		{
			this.filename = _filename;
			this.load_file();
		}

		public Repo() { }

		private void load_file ()
		{
			var lines = File.ReadAllText(this.filename);
			try
			{
				this.game_list = JsonSerializer.Deserialize<List<Game>>(lines);
			} catch (JsonException e)
			{
				throw new InvalidOperationException(e.Message);
			}
		}

		public string display_games ()
		{
			string result = "\n";
			foreach (Game game in this.game_list)
			{
				result += game.display_game() + "\n";
			}
			return result;
		}
	}
}
