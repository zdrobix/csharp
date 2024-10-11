using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

namespace starwars
{	
	public record Root(
		[property: JsonPropertyName("count")] int count,
		[property: JsonPropertyName("next")] string next,
		[property: JsonPropertyName("previous")] object previous,
		[property: JsonPropertyName("results")] IReadOnlyList<Result> results);
}
