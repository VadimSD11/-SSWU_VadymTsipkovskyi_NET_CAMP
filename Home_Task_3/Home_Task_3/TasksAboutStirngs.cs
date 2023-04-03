using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Home_Task_3
{
    public static class TasksAboutStirngs
    {
        public static  int? IndexOfSecond(string word, string _string) {
            
            int firstIndex = _string.IndexOf(word);//пошук першого входження підстрічки у строку
            
            if (firstIndex == -1) { return null; }//якщо підстрічка взагалі відсутня у строці повертаємо null
            
            int secondIndex = _string.IndexOf(word, firstIndex + 1);//пошук другого входження підстрічки у строку
            
            if (secondIndex != -1) { return secondIndex; }//якщо знайшли повертаємо індекс інакше null
            else { return null; }
        }
        public static int AmountOfWords_BigLetters(string _string) {
            
            string[] words = _string.Split(' ');// розділення строки на слова
            int counter = 0;//кількість слів із великої літери
            
            foreach (string word in words)//цикл пошуку слів 
            {
                if (word.Length > 0 && char.IsUpper(word[0]))
                {
                    counter++;
                }
            }
            return counter;

        }
        public static string ReplaceDoubleLetters(string _string,string replacetxt) {
           
            string[] words = _string.Split(' ');// розділення строки на слова
            for (int i = 0; i < words.Length; i++)
            {
                string word = words[i];
                bool dbLetters = false;//змінна для перевірки наявності подвійних літер

                // Перевірка на присутність подвійних літер
                for (int j = 0; j < word.Length - 1; j++)
                {
                    if (word[j] == word[j + 1])
                    {
                        dbLetters = true;
                        break;
                    }
                }

                // якщо у слові є подвійні літери заміняємо на наш текст
                if (dbLetters)
                {
                    words[i] = replacetxt;
                }
            }

            // Створення новго тексту
            string output = string.Join(' ', words);
            return output;

        }

    }
}
