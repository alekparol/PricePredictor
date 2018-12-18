using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper
{

    /**
     * Making module which could check distance product from the current position (?). Check for the fastest and cheapest way to get product.  
     * To check current location GeoCordinateWatcher Class can be used to return specyfic longitude and latitude or just passing IP's location - 
     * it would return city, so that would be not very detailed info but could do for this purpose.     
    */

    public class Location
    {

        private string productLocalization;

        private string city;
        private string district;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string ProductLocalization
        {
            get
            {
                return productLocalization; // Readonly.
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

        /* ============ */
        /* Constructors */
        /* ============ */

        public Location ()
        {

        }

        public Location (string productLocalization)
        {

            this.productLocalization = productLocalization;

            if (productLocalization.Contains(", "))
            {
                string[] locAuxilliary = productLocalization.Split(',');

                city = locAuxilliary[0].Trim();
                District = locAuxilliary[1].Trim();

            }
            else
            {
                city = productLocalization;
            }

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void DisplayLocation()
        {

            if (district == null)
            {
                Console.WriteLine("Product location is: {0}", city);
            }
            else
            {
                Console.WriteLine("Product location is: {0} in {1}", district, city);
            }

        }

        public void DisplayLocationInPolish()
        {

            if (district == null)
            {
                Console.WriteLine("Produkt jest zlokalizowany w: {0}", city);
            }
            else
            {
                Console.WriteLine("Produkt zlokalizowany jest w: {0} w {1}", district, city);
            }

        }

    }
}
