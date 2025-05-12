using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Base;
using HomeOrganizer.API.Dto.UserAccount;
using TaskStatus = HomeOrganizer.Domain.Enum.TaskStatus;


namespace HomeOrganizer.API.Dto.Task;

public class TaskDto: DtoBase
{
    [JsonPropertyName("description")]
    public string Description { get; set; } = null!;
    [JsonPropertyName("dueDt")]
    public string? DueDt { get; set; }
    [JsonPropertyName("dueTm")]
    public string? DueTm { get; set; }
    [JsonPropertyName("taskStatus")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public TaskStatus TaskStatus { get; set; }
    [JsonPropertyName("home")]
    public HomeDto Home { get; set; } = null!;
    [JsonPropertyName("userAccounts")]
    public List<UserAccountDto> UserAccounts { get; set; } = new();
}