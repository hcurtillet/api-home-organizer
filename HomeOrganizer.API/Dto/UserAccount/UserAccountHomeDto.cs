using System.Text.Json.Serialization;
using HomeOrganizer.API.Dto.Home;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.API.Dto.UserAccount;

public class UserAccountHomeDto: HomeDto
{
    [JsonPropertyName("userAccountHomeRole")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserAccountHomeRole Role { get; set; }
}