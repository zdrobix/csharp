using System.Text.Json.Serialization;

public class User
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("username")]
	public string? Username { get; set; }

	[JsonPropertyName("name")]
	public string? Name { get; set; }

	[JsonPropertyName("first_name")]
	public string? FirstName { get; set; }

	[JsonPropertyName("last_name")]
	public string? LastName { get; set; }

	[JsonPropertyName("instagram_username")]
	public string? InstagramUsername { get; set; }

	[JsonPropertyName("twitter_username")]
	public string? TwitterUsername { get; set; }

	[JsonPropertyName("portfolio_url")]
	public string? PortfolioUrl { get; set; }

	[JsonPropertyName("profile_image")]
	public ProfileImage? ProfileImage { get; set; }

	[JsonPropertyName("links")]
	public Links? Links { get; set; }
}
