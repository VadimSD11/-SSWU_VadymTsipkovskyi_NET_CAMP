using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_task_10
{
    public static class Task1
    {
        public static bool LunaAlgo(string number) {
            int sum = 0;
            bool isEven = false;

            for (int i = number.Length - 1; i >= 0; i--)
            {
                bool success = int.TryParse(number[i].ToString(), out int digit);

                if (!success)
                {
                  return false;
                }

                if (isEven)
                {
                    digit *= 2;
                    if (digit > 9)
                    {
                        digit -= 9;
                    }
            
                }
                sum += digit;
   
                isEven = !isEven;
            }

            return sum % 10 == 0;

        }
        public static string IdentifyCard(string number) {
            if (number.Length == 15 && (number.StartsWith("34") || number.StartsWith("37"))){
                return "American Express";
            }
            else if (number.Length == 16 && (number.StartsWith("51") || number.StartsWith("52")
                    || number.StartsWith("53") || number.StartsWith("55"))) {
                return "MasterCard";
            }
            else if ((number.Length == 13 || number.Length == 16) && number.StartsWith("4")) {
                return "Visa";
            }
            else { return "Unknown"; }
        
        }
        public static void WorkWithConsoleInput() {
            Console.Write("Вкажіть номер картки яку ви хочете перевірити: ");
            string number=Console.ReadLine();
            Console.WriteLine("Result: "+IsCardReal(number));
        }
        public static void WorkWithConsole() {
            string number1 = "378282246310005";
            Console.WriteLine("First Card # American Express # card_number = 378282246310005");
            Console.WriteLine("Resutl: "+IsCardReal(number1));
            string number2 = "5555555555554444";
            Console.WriteLine("Second Card # MasterCard # card_number =  5555555555554444");
            Console.WriteLine("Result: "+IsCardReal(number2));
        }
        public static string IsCardReal(string number) {
            if (LunaAlgo(number))
            {
                return $"Yes it is real\nIt's:{IdentifyCard(number)} ";
            }
            else { return "It is not real"; }
        }
    }
}
