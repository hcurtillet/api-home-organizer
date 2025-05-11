using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.UserAccount;
using HomeOrganizer.API.Extensions;
using HomeOrganizer.Domain.Entities;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.API.Dto.Home;

public class UserAccountHomeDto: UserAccountDto
{
    [JsonPropertyName("userAccountHomeRole")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserAccountHomeRole Role { get; set; }
}