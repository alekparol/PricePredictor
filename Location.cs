using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper
{

    public class Location
    {

        private string productLocalization;

        private string city;
        private string district;

        public string ProductLocalization
        {
            get
            {
                return productLocalization;
            }
            set
            {
                productLocalization = value;
            }

        }

        public string City
        {
            get
            {
                return city;
            }
            set
            {
                city = value;
            }

        }

        public string District
        {
            get
            {
                return district;
            }
            set
            {
                district = value;
            }

        }

        public Location (string productLocalization)
        {

            this.productLocalization = productLocalization;

            if (productLocalization.Contains(", "))
            {
                string[] locAuxilliary = productLocalization.Split(',');

                City = locAuxilliary[0];
                District = locAuxilliary[1].Trim();

            }
            else
            {
                City = productLocalization;
            }

        }

        public void DisplayLocation()
        {

            if (district == null)
            {
                Console.WriteLine("Product location is: {0}", city);
            }
            else
            {
                Console.WriteLine("Product location is: {0}, {1}", city, district);
            }

        }

    }
}
