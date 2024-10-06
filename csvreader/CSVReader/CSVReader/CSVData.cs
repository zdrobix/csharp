using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace csvread.data
{
	internal class CSVData
	{
		public string[] columns { get; }
		public IEnumerable<string[]> rows { get; }

		public CSVData(string[] columns_, IEnumerable<string[]> rows_)
		{
			this.columns = columns_;
			this.rows = rows_;
		}

		public string stringColumnNames() => string.Join(" ", this.columns.Select(col => col)) + '\n';

		public string stringRowNumber(int row) => string.Join(" ", this.rows.ElementAt(row).Select(rowN => rowN)) + '\n';

		public string stringData() {
			var result = this.stringColumnNames();
			for (int i = 0; i < this.rows.Count(); i ++)
			{
				result += this.stringRowNumber(i);
			}
			return result;
		}
	}
}
