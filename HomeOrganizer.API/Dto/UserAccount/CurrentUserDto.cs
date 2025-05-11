using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Base;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.API.Dto.UserAccount;

public class CurrentUserDto : DtoBase
{
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;
    [JsonPropertyName("firstname")] public string Firstname { get; set; } = string.Empty;
    [JsonPropertyName("lastname")] public string Lastname { get; set; } = string.Empty;
    [JsonPropertyName("homeRoles")]
    public Dictionary<Guid, UserAccountHomeRole> HomeRoles { get; } = new();
}