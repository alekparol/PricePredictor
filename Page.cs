using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;

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
            locationField = driver.FindElement(By.Id("cityFieldGray"));


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

            submitButton.Click();

            pageURL = baseURL + "/" + productLocation + "/q-" + ChangeName(productName) + "/";  
            return pageURL;

        }

        public string ChangeName (string productName)
        {

            productName = productName.Replace(" ", "-");
            return productName;

        }

        /**
         * TODO: Check how url changes for different search locations. 
         */

        public string ChangeLocation(string productLocation)
        {

            productLocation = productLocation.Replace(" ", "-");
            return productLocation;

        }

    }

    public class SearchPage
    {
        private string baseURL = "https://www.olx.pl";
        private string pageURL;

        private int pageElements;
        private string pagePages;

        public string SearchProduct(IWebDriver driver, string productName)
        {

            driver.FindElement(By.Id("headerSearch")).SendKeys(productName);
            driver.FindElement(By.Id("submit-searchmain")).Click();

            productName = productName.Replace(" ", "-"); // Add normalizing function to Name class.

            pageURL = baseURL + "/oferty/q-" + productName + "/"; // That will do only if product name is one word. In other case between two words has to be "-" sign.
            return pageURL;

        }

        public void CountResults(IWebDriver driver)
        {

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td//div[2]/h2")).Text;
            Regex foundResults = new Regex("\\d+");

            Match matchNumber = foundResults.Match(numberOfResults);
            pageElements = Int32.Parse(matchNumber.ToString());

        }

    }

    public class ProductPage
    {
        private string baseURL = "https://www.olx.pl";
        private string pageURL;

        private int pageElements;
        private string pagePages;

        private IWebElement searchField;
        private IWebElement submitButton;

        public ProductPage (IWebDriver driver)
        {

            searchField = driver.FindElement(By.Id("headerSearch"));
            submitButton = driver.FindElement(By.Id("submit-searchmain"));

        }

        public string SearchProduct(IWebDriver driver, string productName)
        {

            driver.FindElement(By.Id("headerSearch")).SendKeys(productName);
            driver.FindElement(By.Id("submit-searchmain")).Click();

            productName = productName.Replace(" ", "-"); // Add normalizing function to Name class.

            pageURL = baseURL + "/oferty/q-" + productName + "/"; // That will do only if product name is one word. In other case between two words has to be "-" sign.
            return pageURL;

        }

        public void CountResults(IWebDriver driver)
        {

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td//div[2]/h2")).Text;
            Regex foundResults = new Regex("\\d+");

            Match matchNumber = foundResults.Match(numberOfResults);
            pageElements = Int32.Parse(matchNumber.ToString());

        }

    }

}
