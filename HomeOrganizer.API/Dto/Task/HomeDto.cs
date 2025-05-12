using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Base;
using HomeOrganizer.API.Dto.Home;

namespace HomeOrganizer.API.Dto.Task;

public class HomeDto : DtoBase
{
    [JsonPropertyName("name")] public string Name { get; set; }
}