using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{
    public class ProductsList
    {

        private int numberOfResults;
        private int productsOnPage;

        private Regex foundResults = new Regex("\\d+\\s{1}?\\d+"); // Changed because some number are in format X XXX.

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public int NumberOfResults
        {

            get
            {
                return numberOfResults;
            }
            set
            {
                numberOfResults = value;
            }

        }

        public int ProductsOnPage
        {

            get
            {
                return productsOnPage;
            }
            set
            {
                productsOnPage = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public ProductsList ()
        {

        }

        public ProductsList(IWebDriver driver)
        {

            string nrb = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[1]/p")).Text;
            //*[@id="offers_table"]/tbody/tr[1]/td/div[1]/p
            if (nrb == string.Empty)
            {
           

                numberOfResults = 0;
                Console.WriteLine(nrb);

            }
            else
            {
            
                Match matchNumber = foundResults.Match(nrb);
                this.numberOfResults = Int32.Parse(matchNumber.ToString());

                Console.WriteLine(matchNumber);

            }

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            productsOnPage = listOfProducts.Count;

            Console.WriteLine(productsOnPage);

        }

    }
}
