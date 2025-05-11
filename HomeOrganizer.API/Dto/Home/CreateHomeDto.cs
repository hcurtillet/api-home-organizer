using System.Text.Json.Serialization;

namespace HomeOrganizer.API.Dto.Home;

public class CreateHomeDto
{
    [JsonPropertyName("name")] public string Name { get; set; }
}