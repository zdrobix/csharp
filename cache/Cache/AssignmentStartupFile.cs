using System.Runtime.InteropServices;

IDataDownloader dataDownloader = new SlowDataDownloader();
CachingSystem system = new CachingSystem(dataDownloader);

system.DownloadData("id1");
system.DownloadData("id2");
system.DownloadData("id3");
system.DownloadData("id1");
system.DownloadData("id2");
system.DownloadData("id3");

Console.ReadKey();

public interface IDataDownloader
{
	string DownloadData(string resourceId);
}

public class SlowDataDownloader : IDataDownloader
{
    public string DownloadData(string resourceId)
    {
        //let's imagine this method downloads real data,
        //and it does it slowly
        Thread.Sleep(1000);
        return $"Some data for {resourceId}";
    }
}

public class FastDataDownloader : IDataDownloader
{
	public string DownloadData(string resourceId)
	{
		return $"Some data for {resourceId}";
	}
}

public class CachingSystem
{
    private Dictionary<string, string> data = new Dictionary<string, string>();

    public CachingSystem (IDataDownloader _dataDownloader)
    {
        this.data = new Dictionary<string, string> ();
    }

    public void DownloadData(string resourceId)
    {
        DateTime now = DateTime.Now;    
        if (!this.data.ContainsKey(resourceId)) {
            this.data.Add(resourceId, new SlowDataDownloader().DownloadData(resourceId));
        }
        Console.WriteLine(new FastDataDownloader().DownloadData(resourceId));
        //sau doar Console.WriteLine(this.data[resourceId]);
    }

}

