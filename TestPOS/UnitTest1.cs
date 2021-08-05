using System;
using Xunit;
using POS_CashMasters.Classes;

namespace TestPOS
{
    
    public class BasicTest
    {
        [Fact]
        public void Test1()
        {
            var obj = new POS_CashMasters.Classes.Entries();
            var oCashier = new POS_CashMasters.Classes.CashierValidation();

            obj.dPrice = 100;
            obj.dPayment = 120;
            

        }

        
        public void Test2()
        {
            var obj = new POS_CashMasters.Classes.Utilities();

           
        }
    }
}
