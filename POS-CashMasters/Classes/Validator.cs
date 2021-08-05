using System;
using System.Globalization;

namespace POS_CashMasters.Classes
{
    public class Validator
    {
        public Validator()
        {

        }



        public decimal ValidateInput()
        {
            ConsoleKeyInfo inputKey;
            string backValue = "";
            decimal value;
          //  do
           // {
                do
                {
                    inputKey = Console.ReadKey(true);


                    if (char.IsDigit(inputKey.KeyChar))
                    {
                        if (inputKey.KeyChar == '0')
                        {
                            if (!backValue.StartsWith("0") || backValue.Contains('.'))
                                Write(ref backValue, inputKey);
                        }

                        else
                            Write(ref backValue, inputKey);
                    }

                    if (inputKey.KeyChar == '-' && backValue.Length == 0 ||
                        inputKey.KeyChar == '.' && !backValue.Contains(inputKey.KeyChar) &&
                        backValue.Length > 0)
                        Write(ref backValue, inputKey);

                    if (inputKey.Key == ConsoleKey.Backspace && backValue.Length > 0)
                    {
                        backValue = backValue.Substring(0, backValue.Length - 1);
                        Console.Write("\b \b");
                    }

                } while (inputKey.Key != ConsoleKey.Enter); //Loop until Enter key not pressed

                decimal.TryParse(backValue, out value);

            // } while (value == 0);
            

            return value;
        }

        public void Write(ref string backValue, ConsoleKeyInfo inputKey)
        {
            backValue += inputKey.KeyChar;
            Console.Write(inputKey.KeyChar);
            
        }

    }
}
