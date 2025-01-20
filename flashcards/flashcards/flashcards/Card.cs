using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace flashcards
{
	internal class Card
	{
		public string Question { get; set; }
		public string Answer { get; set; }
		public Card(string question_, string answer_)
		{
			this.Question = question_;
			this.Answer = answer_;
		}
	}
}
