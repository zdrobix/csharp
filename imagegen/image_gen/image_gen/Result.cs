using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

public class Result
{
	[JsonPropertyName("id")]
	public string? Id { get; set; }

	[JsonPropertyName("created_at")]
	public DateTime CreatedAt { get; set; }

	[JsonPropertyName("width")]
	public int Width { get; set; }

	[JsonPropertyName("height")]
	public int Height { get; set; }

	[JsonPropertyName("color")]
	public string? Color { get; set; }

	[JsonPropertyName("blur_hash")]
	public string? BlurHash { get; set; }

	[JsonPropertyName("likes")]
	public int Likes { get; set; }

	[JsonPropertyName("liked_by_user")]
	public bool LikedByUser { get; set; }

	[JsonPropertyName("description")]
	public string? Description { get; set; }

	[JsonPropertyName("user")]
	public User? User { get; set; }

	[JsonPropertyName("current_user_collections")]
	public List<object>? CurrentUserCollections { get; set; }

	[JsonPropertyName("urls")]
	public Urls? Urls { get; set; }

	[JsonPropertyName("links")]
	public Links? Links { get; set; }
}
