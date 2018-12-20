using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{
    public class PageList
    {

        private List<IWebElement> listOfPages;
        private int numberOfPages;

        private IWebElement firstPage;
        private IWebElement currentPage;
        private IWebElement lastPage;

        private int firstPageNumber;
        private int lastPageNumber;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

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

        public int NumberOfPages
        {
            get
            {
                return numberOfPages;
            }
            set
            {
                numberOfPages = value;
            }

        }

        public IWebElement FirstPage
        {
            get
            {
                return firstPage;
            }
            set
            {
                firstPage = value;
            }

        }

        public IWebElement LastPage
        {
            get
            {
                return lastPage;
            }
            set
            {
                lastPage = value;
            }

        }

        public IWebElement CurrentPage
        {
            get
            {
                return currentPage;
            }
            set
            {
                currentPage = value;
            }

        }

        public int FirstPageNumber
        {
            get
            {
                return firstPageNumber;
            }
            set
            {
                firstPageNumber = value;
            }

        }

        public int LastPageNumber
        {
            get
            {
                return lastPageNumber;
            }
            set
            {
                lastPageNumber = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public PageList()
        {

        }

        public PageList (IWebDriver driver, List <IWebElement> pageChangeBar)
        {
       
            listOfPages = new List<IWebElement>(pageChangeBar[0].FindElements(By.ClassName("item")));
            numberOfPages = listOfPages.Count;

            if (numberOfPages > 0)
            {
                firstPage = listOfPages[0];
                lastPage = listOfPages[numberOfPages - 1];

                firstPageNumber = Int32.Parse(firstPage.Text);
                lastPageNumber = Int32.Parse(lastPage.Text);

                currentPage = listOfPages.Find((IWebElement obj) => obj.GetAttribute("data-cy") == "page-link-current");

            }

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public int CurrentPageNumber ()
        {
            return listOfPages.IndexOf(currentPage) + 1;
        }

    }
}
