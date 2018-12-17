using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{
    public class MainPage
    {
        private string baseURL = "https://www.olx.pl";
        private string pageURL;

        private IWebElement searchField;
        private IWebElement submitButton;
        private IWebElement locationField;
        
        public MainPage (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(baseURL);

            searchField = driver.FindElement(By.Id("headerSearch"));
            submitButton = driver.FindElement(By.Id("submit-searchmain"));
            locationField = driver.FindElement(By.Id("cityField"));

        }

        public string SearchProduct (string productName)
        {

            searchField.SendKeys(productName);
            submitButton.Click();

            pageURL = baseURL + "/oferty/q-" + ChangeName(productName) + "/"; // That will do only if product name is one word. In other case between two words has to be "-" sign.
            return pageURL; 

        }

        public string SearchProduct(string productName, string productLocation)
        {

            searchField.SendKeys(productName);
            locationField.SendKeys(productLocation);

            /**
             * TODO: Remove this nasty repetition.
             */

            Thread.Sleep(100);
            submitButton.Click();

            pageURL = baseURL + "/" + ChangeLocation(productLocation) + "/q-" + ChangeName(productName) + "/";  
            return pageURL;

        }

        public string ChangeName (string productName)
        {

            productName = productName.Replace(" ", "-").ToLower();
            return productName;

        }

        /**
         * TODO: Check how url changes for different search locations. 
         */

        public string ChangeLocation(string productLocation)
        {

            productLocation = productLocation.Replace(" ", "-").ToLower();
            return productLocation;

        }

    }

    public class SearchPage
    {
        private string baseURL = "https://www.olx.pl";
        private string pageURL;

        private int searchCount;

        private int pageElements;
        private string pagePages;

        private int pageNumber;
        private bool isNext;
        private static int numberOfPages;

        public void CountResults (IWebDriver driver)
        {

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td//div[2]/h2")).Text;
            if (numberOfResults == string.Empty)
            {

                numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td/div[1]/p")).Text;

                Regex foundResults = new Regex("\\d+");

                Match matchNumber = foundResults.Match(numberOfResults);
                searchCount = Int32.Parse(matchNumber.ToString());

                Console.WriteLine(matchNumber);
            } 
            else
            {

                Regex foundResults = new Regex("\\d+");

                Match matchNumber = foundResults.Match(numberOfResults);
                searchCount = Int32.Parse(matchNumber.ToString());

                Console.WriteLine(matchNumber);

            }


        }

        public int CountPageElements (IWebDriver driver)
        {

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            pageElements = listOfProducts.Count;

            Console.WriteLine(pageElements);

            return pageElements;

        }

    }

    public class ProductPage
    {

        private string baseURL = "https://www.olx.pl";
        private string pageURL;

    }

}
