using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise___2
{
    public static class Task2
    {
        public static IEnumerable<int> SortArr(params int[][] arrays)
        {
            List<int> arrs = new List<int>();
            foreach (var array in arrays)//додаємо усі масиви у купу
            {
                arrs.AddRange(array);
            }
            
            arrs.Sort();//сортуємо
            foreach (var item in arrs)
            {
                yield return item;//повертаємо значення
            }
        }
    }
}
