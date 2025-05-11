using System.Text.Json.Serialization;
using TaskStatus = HomeOrganizer.Domain.Enum.TaskStatus;

namespace HomeOrganizer.API.Dto.Task;

public class UpdateTaskDto
{
    [JsonPropertyName("description")]
    public string? Description { get; set; }
    [JsonPropertyName("dueDt")]
    public string? DueDt { get; set; }
    [JsonPropertyName("dueTm")]
    public string? DueTm { get; set; }

    [JsonPropertyName("taskStatus")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskStatus TaskStatus { get; set; }
    [JsonPropertyName("userAccountIdToAdd")]
    public List<Guid>? UserAccountIdsToAdd { get; set; } = [];

    [JsonPropertyName("userAccountIdsToRemove")]
    public List<Guid>? UserAccountIdsToRemove { get; set; } = [];
}