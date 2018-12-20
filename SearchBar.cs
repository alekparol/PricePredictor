using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{

    /**
     * TODO: Make locationRange to work.    
    */

    public class SearchBar
    {

        protected IWebElement fieldSet; // Field within in there is at least three IWebElements: searchField, locationInputField and submitButton. 

        protected IWebElement searchField;
        protected IWebElement locationInputField;
        protected IWebElement submitButton;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public IWebElement Fieldset
        {

            get
            {
                return fieldSet;
            }
            set
            {
                fieldSet = value;
            }

        }

        public IWebElement SearchField
        {

            get
            {
                return searchField;
            }
            set
            {
                searchField = value;
            }

        }

        public IWebElement LocationInputField
        {

            get
            {
                return locationInputField;
            }
            set
            {
                locationInputField = value;
            }

        }

        public IWebElement SubmitButton
        {

            get
            {
                return submitButton;
            }
            set
            {
                submitButton = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public SearchBar ()
        {

        }

    }

    public class SearchBarMain:SearchBar
    {
    
        /* ============ */
        /* Constructors */
        /* ============ */

        public SearchBarMain()
        {

        }

        public SearchBarMain(IWebDriver driver)
        {

            fieldSet = driver.FindElement(By.Id("searchmain"));

            searchField = fieldSet.FindElement(By.Id("headerSearch"));
            locationInputField = fieldSet.FindElement(By.Id("cityField"));
            submitButton = fieldSet.FindElement(By.Id("submit-searchmain"));

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void TypeProductName (string productName)
        {

            searchField.SendKeys(productName);
            Thread.Sleep(1000);

        }

        public void ClearProductName ()
        {

            searchField.Clear();
            Thread.Sleep(1000);

        }

        public void TypeLocation (string productLocation)
        {

            locationInputField.SendKeys(productLocation);
            Thread.Sleep(1000);

        }

        public void SubmitSearch ()
        {
            submitButton.Click();
            Thread.Sleep(1000);

        }

    }

    public class SearchBarSearch:SearchBarMain
    {
        /**
         * TODO: Add sanity check if driver's url is matching the regex pattern, to prevent program's crash.        
         * NOTE: There are plenty other elements on the searchPage which could be helpful on ther stages of the projects, but all elements are related to some category, so
         * it would be pain in the ass trying to load and use them.
        */

        private IWebElement locationRange;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public IWebElement LocationRange
        {

            get
            {
                return locationRange;
            }
            set
            {
                locationRange = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public SearchBarSearch ()
        {

        }

        public SearchBarSearch (IWebDriver driver)
        {

            fieldSet = driver.FindElement(By.Id("searchbox"));

            searchField = fieldSet.FindElement(By.Id("search-text"));
            locationInputField = fieldSet.FindElement(By.Id("cityField"));

            locationRange = fieldSet.FindElement(By.Id("distanceSelect"));
            submitButton = fieldSet.FindElement(By.Id("search-submit"));

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void SelectLocationRange ()
        {
            /**
             * It has to be done with SelectElement object.           
            */
        }

    }

}
