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
            set
            {
                pageChangeBar = value;
            }
        }

        public NextPrev NextPrev
        {
            get
            {
                return nextPrev;
            }
            set
            {
                nextPrev = value;
            }

        }

        public PageList PageList
        {
            get
            {
                return pageList;
            }
            set
            {
                pageList = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */


        public PageBar ()
        {

        }

        public PageBar (IWebDriver driver)
        {

            pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));
            nextPrev = new NextPrev(driver, pageChangeBar);
            pageList = new PageList(driver, pageChangeBar);

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

    }
}
