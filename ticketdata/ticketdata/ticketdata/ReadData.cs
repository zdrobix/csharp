using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UglyToad.PdfPig;
using UglyToad.PdfPig.Content;

namespace ticketdata
{
	public class ReadData
	{
		private string path;

		public ReadData(string path_)
		{
			this.path = path_;
		}

		public List<string>? Read ()
		{
			try
			{
				var data = new List<string>();
				var pdfFiles = Directory.EnumerateFiles(this.path, "*.pdf");
				foreach (var file in pdfFiles)
				{
					using ( var document = PdfDocument.Open(file))
					{
						var page = document.GetPage(1);
						string text = page.Text;
						Regex regexPattern = new Regex(".*(Title:.*Date:.*Time:.*)*.*www\.ourCinema\.(.*)");`
					}
				}
				return data;
			} catch (Exception e) { 
				Console.WriteLine(e.Message); 
				return null; 
			}
		}
	}
}
