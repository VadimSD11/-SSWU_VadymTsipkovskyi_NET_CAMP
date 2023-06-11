using System;

public class QuickSort<T>
{
    public static void Sort(T[] array, Func<T, T, int> comparer, Func<T[], int, int, int> pivotSelector)
    {
        Sort(array, 0, array.Length - 1, comparer, pivotSelector);
    }

    private static void Sort(T[] array, int left, int right, Func<T, T, int> comparer, Func<T[], int, int, int> pivotSelector)
    {
        if (left < right)
        {
            int pivotIndex = pivotSelector(array, left, right);
            pivotIndex = Partition(array, left, right, comparer, pivotIndex);
            Sort(array, left, pivotIndex - 1, comparer, pivotSelector);
            Sort(array, pivotIndex + 1, right, comparer, pivotSelector);
        }
    }

    private static int Partition(T[] array, int left, int right, Func<T, T, int> comparer, int pivotIndex)
    {
        T pivotValue = array[pivotIndex];
        Swap(array, pivotIndex, right);

        int i = left;

        for (int j = left; j < right; j++)
        {
            if (comparer(array[j], pivotValue) <= 0)
            {
                Swap(array, i, j);
                i++;
            }
        }

        Swap(array, i, right);
        return i;
    }

    private static void Swap(T[] array, int i, int j)
    {
        T temp = array[i];
        array[i] = array[j];
        array[j] = temp;
    }
}


