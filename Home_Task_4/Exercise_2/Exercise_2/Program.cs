using System.Text;
using System.Text.RegularExpressions;

namespace Exercise_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;

            string txt = "AAAA vadim.tsipkovskyi@nure.ua\tvad1m@gmail.com @invalid email3@.com\nemail4@com invalid@email email5@.com.ua email6@example.123 nonreal@gma_il.com emailreal@mail.ua dbdbdb vadym_mail_real@gmail.com";
            string[] realEmails = EmailValidation.GetRealEmails(txt);
            string[] nonRealEmails = EmailValidation.GetWrongEmails(txt);
            Console.WriteLine("Реальнi адреси:");
            foreach (string realEmail in realEmails) { Console.WriteLine(realEmail); }
            Console.WriteLine();
            Console.WriteLine("Лексеми, які не є правильними електронними адресами,але містять в своєму записі символ @:");
            foreach (string nonRealEmail in nonRealEmails)
            {
                Console.WriteLine(nonRealEmail);
            }
        }

       
    }
}