using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ticketdata
{
	public class Ticket
	{
		private string filmName;
		private DateOnly dateTime;
		private TimeOnly timeSpan;
		private static Dictionary<string, string> domainFormat = new Dictionary<string, string>
		{
			["com"] = "en-US",
			["fr"] = "fr-FR",
			["jp"] = "ja-JP",
		};

		public Ticket(string filmName_, DateOnly dateTime_, TimeOnly timeSpan_)
		{
			this.filmName = filmName_;
			this.dateTime = dateTime_;
			this.timeSpan = timeSpan_;
		}
		public Ticket(string filmName_, string dateTime_, string timeSpan_, string domain)
		{
			this.filmName = filmName_;
			this.dateTime = DateOnly.Parse(
										dateTime_,
										new CultureInfo(domainFormat[domain]));
			this.timeSpan = TimeOnly.Parse(
										timeSpan_,
										new CultureInfo(domainFormat[domain]));
		}

		public string getFilmName() => this.filmName;
		public DateOnly getDateTime() => this.dateTime;
		public TimeOnly getTimeSpan() => this.timeSpan;
		public string toString() => string.Format("{0, -20} {1, -10} {2, -10}", this.filmName, this.dateTime, this.timeSpan);
	}
}
