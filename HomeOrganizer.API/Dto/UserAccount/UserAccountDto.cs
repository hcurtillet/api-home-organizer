using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Base;

namespace HomeOrganizer.API.Dto.UserAccount;

public class UserAccountDto : DtoBase
{
    [JsonPropertyName("email")] public string Email { get; set; } = string.Empty;
    [JsonPropertyName("firstname")] public string Firstname { get; set; } = string.Empty;
    [JsonPropertyName("lastname")] public string Lastname { get; set; } = string.Empty;
    [JsonPropertyName("homes")] public List<UserAccountHomeDto> Homes { get; set; } = new();
}