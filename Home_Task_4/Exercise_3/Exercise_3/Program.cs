﻿namespace Exercise_3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //завтра допишу
            Console.WriteLine("Hello, World!");
            BillingSystem bl = new BillingSystem("C:\\Users\\Vadim_y9xms2s\\source\\repos\\Exercise_3\\Exercise_3\\Bills.txt");
            Console.WriteLine();
            bl.PrintApartmentInfo(102);
            Console.WriteLine();
            bl.PrintOwnerWithMaxDebt(0.25m);
            Console.WriteLine();
            bl.PrintReport();
            Console.WriteLine($"Apartment with no consumption in this quarter: { bl.GetApartmentWithNoConsumption()}");
        }
    }
}