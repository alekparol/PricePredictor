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

        private Regex foundResults = new Regex("\\d+");

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

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"topLink\"]/div/ul[1]/li[1]/span")).Text;
            if (numberOfResults == string.Empty)
            {

                numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[1]/p")).Text;
                Match matchNumber = foundResults.Match(numberOfResults);

                this.numberOfResults = Int32.Parse(matchNumber.ToString());
                Console.WriteLine(matchNumber);

            }
            else
            {
            
                Match matchNumber = foundResults.Match(numberOfResults);
                this.numberOfResults = Int32.Parse(matchNumber.ToString());

                Console.WriteLine(matchNumber);

            }

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            productsOnPage = listOfProducts.Count;

            Console.WriteLine(productsOnPage);

        }

    }
}
