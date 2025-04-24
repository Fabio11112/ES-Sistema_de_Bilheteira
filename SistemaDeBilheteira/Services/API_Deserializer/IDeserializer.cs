using RestSharp;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public interface IDeserializer<T> where T : IDeserializable
{
    public Task<T?>? Fetch(string url);
}