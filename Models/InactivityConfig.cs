using Newtonsoft.Json;

namespace test2.Models
{
    public record InactivityConfig(
        [property: JsonProperty("inactivityTime")] int InactivityTime,
        [property: JsonProperty("passwordInactivityTime")] int PasswordInactivityTime);
}