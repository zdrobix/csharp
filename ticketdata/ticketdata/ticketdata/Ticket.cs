using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ticketdata
{
	public class Ticket
	{
		private string filmName;
		private DateTime dateTime;
		private TimeSpan timeSpan;

		public Ticket(string filmName_, DateTime dateTime_, TimeSpan timeSpan_)
		{
			this.filmName = filmName_;
			this.dateTime = dateTime_;
			this.timeSpan = timeSpan_;
		}

		public string getFilmName() => this.filmName;
		public DateTime getDateTime() => this.dateTime;
		public TimeSpan getTimeSpan() => this.timeSpan;
	}
}
