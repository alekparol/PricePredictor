using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{
    public class PageBar
    {

        private List<IWebElement> pageChangeBar; /* Web element which relates to whole page count bar on the bottom of the page - that is "previous", "next", list of pages. */

        private NextPrev nextPrev;
        private PageList pageList;

        private static int numberOfPages;

        /* =================== */
        /* Getters and Setters */
        /* =================== */


        public List<IWebElement> PageChangeBar
        {
            get
            {
                return pageChangeBar;
            }

        }

        public NextPrev NextPrev
        {
            get
            {
                return nextPrev;
            }

        }

        public PageList PageList
        {
            get
            {
                return pageList;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */


        public PageBar ()
        {

        }

        /**
         * NOTE: Here there should be no sanity check, because there are ones in both classes.       
        */

        public PageBar (IWebDriver driver)
        {

            pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));

            nextPrev = new NextPrev(driver, pageChangeBar);
            pageList = new PageList(driver, pageChangeBar);

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public PageBar GoToNextPage (IWebDriver driver)
        {
            PageBar pageBar = new PageBar(driver);

            if (nextPrev.IsNext() == true)
            {
                driver.Navigate().GoToUrl(nextPrev.PageNext.GetAttribute("href"));
                pageBar = new PageBar(driver);

                return pageBar;
            }

            return pageBar;

        }

        public PageBar GoToPreviousPage (IWebDriver driver)
        {

            PageBar pageBar = new PageBar(driver);

            if (nextPrev.IsPrevious() == true)
            {
                driver.Navigate().GoToUrl(nextPrev.PagePrevious.GetAttribute("href"));
                pageBar = new PageBar(driver);

                return pageBar;
            }

            return pageBar;

        }

        public PageBar GoToFirstPage(IWebDriver driver)
        {

            PageBar pageBar = new PageBar(driver);

            if (pageList.FirstPageNumber != 0)
            {
                driver.Navigate().GoToUrl(pageList.FirstPage.FindElement(By.XPath("./a")).GetAttribute("href"));
                pageBar = new PageBar(driver);

                return pageBar;
            }

            return pageBar;

        }

        public PageBar GoToLastPage(IWebDriver driver)
        {

            PageBar pageBar = new PageBar(driver);

            if (pageList.LastPageNumber != 0)
            {
                driver.Navigate().GoToUrl(pageList.LastPage.FindElement(By.XPath("./a")).GetAttribute("href"));
                pageBar = new PageBar(driver);

                return pageBar;
            }

            return pageBar;

        }

    }
}
