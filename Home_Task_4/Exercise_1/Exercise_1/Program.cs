using System.Runtime.InteropServices;
using System.Text;

namespace Exercise_1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = UTF8Encoding.UTF8;
          
            
            string englishText = @"This is a sentence (with smtn in brackets).
                                                Another sentence with ( information in brackets)!  
\n Third sentence without info in brackets.
    Sentence 4 with (brakcets)?";

            Console.WriteLine("Текст англійською мовою:");
            Console.WriteLine(englishText);
            string[] sentences = FirstTask.GetStringArray(englishText);//отримання масиву речень із дужками
           
            Console.WriteLine();
            Console.WriteLine("Bсі речення, які містять інформацію в дужках:");
            FirstTask.PrintStringArray(sentences);

            string ukrainianText = @"Перше речення із (дужками)! 
                    Друге речення.
                    Речення номер (три)!
                    Останнє (речення)?";

            Console.WriteLine("\nУкраїнський текст:");
            Console.WriteLine(ukrainianText);
            string[] uaSentences =FirstTask.GetStringArray(ukrainianText);
            Console.WriteLine();
            Console.WriteLine("Bсі речення, які містять інформацію в дужках:");
            FirstTask.PrintStringArray(uaSentences);
        }
    }
}