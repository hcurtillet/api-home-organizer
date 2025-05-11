using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Base;
using HomeOrganizer.API.Dto.Task;

namespace HomeOrganizer.API.Dto.Home;

public class HomeDto : DtoBase
{
    [JsonPropertyName("name")] public string Name { get; set; }
    [JsonPropertyName("userAccounts")] public List<UserAccountHomeDto> UserAccounts { get; set; } = new();
    [JsonPropertyName("tasks")] public List<TaskDto> Tasks { get; set; } = new();
}