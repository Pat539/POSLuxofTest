using System;
using System.Configuration;
using System.Globalization;
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
    }
}
