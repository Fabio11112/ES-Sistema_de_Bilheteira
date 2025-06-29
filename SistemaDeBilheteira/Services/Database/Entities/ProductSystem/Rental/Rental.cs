﻿    namespace SistemaDeBilheteira.Services.Database.Entities.ProductSystem.Rental;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Rental : Product
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        // DB mapped
        public string StateName { get; set; } = "Requested";

        // Transient runtime logic handler
        [NotMapped]
        public RentalState State
        {
            get => StateFactory.Create(StateName);
            set => StateName = value.Name;
        }

        public void NextStep() => State.Next(this);
        public void Cancel() => State.Cancel(this);
        public override string GetProductType()
        {
            return "Rental";
        }

        public override string PrintDetails()
        {
            return $"Rental valid until {EndDate:dd/MM/yyyy}";
        }
    }
