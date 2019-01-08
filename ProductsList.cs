using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

/**
 * TODO: Add some class methods which could be reused in Page class.
*/

/**
 * TODO: Change if statements in the body of the constructor. 
 * TODO: Modify XPaths to be more elegant.  
 * TODO: Take into accont that results should be shown only on the first page of the search (or shouldn't? it could be used in the case when number of products changes through 
 * test time (yep, it should be reused)). 
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

            string messageResultsOne = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[1]")).Text;
            string messageResultsTwo = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[2]")).Text;

            if (messageResultsOne == string.Empty && messageResultsTwo == string.Empty)
            {
                numberOfResults = 0;
            }
            else
            {
                if (messageResultsOne == string.Empty)
                {
                    Match matchNumber = foundResults.Match(messageResultsTwo);
                    numberOfResults = Int32.Parse(matchNumber.ToString().Replace(" ", ""));
                }
                if (messageResultsTwo == string.Empty)
                {
                    Match matchNumber = foundResults.Match(messageResultsOne);
                    numberOfResults = Int32.Parse(matchNumber.ToString().Replace(" ", ""));
                }

            }

            listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            productsOnPage = listOfProducts.Count;

            List <IWebElement> listOfActual = new List <IWebElement> (driver.FindElement(By.Id("offers_table")).FindElements(By.ClassName("wrap")));
            actualProducts = listOfActual.Count;

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

    }
}
