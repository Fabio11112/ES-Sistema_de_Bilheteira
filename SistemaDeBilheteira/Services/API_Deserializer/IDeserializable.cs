using Newtonsoft.Json;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public interface IDeserializable
{
    [JsonProperty("id")]
    public int Id { get; set; }
}