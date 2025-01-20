using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace flashcards
{
	internal class Service
	{
		private Repo Repository;
		private Random Rand = new Random();
		public Service (Repo repository_) => this.Repository = repository_;
		public Card GetRandomCard()
		{
			var index = this.Rand.Next(0, this.Repository.GetCards().Count());
			var card = this.Repository.GetCards()
				.ElementAt(index);
			this.Repository.RemoveCard(card);
			return card;
		}
	}
}
