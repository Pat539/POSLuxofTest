using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace POS_CashMasters.Classes
{
    public class TypesOfCurrencies
    {

        //Add more arrays as currencies need it.
        private decimal[] aUS = { 0.01M, 0.05M, 0.10M, 0.25M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M };
        private decimal[] aMEX = { 0.05M, 0.10M, 0.20M, 0.50M, 1.00M, 2.00M, 5.00M, 10.00M, 20.00M, 50.00M, 100.00M, 200.00M };
       // private decimal[] aMEX2 = { 20.00M, 50.00M, 100.00M, 200.00M };

        Dictionary<string, decimal[]> CurrValues = new Dictionary<string, decimal[]>();

        public TypesOfCurrencies ()
        {

                CurrValues1.Add("en-US", aUS);
                CurrValues1.Add("es-MX", aMEX);
        }

        public Dictionary<string, decimal[]> CurrValues1 { get => CurrValues; set => CurrValues = value; }

    }
} 
    

