using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;

namespace POS_CashMasters.Classes
{
    public class Utilities
    {
        public  Utilities()
        {
            AssignCulture();
        }
        public  string AssignCulture()
        {

            try
            {
                string sCulture = ConfigurationManager.AppSettings.Get("CultureInfo");
                // Create a CultureInfo object for French in France.


                string a = NumberFormatInfo.CurrentInfo.CurrencySymbol.ToString();
                if (sCulture.ToString().Trim().Length > 0)
                    //If there is an specific code on the config use it
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(sCulture);
                else
                {
                    // USe the current one detectted
                    Console.WriteLine(Thread.CurrentThread.CurrentCulture.LCID);
                }

                return sCulture;
            }
            catch(Exception ex)
            {
                throw;
            }
            
        }

        public void CalculateChange(decimal dChange, string sCurrencySymbol)
        {
            try
            {        
                TypesOfCurrencies obj = new TypesOfCurrencies();
                var bills = obj.CurrValues1.FirstOrDefault(x => x.Key == Thread.CurrentThread.CurrentCulture.Name).Value; // getting the array for the currency identified
                //using Linq to return the change usign LINQ
                var breakdown =
                    bills
                        .OrderByDescending(x => x)
                        .Aggregate(new { dChange, bills = new List<decimal>() },
                            (a, b) =>
                            {

                                var v = a.dChange;
                                while (v >= b)
                                {
                                    a.bills.Add(b);
                                    v -= b;
                                }
                                return new { dChange = v, a.bills };

                            })
                        .bills
                        .GroupBy(x => x)
                        .Select(x => new { Bill = x.Key, Count = x.Count() });
                    


                if (breakdown.ToArray().Length == 0)
                    Console.WriteLine("\nChange $0.0 \n Thanks for your purchase!");
                else
                {
                    Console.WriteLine("\nPlease return as change " + sCurrencySymbol + " " + string.Format("{0:0,0.00}", dChange)
                    + " in the following denomination");
                    foreach (var i in breakdown)
                    {
                        Console.WriteLine(i.Count + " Bill of " + sCurrencySymbol + i.Bill + "  ");
                    }
                    Console.WriteLine("\nThanks for your purchase!");

                }
            }
            catch (Exception ex)
            {
                throw;
            }

        }
    }
}
