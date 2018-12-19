using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{
    public class ChangePageBar
    {

        private List<IWebElement> pageChangeBar; /* Web element which relates to whole page count bar on the bottom of the page - that is "previous", "next", list of pages. */
        private List<IWebElement> pageNextPrev;  /* Web element which relates to elements of the class containing "previous" and "next" links. This is subset of pageChangeBar. */

        private IWebElement pageNext;
        private IWebElement pagePrevious;

        private IWebElement firstPage;
        private IWebElement currentPage;
        private IWebElement lastPage;

        private List<IWebElement> listOfPages;
        private static int numberOfPages;

        private bool isNext;
        private bool isPrevious;

        /* =================== */
        /* Getters and Setters */
        /* =================== */


        public List<IWebElement> PageChangeBar
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


        public ChangePageBar()
        {

        }

        public ChangePageBar(IWebDriver driver)
        {

            pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));
            pageNextPrev = new List<IWebElement>(pageChangeBar[0].FindElements(By.ClassName("pageNextPrev")));

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

            listOfPages = new List<IWebElement>(pageChangeBar[0].FindElements(By.ClassName("fleft")));
            numberOfPages = listOfPages.Count;

            if (listOfPages.Count == 2)
            {
                firstPage = listOfPages[0];
                lastPage = listOfPages[numberOfPages - 1];

            }

            currentPage = listOfPages.Find((IWebElement obj) => obj.GetAttribute("data-cy") == "page-link-current");
            // pageNumber = Int32.Parse(currentPage.Text); To be debugged.

        }

    }
}
