﻿using System;
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

        protected SearchBarMain searchBar;
        protected IWebElement searchField;
        protected IWebElement locationInputField;
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
            searchBar = new SearchBarMain (driver);

            /*searchField = driver.FindElement(By.Id("headerSearch"));
            locationInputField = driver.FindElement(By.Id("cityField"));
            submitButton = driver.FindElement(By.Id("submit-searchmain"));*/

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

            searchBar.TypeProductName(productName);
            searchBar.SubmitSearch();
            //searchField.SendKeys(productName);
            //submitButton.Click();

            nextPageURL = baseURL + "/oferty/q-" + ChangeName(productName) + "/"; 
            return nextPageURL;

        }

        public string SearchProduct (string productName, string productLocation)
        {

            searchBar.TypeProductName(productName);
            searchBar.TypeLocation(productLocation);
            searchBar.SubmitSearch();
            //searchField.SendKeys(productName);
            //locationInputField.SendKeys(productLocation);

            //Thread.Sleep(1000);
            //submitButton.Click();

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
         * TODO: DisplayAll() displays current page as "-1" for the first page, so it has to be debugged and changed.        
         * TODO: Leave only those properties which are necessary for others to be initialized and those second group move to smaller functions.        
         * Note: We can delete some unnecessary elements, which could be accessed by a single method, but it has to be checked if it affect readability of the code. 
         */

        private List<IWebElement> pageChangeBar; /* Web element which relates to whole page count bar on the bottom of the page - that is "previous", "next", list of pages. */
        private List<IWebElement> pageNextPrev;  /* Web element which relates to elements of the class containing "previous" and "next" links. This is subset of pageChangeBar. */

        private List<IWebElement> listOfPages;

        private IWebElement pageNext;
        private IWebElement pagePrevious;

        private IWebElement firstPage;
        private IWebElement currentPage;
        private IWebElement lastPage;

        private int searchCount;
        private int pageElements;

        private static int numberOfPages;

        private int pageNumber;

        private bool isNext;
        private bool isPrevious;


        /* =================== */
        /* Getters and Setters */
        /* =================== */


        public List <IWebElement> PageChangeBar
        {
            get
            {
                return pageChangeBar;
            }
            set
            {
                pageChangeBar = value;
            }
        }

        public List<IWebElement> PageNextPrev
        {
            get
            {
                return pageNextPrev;
            }
            set
            {
                pageNextPrev = value;
            }
        }

        public List<IWebElement> ListOfPages
        {
            get
            {
                return listOfPages;
            }
            set
            {
                listOfPages = value;
            }
        }


        /* ============ */
        /* Constructors */
        /* ============ */


        public SearchPage ()
        { 
        
        }


        public SearchPage (IWebDriver driver)
        {

            SearchBarSearch searchBar = new SearchBarSearch(driver);


            pageChangeBar = new List<IWebElement> (driver.FindElements(By.ClassName("pager")));
            pageNextPrev = new  List<IWebElement> (pageChangeBar[0].FindElements(By.ClassName("pageNextPrev")));

            if (pageNextPrev.Count == 2)
            {
                pageNext = pageNextPrev[0];
                pagePrevious = pageNextPrev[1];

            }

            if (pageNext != null)
            {
                isNext = pageNext.GetAttribute("href") != null;
            }

            if (pagePrevious != null)
            {
                isPrevious = pagePrevious.GetAttribute("href") != null;
            }

            listOfPages = new List <IWebElement> (pageChangeBar[0].FindElements(By.ClassName("fleft")));
            numberOfPages = listOfPages.Count;

            if (listOfPages.Count == 2)
            {
                firstPage = listOfPages[0];
                lastPage = listOfPages[numberOfPages - 1];

            }

            currentPage = listOfPages.Find((IWebElement obj) => obj.GetAttribute("data-cy") == "page-link-current");
            // pageNumber = Int32.Parse(currentPage.Text); To be debugged.

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

        /**
         * Hard use of regex here.       
        */

    }

}
