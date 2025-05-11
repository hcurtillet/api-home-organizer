using System.Text.Json.Serialization;

namespace HomeOrganizer.API.Dto.Task;

public class CreateTaskDto
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
    [JsonPropertyName("dueDt")]
    public string? DueDt { get; set; }
    [JsonPropertyName("dueTm")]
    public string? DueTm { get; set; }
    [JsonPropertyName("homeId")]
    public Guid HomeId { get; set; }
    [JsonPropertyName("userAccountIds")]
    public List<Guid>? UserAccountIds { get; set; } = new();
}