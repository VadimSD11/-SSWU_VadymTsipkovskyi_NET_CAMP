using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise____3
{
    internal class Task3
    {
        public static IEnumerable<string> GetWordsUni(string text)
        {
            string[] words = text.Split(new[] { ' ', '.', ',', ';', ':' }, StringSplitOptions.RemoveEmptyEntries);
            
            List<string> uniWords = new List<string>();

            foreach (var item1 in words)
            {
                bool isntUni = false;//зміна для пошуку унікальних слів
                foreach (var item2 in uniWords)
                {
                    if (string.Equals(item1, item2, StringComparison.OrdinalIgnoreCase))
                    {
                        isntUni = true;
                        break;
                    }
                }
                if (!isntUni)
                {
                    uniWords.Add(item1);
                    yield return item1;
                }
            }
        }

    }
}
