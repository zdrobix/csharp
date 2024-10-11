namespace starwars
{
	internal interface IApiDataReader
	{
		//Interface for the api reader.
		Task<string> Read(string baseAddress, string requestUri);
	}
}
