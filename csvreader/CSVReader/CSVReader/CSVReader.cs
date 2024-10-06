using csvread.data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvread.read
{
	internal class CSVReader
	{
		private string filePath;
		public CSVReader(string filePath_)
		{
			this.filePath = filePath_;
		}
		public CSVData read()
		{
			using (StreamReader streamReader = new StreamReader(filePath))
			{
				var columnNames = streamReader.ReadLine().Split(',');
				var rows = new List<string[]>();

				while (!streamReader.EndOfStream)
				{
					var cells = streamReader.ReadLine().Split(',');
					rows.Add(cells);
				}
				return new CSVData(columnNames, rows);
			}
		}

	}
}
