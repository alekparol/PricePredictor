using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{

    /**
     * TODO: Make SearchPage and ProductPage to inherit from MainPage. There are elements which are the same on those sites.   
     * TODO: Make a class representing search bar and move all properties to it. 
     * NOTE: Main Page and Search Page have the same elements: searchField, locationField and submitButton, although on the searchField there are few more which could be 
     * helpful. 
     * NOTE: Product Page is somehow different, therefore there should be another class from which it could inherit.     
     * NOTE: Address of the page after search for a product changes with oferty/q-productName if there is no specified location of the search, and /productLocation/q-productName 
     * if it is specified.     
    */

    public class Page
    {

        protected string baseURL = "https://www.olx.pl";

        protected IWebElement searchField;
        protected IWebElement locationField;
        protected IWebElement submitButton;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string BaseURL
        {

            get
            {
                return BaseURL;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public Page()
        {

        }

        public Page (IWebDriver driver)
        {

            GoToHomePage(driver);

            searchField = driver.FindElement(By.Id("headerSearch"));
            submitButton = driver.FindElement(By.Id("submit-searchmain"));
            locationField = driver.FindElement(By.Id("cityField"));

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void GoToHomePage (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(baseURL);

        }

    }

    public class MainPage:Page
    {

        private string nextPageURL;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string NextPageURL
        {

            get
            {
                return nextPageURL;
            }
            set
            {
                nextPageURL = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public MainPage()
        {

        }

        public MainPage (IWebDriver driver):base(driver)
        {

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public string SearchProduct (string productName)
        {

            searchField.SendKeys(productName);
            submitButton.Click();

            nextPageURL = baseURL + "/oferty/q-" + ChangeName(productName) + "/"; 
            return nextPageURL;

        }

        public string SearchProduct (string productName, string productLocation)
        {

            searchField.SendKeys(productName);
            locationField.SendKeys(productLocation);

            Thread.Sleep(1000);
            submitButton.Click();

            nextPageURL = baseURL + "/" + ChangeLocation(productLocation) + "/q-" + ChangeName(productName) + "/";  
            return nextPageURL;

        }

        public string ChangeName (string productName)
        {

            productName = productName.Replace(" ", "-").ToLower();
            return productName;

        }

        /**
         * TODO: Check how url changes for different search locations. 
         */

        public string ChangeLocation (string productLocation)
        {

            productLocation = productLocation.Replace(" ", "-").ToLower();
            return productLocation;

        }

    }

    public class SearchPage:Page
    {

        /**
         * TODO: Move "searchCount" and "pageElemets" down below. 
         * Note: We can delete some unnecessary elements, which could be accessed by a single method, but it has to be checked if it affect readability of the code. 
         */

        private int searchCount;
        private int pageElements;

        private List<IWebElement> pageChangeBar; /* Web element which relates to whole page count bar on the bottom of the page - that is "previous", "next", list of pages. */
        private List<IWebElement> pageNextPrev;  /* Web element which relates to elements of the class containing "previous" and "next" links. This is subset of pageChangeBar. */

        private IWebElement pageNext;
        private IWebElement pagePrevious;

        private IWebElement firstPage;
        private IWebElement currentPage;
        private IWebElement lastPage;

        private List<IWebElement> listOfPages;
        private static int numberOfPages;

        private int pageNumber;

        private bool isNext;
        private bool isPrevious;


        /* =================== */
        /* Getters and Setters */
        /* =================== */


        


        /* ============ */
        /* Constructors */
        /* ============ */


        public SearchPage ()
        { 
        
        }


        public SearchPage (IWebDriver driver)
        {

            searchField = driver.FindElement(By.Id("search-text"));
            locationField = driver.FindElement(By.Id("cityField"));
            submitButton = driver.FindElement(By.Id("search-submit"));

            pageChangeBar = new List<IWebElement> (driver.FindElements(By.ClassName("pager")));
            pageNextPrev = new  List<IWebElement> (pageChangeBar[0].FindElements(By.ClassName("pageNextPrev")));

            if (pageNextPrev.Count == 2)
            {
                pageNext = pageNextPrev[0];
                pagePrevious = pageNextPrev[1];

            }

            isNext = pageNext != null;
            isPrevious = pagePrevious != null;

            listOfPages = new List <IWebElement> (pageChangeBar[0].FindElements(By.ClassName("fleft")));
            numberOfPages = listOfPages.Count;

            if (listOfPages.Count == 2)
            {
                firstPage = listOfPages[0];
                lastPage = listOfPages[numberOfPages - 1];

            }

            currentPage = listOfPages.Find((IWebElement obj) => obj.GetAttribute("data-cy") == "page-link-current");
            pageNumber = listOfPages.IndexOf(currentPage);

        }


        /* ============= */
        /* Class Methods */
        /* ============= */

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

        public void DisplayAll ()
        {

            Console.WriteLine(isNext);
            Console.WriteLine(isPrevious);
            Console.WriteLine(numberOfPages);
            Console.WriteLine(pageNumber);

        }

    }

    public class ProductPage
    {

        private string baseURL = "https://www.olx.pl";
        private string pageURL;

    }

}
