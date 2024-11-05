using System;
using System.Drawing;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace image_gen
{
	public class AsciiGen
	{
		private static char[] AsciiChars = { '#', '@', '%', '=', '+', '*', ':', '-', '.', ' ' };
		//private static char[] AsciiChars = { 'W', 'M', 'B', 'T', 'X', 'x', 'I', '-', '.', ' ' };
		public AsciiGen() { }

		public static async Task GenerateAsciiArt(Result? result)
		{
			if (result?.Urls?.Full != null)
			{
				string generatedAsciiArt = await GenerateFromUrl(result.Urls.Full, Console.WindowWidth*2, Console.WindowHeight*2);
				Console.WriteLine(generatedAsciiArt);
			}
		}

		private static async Task<string> GenerateFromUrl (string imageUrl, int width, int height)
		{
			using HttpClient client = new HttpClient();
			using var stream = await client.GetStreamAsync(imageUrl);
			using var image = new Bitmap(stream);

			return ConvertToAscii(image, width, height);
		}

		private static string ConvertToAscii(Bitmap image, int consoleWidth, int consoleHeight)
		{
			double aspectRatio = (double)image.Width / image.Height;
			int width = consoleWidth;
			int height = (int)(consoleWidth / aspectRatio);
			if (height > consoleHeight)
			{
				height = consoleHeight;
				width = (int)(consoleHeight * aspectRatio);
			}
			using var resizedImage = new Bitmap(image, new Size(width, height));
			StringBuilder asciiArt = new StringBuilder();
			for (int y = 0; y < resizedImage!.Height; y++)
			{
				for (int x = 0; x < resizedImage.Width; x++)
				{
					Color pixelColor = resizedImage!.GetPixel(x, y);
					int grayValue = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;
					char asciiChar = GetAsciiChar(grayValue);
					asciiArt.Append(asciiChar);
				}
				asciiArt.AppendLine();
			}
			return asciiArt.ToString();
		}


		private static char GetAsciiChar(int grayValue)
		{
			int index = grayValue * (AsciiChars.Length - 1) / 255;
			return AsciiChars[index];
		}
	}

}

