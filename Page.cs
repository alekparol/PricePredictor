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

    /**
     * Description: This class contains classes related to pages in each step of the program. Those classes have properties which for which models are specific elements
     * of those pages, which will be used during program run. This class is parted onto four:
     * 1. Class Page which is most general class of them all, which only contains baseURL string to some homepage (in this case it is homepage of OLX) and class method
     *    which navigates webdriver to this URL address. Possibly it should be changed to be Interface or abstract class. 
     * 2. Class MainPage
    */
        
        /**
         * TODO: Add void methods GoToNextPage() and GoToPreviousPage() which will be implemented pageBar.PageList.PageNext.Click() or simillar - SearchPageSearch. 
         * TODO: Add a function which will be changing polish letters to their english substitute. Like change ł into l in biała-podlaska. This function should be used 
         * in both change funtions.         
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

    public class SearchPage:Page
    {

        private SearchBarSearch searchBar;
        private PageBar pageBar;
        private ProductsList productsList;


        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public SearchBarSearch SearchBar
        {
            get
            {
                return searchBar;
            }

        }

        public ProductsList ProductsList
        {
            get
            {
                return productsList;
            }

        }

        public PageBar PageBar
        {
            get
            {
                return pageBar;
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
            productsList = new ProductsList(driver);

            pageBar = new PageBar(driver);

        }

        /* ============= */
        /* Class Methods */
        /* ============= */


        public void DisplayAll()
        {

            Console.WriteLine("{0} is that there is a next page link.", pageBar.NextPrev.IsNext());
            Console.WriteLine("{0} is that there is a previous page link.", pageBar.NextPrev.IsPrevious());

            Console.WriteLine("There is: {0} pages with search result.", pageBar.PageList.LastPageNumber); // It cannot be numberOfPages because it is related to number of webelements, not their value.
            Console.WriteLine("Current page number is: {0}.", pageBar.PageList.CurrentPageNumber());

            Console.WriteLine("There is: {0} search results.", productsList.NumberOfResults);
            Console.WriteLine("Currently on the page is displayed: {0} products.", productsList.ProductsOnPage);

            Console.WriteLine("There is: {0} actual products.", productsList.ActualProducts);

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
