using image_gen.starwars;
using System.Data;

namespace image_gen
{
	internal class Application
	{
		public static async Task Main(string[] args)
		{
			await new Ui(
				new ApiClient(
					GetAccess.getCredentials()!
				)
			).Run();
		}
	}
}