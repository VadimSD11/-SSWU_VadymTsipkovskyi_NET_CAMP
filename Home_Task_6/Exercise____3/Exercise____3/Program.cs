namespace Exercise____3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Vadym_Tsipkovskyi_Task_3");
            string text = "Some unique words words very unique, some ehm unique, words, letters, text";
            var uniqueWords = Task3.GetWordsUni(text);
            Console.WriteLine("Text:"+text);
            foreach (var word in uniqueWords)
            {
                Console.WriteLine(word);
            }
        }
    }
}