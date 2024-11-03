using System.Text.Json.Serialization;

public class Links
{
	[JsonPropertyName("self")]
	public string? Self { get; set; }

	[JsonPropertyName("html")]
	public string? Html { get; set; }

	[JsonPropertyName("photos")]
	public string? Photos { get; set; }

	[JsonPropertyName("likes")]
	public string? Likes { get; set; }

	[JsonPropertyName("download")]
	public string? Download { get; set; }
}
