using System.Text.Json.Serialization;

public class ApiResponse
{
	[JsonPropertyName("total")]
	public int Total { get; set; }

	[JsonPropertyName("total_pages")]
	public int TotalPages { get; set; }

	[JsonPropertyName("results")]
	public IEnumerable<Result?>? Results { get; set; }
}
