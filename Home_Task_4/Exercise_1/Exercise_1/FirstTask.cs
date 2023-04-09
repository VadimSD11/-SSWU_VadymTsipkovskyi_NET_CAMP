using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Exercise_1
{
    public static class FirstTask
    {
        public static string[] GetStringArray(string str) {
            char[] signs = { '.', '!', '?' };//роздільні знаки

            string[] sentences = str.Split(signs);//створення масиву речень
            List<string> sentencesWithBrackets = new List<string>();//колекція стрічок із дужками
            foreach (string sentence in sentences)//пошук речень із дужками
            {
                if (sentence.Contains("(") && sentence.Contains(")"))
                {
                    sentencesWithBrackets.Add(sentence.Trim());//додання до колекції речення і виділення пустих місць перед ним якщо вони є
                }
            }
            return sentencesWithBrackets.ToArray();

        }
        public static void PrintStringArray(string[] str) {
            foreach (string item in str)
            {
                Console.WriteLine(item);
            }
        }


    }
}
