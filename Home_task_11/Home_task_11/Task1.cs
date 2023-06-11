using System;

public class Task1
{
    public static void Execute()
    {
        //опорний елемент задається функцією

        Console.WriteLine("Task 1");
        int[] array1 = { 5, 2, 9, 1, 7 };
        Console.WriteLine("Array before quicksort(Last element)");
        Console.Write(string.Join(", ", array1));

        QuickSort<int>.Sort(array1, (a, b) => a.CompareTo(b), (array, left, right) => left);
        Console.WriteLine();
        Console.WriteLine("Array after quicksort");
        Console.Write(string.Join(", ", array1));
        Console.WriteLine();
        string[] array2 = { "apple", "orange", "banana", "pear" };
        Console.WriteLine();
        Console.WriteLine("Array before quicksort(Random element)");
        Console.Write(string.Join(", ", array2));
        QuickSort<string>.Sort(array2, (a, b) => a.Length.CompareTo(b.Length), (array, left, right) => new Random().Next(left, right + 1));
        Console.WriteLine();
        Console.WriteLine("Array after quicksort");
        Console.Write(string.Join(", ", array2));
        Console.WriteLine();
        double[] array3 = { 9.5, 5.1, 7.6, 2.8, 1.9, 6.3, 3.6, 8.7, 4.2 };
        Console.WriteLine();
        Console.WriteLine("Array before quicksort(Median)");
        Console.Write(string.Join(", ", array3));
        QuickSort<double>.Sort(array3, (a, b) => a.CompareTo(b), (array, left, right) => GetMedianIndex(array, left, right));
        Console.WriteLine();
        Console.WriteLine("Array after quicksort");
        Console.Write(string.Join(", ", array3));
        Console.WriteLine();
    }
    private static int GetMedianIndex<T>(T[] array, int left, int right)
    {
        int mid = (left + right) / 2;
        T a = array[left];
        T b = array[mid];
        T c = array[right];

        if (Comparer<T>.Default.Compare(a, b) > 0)
        {
            if (Comparer<T>.Default.Compare(b, c) > 0)
                return mid;
            else if (Comparer<T>.Default.Compare(a, c) > 0)
                return right;
            else
                return left;
        }
        else
        {
            if (Comparer<T>.Default.Compare(a, c) > 0)
                return left;
            else if (Comparer<T>.Default.Compare(b, c) > 0)
                return right;
            else
                return mid;
        }
    }
}
