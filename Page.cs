using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{

    /**
     * This file contains classes which are storing relevant IWebElements from pages used in out program.
     * 
    */

    /**
     * TODO: Make SearchPage and ProductPage to inherit from MainPage. There are elements which are the same on those sites.   
     * TODO: Make a class representing search bar and move all properties to it. 
     * TODO: Research if "Page" class should be efficiently changed to an interface.     
     * NOTE: Main Page and Search Page have the same elements: searchField, locationField and submitButton, although on the searchField there are few more which could be 
     * helpful. 
     * NOTE: Product Page is somehow different, therefore there should be another class from which it could inherit.     
     * NOTE: Address of the page after search for a product changes with oferty/q-productName if there is no specified location of the search, and /productLocation/q-productName 
     * if it is specified.     
    */


    public class Page
    {

        protected string baseURL = "https://www.olx.pl";

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

        private SearchBarMain searchBar;
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

            GoToHomePage(driver);
            searchBar = new SearchBarMain(driver);

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public string SearchProduct (string productName)
        {

            searchBar.TypeProductName(productName);
            searchBar.SubmitSearch();

            nextPageURL = baseURL + "/oferty/q-" + ChangeName(productName) + "/"; 
            return nextPageURL;

        }

        public string SearchProduct (string productName, string productLocation)
        {

            searchBar.TypeProductName(productName);
            searchBar.TypeLocation(productLocation);
            searchBar.SubmitSearch();

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

    public class SearchPage : Page
    {

        /**
         * TODO: Move "searchCount" and "pageElemets" down below. 
         * TODO: DisplayAll() displays current page as "-1" for the first page, so it has to be debugged and changed.        
         * TODO: Leave only those properties which are necessary for others to be initialized and those second group move to smaller functions.        
         * Note: We can delete some unnecessary elements, which could be accessed by a single method, but it has to be checked if it affect readability of the code. 
         */

        private int searchCount;
        private int pageElements;

        private SearchBarSearch searchBar;
        private PageBar pageBar;


        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public SearchBarSearch SearchBar
        {
            get
            {
                return searchBar;
            }
            set
            {
                searchBar = value;
            }

        }

        public PageBar PageBar
        {
            get
            {
                return pageBar;
            }
            set
            {
                pageBar = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */


        public SearchPage()
        {

        }


        public SearchPage(IWebDriver driver)
        {

            searchBar = new SearchBarSearch(driver);
            pageBar = new PageBar(driver);


        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void CountResults(IWebDriver driver)
        {

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"topLink\"]/div/ul[1]/li[1]/span")).Text;
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

        public int CountPageElements(IWebDriver driver)
        {

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            pageElements = listOfProducts.Count;

            Console.WriteLine(pageElements);

            return pageElements;

        }

        public void DisplayAll()
        {

            Console.WriteLine("{0} is that there is a next page link.", pageBar.NextPrev.IsNext());
            Console.WriteLine("{0} is that there is a previous page link.", pageBar.NextPrev.IsPrevious());
            Console.WriteLine("There is: {0} pages with search result.", pageBar.PageList.NumberOfPages);
            Console.WriteLine("Current page number is: {0}.", pageBar.PageList.CurrentPageNumber());

        }

    }


    public class ProductPage
    {

        private string baseURL = "https://www.olx.pl";
        private string pageURL;

        /**
         * Hard use of regex here.       
        */

    }

}
