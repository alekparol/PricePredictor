using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;
using WebScraper;

namespace WebScraper
{

    /**
     * This file contains classes which are storing relevant IWebElements from pages used in out program.
     * 
     * Description: This class contains classes related to pages in each step of the program. Those classes have properties which for which models are specific elements
     * of those pages, which will be used during program run. This class is parted onto four:
     * 1. Class Page which is most general class of them all, which only contains baseURL string to some homepage (in this case it is homepage of OLX) and class method
     *    which navigates webdriver to this URL address. Possibly it should be changed to be Interface or abstract class. 
     * 2. Class MainPage    
     *     
    */

    /**
     * TEST PLANS
     * Most vunerable parts of the code (from the side of the page) is ProductsList class. Because definition of the productsList could too wide, as it can contain sponsored 
     * content or advertisments or empty "wraps". So it has to be checked. 
    */

    /**
     * CODE STRUCTURE 
     * Maybe Page class should have all class methods from the classes which objects its using. For example IsNext() should be on the searchPage, not in searchPage.PageBar.NextPrev.    
     * OLX Product class should use ProductsList attributes, as it has list of IWebElements which could be reused. So basically OLX Product creates another products list.
     *     
    */

    /**
     * TODO: Make SearchPage and ProductPage to inherit from MainPage. There are elements which are the same on those sites.   
     * TODO: Research if "Page" class should be efficiently changed to an interface.       
     * TODO: Delete default constructors.     
     * TODO: Modify CurrentPageNumber (driver) in PageList class as it is not working. Problem is in the wrong initialization of the currentPage variable.     
     *     
     * NOTE: Main Page and Search Page have the same elements: searchField, locationField and submitButton, although on the searchField there are few more which could be 
     * helpful. 
     * NOTE: Product Page is somehow different, therefore there should be another class from which it could inherit.     
     * NOTE: Address of the page after search for a product changes with oferty/q-productName if there is no specified location of the search, and /productLocation/q-productName 
     * if it is specified.     
     * NOTE: For scrolling down and up
     *     
     * WebDriver driver = new FirefoxDriver();
     * JavascriptExecutor jse = (JavascriptExecutor)driver;
     * jse.executeScript("window.scrollBy(0,250)", "");
     * jse.executeScript("scroll(0, -250);");    
     * 
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

        public void GoToHomepage (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(baseURL);

        }

    }

    public class MainPage:Page
    {

        public WebScraper.Utilities ut = new Utilities();

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

            GoToHomepage(driver);
            searchBar = new SearchBarMain(driver);

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public string SearchProduct (string productName)
        {

            searchBar.TypeProductName(productName);
            searchBar.SubmitSearch();

            nextPageURL = baseURL + "/oferty/q-" + ut.ChangeName(productName) + "/"; 
            return nextPageURL;

        }

        public string SearchProduct (string productName, string productLocation)
        {

            searchBar.TypeProductName(productName);
            searchBar.TypeLocation(productLocation);
            searchBar.SubmitSearch();

            nextPageURL = baseURL + "/" + ut.ChangeLocation(productLocation) + "/q-" + ut.ChangeName(productName) + "/";  
            return nextPageURL;

        }

    }

    public class SearchPage:Page
    {

        private SearchBarSearch searchBar;
        private ProductsList productsList;

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

        /**
         * TODO: Evaluate if this part of code (that is those class methods) are rather more useful in PageBar class or in Page class.       
        */

        public void GoToFirstPage (IWebDriver driver)
        {
            pageBar.GoToFirstPage(driver);
        }

        public void GoToLastPage(IWebDriver driver)
        {
            pageBar.GoToLastPage(driver);
        }

        public void GoToNextPage(IWebDriver driver)
        {
            pageBar.GoToNextPage(driver);
        }

        public void GoToPreviousPage(IWebDriver driver)
        {
            pageBar.GoToPreviousPage(driver);
        }

        /**
         * TODO: Check if adding if adding sanity check here is necessary - that is checking if pageBar and productsList are not null.        
        */

        public void DisplayAll()
        {

            Console.WriteLine("{0} is that there is a next page link.", pageBar.NextPrev.IsNext());
            Console.WriteLine("{0} is that there is a previous page link.\n", pageBar.NextPrev.IsPrevious());

            Console.WriteLine("There is: {0} pages with search result.", pageBar.PageList.LastPageNumber); // It cannot be numberOfPages because it is related to number of webelements, not their value.
            Console.WriteLine("Current page number is: {0}.\n", pageBar.PageList.CurrentPageNumber());

            Console.WriteLine("There is: {0} search results.", productsList.NumberOfResults);
            Console.WriteLine("Currently on the page is displayed: {0} products.\n", productsList.ProductsOnPage);

            Console.WriteLine("There is: {0} actual products.\n\n ", productsList.ActualProducts);

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
