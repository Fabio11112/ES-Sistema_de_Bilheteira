using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;
using SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental.RentalStates;
using System;

namespace SistemaDeBilheteira.Services.Database.Builders;

public class RentalBuilder
{
    private readonly Rental _rental = new();

    public RentalBuilder WithMovie(string movieId)
    {
        _rental.MovieId = movieId;
        return this;
    }

    public RentalBuilder WithPrice(double price)
    {
        _rental.Price = price;
        return this;
    }

    public RentalBuilder WithStartDate(DateTime startDate)
    {
        _rental.StartDate = startDate;
        return this;
    }

    public RentalBuilder WithEndDate(DateTime endDate)
    {
        _rental.EndDate = endDate;
        return this;
    }

    public RentalBuilder WithState(RentalState state)
    {
        _rental.State = state;
        _rental.StateName = state.Name;
        return this;
    }

    public Rental Build()
    {
        _rental.CreatedAt = DateTime.Now;
        return _rental;
    }
}
    
