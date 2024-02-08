using System.Text.Json.Serialization;

namespace WebAPI.Enums
{
    [JsonConverter(typeof(JsonConverter))]
    public enum TurnoEnum
    {
        Manha,
        Tarde,
        Noite
    }
}
