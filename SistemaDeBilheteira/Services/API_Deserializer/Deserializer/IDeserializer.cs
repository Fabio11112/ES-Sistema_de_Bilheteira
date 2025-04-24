using RestSharp;

namespace SistemaDeBilheteira.Services.API_Deserializer;

public interface IDeserializer<T> 
{
    public Task<T?>? Fetch(string url);
}