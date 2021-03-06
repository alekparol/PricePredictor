﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace WebScraper
{

    /**
     * TODO: Add changing name of the day in polish and in english.  
     * TODO: Move all functions which are used in differents modules to the one utility component. OR use changeName(), changeLocalation() etc. as a method of page class, 
     * as those methods do the same job - baseURL + / + component_first + / component_second + /.     
     * TODO: Change getters and setter to read only or write only. 
     * TODO: Think about inheritance and changing private to protected.         
     * TODO: Provide translation for categories and subcategories with google translate (yep, that is pretty stupid idea).  
     * TODO: Make a base class which would be just day and month - in the case of "today" or yesterday just load today's date from the c#. And a class which will inherit 
     * basic properties and override methods.     
     * TODO: Change whole class to use DateTime struct.    
     */


    public class Date
    {

        private string productDate;

        private string days;
        private string months;

        private int hours;
        private int minutes;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string ProductDate
        {

            get
            {
                return productDate; // Readonly.
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

        /* ============ */
        /* Constructors */
        /* ============ */


        public Date ()
        {

        }

        public Date (string productDate)
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

        /* ============= */
        /* Class Methods */
        /* ============= */

            /**
             * For real, that is not this method's functionality. It should pass current date and change days to numerical value and add month.            
            */

        public void ChangeDaysToEnglish()
        {

            DateTime currentTime = DateTime.Now;

            if (days == "dzisiaj")
            {
                days = currentTime.Day.ToString();
            }
            else if (days == "wczoraj")
            {
                days = (currentTime.Day - 1).ToString();
            }

        }


        public void ChangeMonthsToEnglish ()
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

        public void ChangeMonthsToPolish ()
        {

            CultureInfo polish = new CultureInfo("pl-PL");

            for (int i = 1; i <= 12; i++)
            {

                if (months == polish.DateTimeFormat.GetMonthName(12).ToLower().Substring(0, 3))
                {
                    this.months = polish.DateTimeFormat.GetMonthName(i);
                }

            }

        }

        public void DisplayDate ()
        {

            if (hours == 0 && minutes == 0)
            {

                ChangeMonthsToEnglish();
                string ordinalNumber = OrdinalNumber();

                Console.WriteLine("Product date is: {0} {1} of {2}", days, ordinalNumber, months);

            }
            else
            {

                ChangeDaysToEnglish();
                Console.WriteLine("Product date is: {0}, {1}:{2}", days, hours, minutes);
            }

        }

        public void DisplayDateInPolish ()
        {

            if (hours == 0 && minutes == 0)
            {

                ChangeMonthsToPolish();
                Console.WriteLine("Data wystawienia produktu to: {0} {1}", days, months);

            }
            else
            {
                Console.WriteLine("Data wystawienia produktu to: {0}, {1}:{2}", days, hours, minutes);
            }


        }
    }

}