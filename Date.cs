using System;
using System.Collections.Generic;
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
                Console.WriteLine("Product date is: {0} th of {1}", days, months);
            }
            else
            {
                Console.WriteLine("Product date is: {0}, {1}:{2}", days, hours, minutes);
            }

        }

    }
}
