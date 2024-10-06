using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GameParser
{
	internal class Game
	{
		public string Title { get; set; }
		public int ReleaseYear { get; set; }
		public double Rating { get; set; }

		public string display_game ()
		{
			return $"Title: {this.Title}, Year: {this.ReleaseYear}, Rating: {this.Rating}";
		}
	}
}
