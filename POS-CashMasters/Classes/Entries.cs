using System;
using FluentValidation;
namespace POS_CashMasters.Classes
{
    public class Entries
    {
        public decimal dPrice { get; set; }
        public decimal dPayment { get; set; }

        public Entries()
        {
        }
    }

    public class CashierValidation : AbstractValidator<Entries>
    {
        //adding rules to validate the entries
        public CashierValidation()
        {

            RuleFor(entries => entries.dPrice).NotEmpty().WithMessage("\nPrice cannot be zero or empty").WithName("Price");
            RuleFor(entries => entries.dPayment).NotEmpty().WithMessage("\nCash/Payment cannot be zero or empty");
            RuleFor(entries => entries.dPayment).GreaterThanOrEqualTo(entries => entries.dPrice).WithMessage("\nCash/Payment must be greater/equal than price");
           
        }

    }
}

