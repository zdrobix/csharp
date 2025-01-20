using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Annotations;
using System.Windows.Media.Animation;

namespace flashcards
{
	internal class Repo
	{
		private string Path = @"./input.txt";
		private List<Card> Cards;

		public Repo ()
		{
			Cards = new List<Card> ();
			this.LoadFromFile();
		}

		private void LoadFromFile()
		{
			using (StreamReader sr = new StreamReader(this.Path))
			{
				string answer, question;
				question = sr.ReadLine();
				answer = sr.ReadLine();
				while (answer != null && question != null)
				{
					this.Cards.Add(new Card(question, answer));
					question = sr.ReadLine();
					answer = sr.ReadLine();
				}
			}
		}

		public IEnumerable<Card> GetCards() => this.Cards;
		public void RemoveCard(Card card) => this.Cards.Remove(card);
	}
}
