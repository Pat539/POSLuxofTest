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
        public CashierValidation()
        {

            RuleFor(entries => entries.dPrice).NotEmpty().WithMessage("Price cannot be zero or empty").WithName("Price");
            RuleFor(entries => entries.dPayment).NotEmpty().WithMessage("Cash/Payment cannot be zero or empty");
            RuleFor(entries => entries.dPayment).GreaterThanOrEqualTo(entries => entries.dPrice).WithMessage("Cash/Payment must be greater/equal than price");
           
        }

    }


  /*  <system.diagnostics>
        <trace autoflush = "true" indentsize="4">
          <listeners>
            <add name = "myListener" type="System.Diagnostics.TextWriterTraceListener" initializeData="CashApp.log" />
            <remove name = "Default" />
          </ listeners >
        </ trace >
  </ system.diagnostics > */


}

