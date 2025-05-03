using SistemaDeBilheteira.Services.Database.Entities;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class AddressBuilder
{
    private Address Address { get; set; } = new();

    public AddressBuilder WithStreetLine1(string streetLine1)
    {
        Address.StreetLine1 = streetLine1;
        return this;
    }
    
    public AddressBuilder WithStreetLine2(string streetLine2)
    {
        Address.StreetLine2 = streetLine2;
        return this;
    }
    
    public AddressBuilder WithCity(string city)
    {
        Address.City = city;
        return this;
    }
    
    public AddressBuilder WithState(string state)
    {
        Address.State = state;
        return this;
    }
    
    public AddressBuilder WithZipCode(string zipCode)
    {
        Address.ZipCode = zipCode;
        return this;
    }
    
    public AddressBuilder WithCountry(string country)
    {
        Address.Country = country;
        return this;
    }
    
    public AddressBuilder WithIsDefault(bool isDefault)
    {
        Address.IsDefault = isDefault;
        return this;
    }
    
    public AddressBuilder WithUserId(string userId)
    {
        Address.AppUserId = userId;
        return this;
    }
    
    public Address Build()
    {
        return Address;
    }
}