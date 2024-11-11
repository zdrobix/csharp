
namespace stopwatch;

public class Application
{
	public static void Main(string[] args)
	{
		__Stopwatch.Start();
		for (int i = 0; i < 50000; i++)
			continue;
		__Stopwatch.Stop();
        Console.WriteLine(__Stopwatch.getElapsed()! + " elapsed");
			
	}
}
