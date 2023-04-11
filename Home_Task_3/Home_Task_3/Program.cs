using System.Text;

namespace Home_Task_3
{
    internal class Program
    {1. задача. Класи користувач та Вежа взаємодіють.
        static void Main(string[] args)
        {

            Console.OutputEncoding = UTF8Encoding.UTF8;
            string inputstring = "Fast APPLE test Rest Dust test Fest Notatest letter";
            string word = "test";
            string repacement = "==REPLACED==";
            Console.WriteLine("Наш текст перед виконанням завданнь: "+inputstring);
            Console.WriteLine("Iндекс другого входження заданої підстрічки в текст:" + TasksAboutStirngs.IndexOfSecond(word, inputstring));
            Console.WriteLine("Kількість слів, що починаються з великої літери:" + TasksAboutStirngs.AmountOfWords_BigLetters(inputstring));
            Console.WriteLine("Текст пілся заміни всіх слів що містять подвоєння літер:" + TasksAboutStirngs.ReplaceDoubleLetters(inputstring,repacement));
        }
    }
}
