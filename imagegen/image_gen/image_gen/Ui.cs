using image_gen.starwars;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace image_gen
{
	internal class Ui
	{
		private ApiClient _apiClient;
		public Ui (ApiClient apiClient)
		{
			this._apiClient = apiClient;
		}
		public async Task Run()
		{
			while (true)
			{
				Console.Write("Enter a word: ");
				string? keyword = Console.ReadLine();
				if (keyword == "" || keyword == null)
					break;
				string endpoint = "search/photos?query=" + keyword + "&per_page=5";
				try
				{
					ApiResponse apiResponse = await this._apiClient.GetAsync<ApiResponse>(endpoint);
					await AsciiGen
						.GenerateAsciiArt(
							apiResponse.Results!
							.Where(response => response.Width >= 1920 && response.Height >= 1080)
							.First()
						);
				}
				catch (HttpRequestException e)
				{
					Console.WriteLine("error: " + e.Message);
				}
			}
		}
	}
}
