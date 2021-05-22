using System;
using CarDealer.Entities;
using FluentValidation;

namespace CarDealer.API
{
    public class CarValidator : AbstractValidator<Car>
    {
        public CarValidator()
        {
            RuleFor(car => car.Brand).NotNull();
        }
    }
}
