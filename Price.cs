using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper
{

    enum Currencies { PLN, EUR, USD, CHF, GBP };

    public class Price
    {

        private string productPrice;

        private int amount;
        private string currency;

        public string ProductPrice
        {
            get
            {
                return productPrice;
            }
            set
            {
                productPrice = value;
            }

        }

        public int Amount
        {
            get
            {
                return amount;
            }
            set
            {
                amount = value;
            }

        }

        public string Currency
        {
            get
            {
                return currency;
            }
            set
            {
                currency = value;
            }

        }

        public Price(string productPrice)
        {

            this.productPrice = productPrice;
            currency = productPrice.Substring(productPrice.Length - 3);

            string dateAuxilliary = productPrice.Remove(productPrice.Length - 3).Replace(" ", ""); // Changes "X XXX zl" format to the "XXXX" for parse to be available.
            amount = Int32.Parse(dateAuxilliary);

        }

        public void DisplayPrice()
        {

            Console.WriteLine("Product price is: {0} {1}", amount, currency);

        }

    }
}
