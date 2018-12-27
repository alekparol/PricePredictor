using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

/**
 * TODO: Add some class methods which could be reused in Page class.
*/

namespace WebScraper
{
    public class ProductsList
    {

        private int numberOfResults;
        private int productsOnPage;

        private int actualProducts;

        private List<IWebElement> listOfProducts;
        private Regex foundResults = new Regex("\\d+\\s?\\d+"); // Changed because some number are in format X XXX.

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

        public int ActualProducts
        {

            get
            {
                return actualProducts;
            }
            set
            {
                actualProducts = value;
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

            string messageResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[1]/p")).Text;

            if (messageResults == string.Empty)
            {
                numberOfResults = 0;
            }
            else
            {
            
                Match matchNumber = foundResults.Match(messageResults);
                numberOfResults = Int32.Parse(matchNumber.ToString().Replace(" ",""));

            }

            listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            productsOnPage = listOfProducts.Count;

            List <IWebElement> listOfActual = new List <IWebElement> (driver.FindElement(By.Id("offers_table")).FindElements(By.Id("wrap")));
            actualProducts = listOfActual.Count;

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

    }
}
