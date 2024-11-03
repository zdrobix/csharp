using System.Text.Json.Serialization;

public class ProfileImage
{
	[JsonPropertyName("small")]
	public string? Small { get; set; }

	[JsonPropertyName("medium")]
	public string? Medium { get; set; }

	[JsonPropertyName("large")]
	public string? Large { get; set; }
}
