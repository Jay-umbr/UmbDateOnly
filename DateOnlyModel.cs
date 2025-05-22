using System.Text.Json.Serialization;

namespace DateOnly;

public class DateOnlyModel
{
    [JsonPropertyName("year")]
    public required int Year { get; init; }
    
    [JsonPropertyName("month")]
    public required int Month { get; init; }
    
    [JsonPropertyName("day")]
    public required int Day { get; init; }
}