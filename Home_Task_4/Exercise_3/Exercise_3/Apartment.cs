using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise_3
{
    public class Apartment
    {
            public int Number { get; }

            public string Owner { get; }
            public string Adress { get; }

            public int InitialReading { get; }
            public int FinalReading { get; }
            public DateTime Date { get; }

            public Apartment(int number,string adress, string owner, int initialReading, int finalReading, DateTime date)
            {
                Number = number;
                Owner = owner;
                InitialReading = initialReading;
                FinalReading = finalReading;
                Date = date;
                Adress= adress;

            }

            public int GetTotalConsumption()
            {
                return FinalReading - InitialReading;
            }

            public int GetConsumptionForMonth(string monthName)
            {
                int monthIndex = Array.IndexOf(BillingSystem.GetMonthNames(), monthName);
                int month = monthIndex + 1; 
          

                if (Date.Month != month)
                {
                    return 0; 
                }

                return GetTotalConsumption();
            }

            public decimal GetTotalCost(decimal costPerKWh = 0.25m)
             {
                int consumption = GetTotalConsumption();
                return consumption * costPerKWh;
             }
    }
}
