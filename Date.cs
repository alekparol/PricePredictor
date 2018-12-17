using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WebScraper
{

    enum Months { January, February, March, April, May, June, July, August, September, October, November, December };

    /**
     * TODO: Modify display of the date for "th" and that stuff.
     * Months().Substring().ToUpper() + "." - for shorter. 
     */

    public class Date
    {

        private string productDate;

        private string days;
        private string months;

        private int hours;
        private int minutes;

        public string ProductDate
        {

            get
            {
                return productDate;
            }
            set
            {
                ProductDate = value;
            }

        }

        public string Days
        {

            get
            {
                return days;
            }
            set
            {
                days = value;
            }

        }

        public string Months
        {

            get
            {
                return months;
            }
            set
            {
                months = value;
            }

        }

        public int Hours
        {

            get
            {
                return hours;
            }
            set
            {
                hours = value;
            }

        }

        public int Minutes
        {

            get
            {
                return minutes;
            }
            set
            {
                minutes = value;
            }

        }

        public Date(string productDate)
        {

            this.productDate = productDate;

            if (productDate.Contains(":"))
            {

                string[] dateAuxilliary = productDate.Split(' ');
                Days = dateAuxilliary[0];

                string[] hoursAuxilliary = dateAuxilliary[1].Split(':');
                Hours = Int32.Parse(hoursAuxilliary[0]);
                Minutes = Int32.Parse(hoursAuxilliary[1]);

            }
            else
            {

                string[] dateAuxilliary = productDate.Split(' ');
                Days = dateAuxilliary[0];

                Months = dateAuxilliary[1];

            }

        }

        public void DisplayDate()
        {

            if (hours == 0 && minutes == 0)
            {
                ChangeMonths();
                string ordinalNumber = OrdinalNumber();
                Console.WriteLine("Product date is: {0} {1} of {2}", days, ordinalNumber, months);
            }
            else
            {
                Console.WriteLine("Product date is: {0}, {1}:{2}", days, hours, minutes);
            }

        }

        public void ChangeMonths ()
        {
            CultureInfo english = new CultureInfo("en-EN");
            CultureInfo polish = new CultureInfo("pl-PL");

            for (int i = 1; i <= 12; i++)
            {

                if (months == polish.DateTimeFormat.GetMonthName(12).ToLower().Substring(0, 3))
                {
                    this.months = english.DateTimeFormat.GetMonthName(i);
                }

            }

        }

        public string OrdinalNumber ()
        {
            string ordinal = "th";
            int daysToInteger = Int32.Parse(days);

            if (daysToInteger == 1 || daysToInteger == 21 || daysToInteger == 31)
            {
                ordinal = "st";
            }
            else if (daysToInteger == 2 || daysToInteger == 22)
            {
                ordinal = "nd";
            }
            else if (daysToInteger == 3 || daysToInteger == 23)
            {
                ordinal = "rd";
            }

            return ordinal;

        }

    }
}
