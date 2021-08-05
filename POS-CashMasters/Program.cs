using System;
using System.Threading;
using System.Configuration;
using System.Globalization;
using POS_CashMasters.Classes;
using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;
using System.Diagnostics;

namespace POS_CashMasters
{
    class Program
    {


        static void Main(string[] args)
        {
            try
            {
                Logger.Info("Application started.", "CashMaster");

                Utilities oUtil = new Utilities(); // Identify current culture Info or assign the one on app.config File

                Validator oValid = new Validator();
                CashierValidation oC = new CashierValidation();

                Console.WriteLine("Welcome to Cash Masters");
                Console.WriteLine("------------------------\n");
                TypesOfCurrencies oj = new TypesOfCurrencies();
                ValidationResult results;
                do
                {
                    Console.WriteLine("Price/Cost: ");

                    decimal dPrice;
                    Entries oEnt = new Entries();
                    dPrice = oValid.ValidateInput(); // validating only numeric values when typing
                    oEnt.dPrice = dPrice;
                    string sSymbol = NumberFormatInfo.CurrentInfo.CurrencySymbol.ToString();
                    Console.Write("\r" + sSymbol + " " + string.Format("{0:0,0.00}", dPrice)); // displaying the entry on correct format


                    Console.WriteLine("\nCash In: ");
                    decimal dCash = oValid.ValidateInput();
                    oEnt.dPayment = dCash;
                    Console.Write("\r" + sSymbol + " " + string.Format("{0:0,0.00}", dCash));

                    
                    results = oC.Validate(oEnt); // applying validations of Qtys for the entries

                    if (!results.IsValid)
                        foreach (var failure in results.Errors)
                        {
                            Console.WriteLine("\nError: " + failure.ErrorMessage);
                        }
                    else
                    {
                        //id entires are valid calculate the change and minimum denominations

                        decimal dChange = dCash - dPrice;

                        oUtil.CalculateChange(dChange,sSymbol);

                    }
                } while (!results.IsValid);

            }
            catch (NullReferenceException nullEx)
            {
                //Logger.Error(nullEx, "Main");
                Console.WriteLine(nullEx.Message);
            }
            catch (InvalidCastException inEx)
            {
                //Logger.Error(inEx, "Main");
                Console.WriteLine(inEx.Message);
            }
            catch (InvalidOperationException inOEx)
            {
                //Logger.Error(inOEx, "Main");
                Console.Write("Invalid operation. Please try again.");
            }
            catch (FormatException FormEx)
            {
                //Logger.Error(FormEx, "Main");
                Console.Write("Not a valid format. Please try again.");
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "Main");
                Console.Write("Error occurred! Please try again." + ex.Message);
            }
           
        }
    }
}
