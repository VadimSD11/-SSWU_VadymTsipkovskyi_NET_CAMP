namespace Exercise___2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tsipkovskyi_Vadym_Task_2");
            int[] arr1 = { 1, 3, 5 };
            int[] arr2 = { 2, 4, 6 };
            int[] arr3 = { 0, 8, 9 };
            int[] arr4 = { 101, 20, 13 ,14};
            

            var res = Task2.SortArr(arr1, arr2, arr3,arr4);
            foreach (var item in res)
            {
                Console.Write(item+" ");
            }
        }
    }
}