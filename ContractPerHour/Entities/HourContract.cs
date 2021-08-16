using System;
using System.Collections.Generic;
using System.Text;

namespace ContractPerHour.Entities
{
    class HourContract
    {
        public DateTime Date { get; set; }
        public double ValuePerHour { get; set; }
        public int Hours { get; set; }

        public HourContract()
        {
        }

        public HourContract(DateTime date, double valuePerHour, int hour)
        {
            Date = date;
            ValuePerHour = valuePerHour;
            Hours = hour;
        }

        public double TotalValue()
        {
            return Hours * ValuePerHour;
        }
    }
}
