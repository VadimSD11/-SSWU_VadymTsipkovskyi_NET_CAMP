using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class BillingSystem
    {
        private List<Apartment> apartments;
        private static int quarter;
        private static string[] monthNames = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

        public BillingSystem(string filePath)
        {
            apartments = new List<Apartment>();
            //using (StreamWriter sw = new StreamWriter(filePath))
            //{
            //    sw.WriteLine("4 1");
            //    sw.WriteLine("101\tStreet one\tJane Doe\t500\t650\t10.01.22");
            //    sw.WriteLine("102\tStreet two\tJohn Doe\t300\t400\t10.03.22");
            //    sw.WriteLine("103\tStreet three\tJack Smith\t200\t250\t10.02.22");
            //    sw.WriteLine("104\tStreet four\tName Surname\t250\t250\t12.02.22");

            //}
            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line = sr.ReadLine();
                    string[] firstLine = line.Split(' ', StringSplitOptions.TrimEntries);

                    int numOfApartments = int.Parse(firstLine[0]);
                    quarter = int.Parse(firstLine[1]);

                    for (int i = 0; i < numOfApartments; i++)
                    {
                        line = sr.ReadLine();
                        Console.WriteLine(line);
                        string[] apartmentInfo = line.Split('\t', ' ', StringSplitOptions.TrimEntries);

                        if (apartmentInfo.Length != 6)
                        {
                            Console.WriteLine(apartmentInfo.Length);
                            Console.WriteLine($"Apartment info error: {line}");
                            continue;
                        }

                        int apartmentNumber;

                        if (!int.TryParse(apartmentInfo[0], out apartmentNumber))
                        {
                            Console.WriteLine($"Apartment number error: {apartmentInfo[0]}");
                            continue;
                        }
                        string adress = apartmentInfo[1];
                        string ownerName = apartmentInfo[2];

                        int initialReading;

                        if (!int.TryParse(apartmentInfo[3], out initialReading))
                        {
                            Console.WriteLine($"Initial reading error: {apartmentInfo[3]}");
                            continue;
                        }

                        int finalReading;

                        if (!int.TryParse(apartmentInfo[4], out finalReading))
                        {
                            Console.WriteLine($"Final reading error: {apartmentInfo[4]}");
                            continue;
                        }

                        DateTime date;

                        if (!DateTime.TryParseExact(apartmentInfo[5], "dd.MM.yy", null, DateTimeStyles.None, out date))
                        {
                            Console.WriteLine($"Date format error: {apartmentInfo[5]}");
                            continue;
                        }

                        apartments.Add(new Apartment(apartmentNumber,adress, ownerName, initialReading, finalReading, date));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error: {e.Message}");
            }
        }
        public  static string[] GetMonthNames()
        {
            return monthNames;
        }
        public void PrintReport()
        {
            Console.WriteLine($"Quarter {quarter}\n");
            int n = 0;
            int m = 0;
            if (quarter == 1) { m = 3; }
            if(quarter == 2) { n = 3; m = 6; }
            if (quarter == 3) { n = 6; m = 9; }
            if (quarter == 4) { n = 9; m = 12; }
                foreach (string monthName in monthNames[n..m])
                {
                    Console.WriteLine($"{monthName}:");

                    foreach (Apartment apartment in apartments)
                    {
                        int consumption = apartment.GetConsumptionForMonth(monthName);
                    
                        if (consumption >= 0)
                        {
                            decimal cost = consumption * 0.25m; 


                            Console.WriteLine($"{apartment.Number}\t{apartment.Adress}\t{apartment.Owner}\t{consumption}\t{cost:0.00}");
                        }
                      
                    }

                    Console.WriteLine();
                }
            
        }

        public void PrintApartmentInfo(int apartmentNumber)
        {
            foreach (Apartment apartment in apartments)
            {
                if (apartment.Number == apartmentNumber)
                {
                    Console.WriteLine($"Apartment Number: {apartment.Number}");
                    Console.WriteLine($"Apartment Adress:{apartment.Adress}");
                    Console.WriteLine($"Owner Name: {apartment.Owner}");
                    Console.WriteLine($"Initial Reading: {apartment.InitialReading}");
                    Console.WriteLine($"Final Reading: {apartment.FinalReading}");
                    Console.WriteLine($"Date: {apartment.Date.ToString("dd.MM.yy")}");
                    Console.WriteLine($"Consumption: {apartment.GetTotalConsumption()}");
                    Console.WriteLine($"Cost: {apartment.GetTotalCost():0.00}");

                    return;
                }
            }

            Console.WriteLine($"Apartment {apartmentNumber} not found.");
        }

        public void PrintOwnerWithMaxDebt(decimal costPerKWh)
        {
            decimal maxDebt = 0m;
            string maxDebtOwner = "";

            foreach (Apartment apartment in apartments)
            {
                decimal cost = apartment.GetTotalCost(costPerKWh);

                if (cost > maxDebt)
                {
                    maxDebt = cost;
                    maxDebtOwner = apartment.Owner;
                }
            }

            Console.WriteLine($"Owner with max debt: {maxDebtOwner}");
            Console.WriteLine($"Debt: {maxDebt:0.00}");
        }
        public int GetApartmentWithNoConsumption() {
            int number = -1;
                foreach (Apartment apartment in apartments)
            {
                
                if (apartment.GetTotalConsumption() == 0) {
                    number = apartment.Number;
                }
            }
                return number;

        }
        public  int GetYear(DateTime date)
        {
            int year = date.Year;

            return year;
        }
    }
}
