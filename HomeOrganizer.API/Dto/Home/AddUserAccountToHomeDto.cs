using System.Text.Json.Serialization;
using HomeOrganizer.Domain.Enum;

namespace HomeOrganizer.API.Dto.Home;

public class AddUserAccountToHomeDto
{
    [JsonPropertyName("homeId")]
    public Guid HomeId { get; set; }
    [JsonPropertyName("userAccountId")]
    public Guid UserAccountId { get; set; }
    [JsonPropertyName("role")]
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public UserAccountHomeRole Role { get; set; } = UserAccountHomeRole.Child;
    
}