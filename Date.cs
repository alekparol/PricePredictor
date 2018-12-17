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
                Console.WriteLine("Product date is: {0} {1} of {2}", days, OrdinalNumber(), months);
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

                if (this.months.ToLower().Equals(polish.DateTimeFormat.GetMonthName(i).ToLower().Substring(0,3)))
                {
                    this.months = english.DateTimeFormat.GetMonthName(i);
                }

            }

        }

        public string OrdinalNumber ()
        {

            string daysString = this.days.ToString();

            if (daysString.Length == 2)
            {

                if (daysString[0] == '1')
                {
                    return "th";
                }
                else
                {
                    if (daysString[1] == '1')
                    {
                        return "st";
                    }
                    else if (daysString[1] == '2')
                    {
                        return "nd";
                    }
                    else if (daysString[1] == '3')
                    {
                        return "rd";
                    }
                    else
                    {
                        return "th";
                    }
                }

            }
            else if (daysString.Length == 1)
            {

                if (daysString[1] == '1')
                {
                    return "st";
                }
                else if (daysString[1] == '2')
                {
                    return "nd";
                }
                else if (daysString[1] == '3')
                {
                    return "rd";
                }
                else
                {
                    return "th";
                }

            }
            else
            {
                return "Wrong days format. ";
            }

        }

    }
}
