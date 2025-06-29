﻿using SistemaDeBilheteira.Services.Database.Entities.User;

namespace SistemaDeBilheteira.Services.Database.Entities.PaymentSystem;

public interface IPurchaseSystem
{
    bool Pay(PaymentMethod paymentMethod, AppUser user, Address? address = null);
    
}