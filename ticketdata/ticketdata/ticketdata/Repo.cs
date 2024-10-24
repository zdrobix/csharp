using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ticketdata
{
	public class Repo
	{
		private ReadData? readData;
		private List<Ticket>? ticketList;

		public Repo() { }
		public void loadData(string path)
		{
			this.readData = new ReadData(path);
			try
			{
				this.ticketList = new List<Ticket>();
				List<List<string>?>? data = this.readData.Read();
				foreach (List<string>? list in data!)
				{
					for (int i = 1; i < list!.Count - 3; i += 3)
					{
						this.ticketList.Add(
						new Ticket(
							list![i],
							list![i + 1],
							list![i + 2],
							list![list!.Count - 1]
							)
						);
					}
				}

			}
			catch (Exception e){
				throw new Exception(e.Message);
			}

		}
		public string? listTickets() => string.Join('\n', this.ticketList.Select(ticket => ticket.toString()));
		
	}
}
