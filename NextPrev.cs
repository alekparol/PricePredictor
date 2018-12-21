using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;

namespace WebScraper
{

    /**
     *TODO: Check if no sanity checks are missing.     
     *NOTE: List of IWebElements is passed (not sure if it has to be that way) - to check if this list has any elements.    
    */

    public class NextPrev
    {

        private List<IWebElement> pageNextPrev;

        private IWebElement pageNext;
        private IWebElement pagePrevious;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

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

        public IWebElement PageNext
        {

            get
            {
                return pageNext;
            }
            set
            {
                pageNext = value;
            }

        }

        public IWebElement PagePrevious
        {

            get
            {
                return pagePrevious;
            }
            set
            {
                pagePrevious = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public NextPrev ()
        {

        }

        public NextPrev (IWebDriver driver, List<IWebElement> pageChangeBar)
        {

            if (pageChangeBar.Count != 0)
            {

                pageNextPrev = new List<IWebElement>(pageChangeBar[0].FindElements(By.ClassName("pageNextPrev")));

                if (pageNextPrev.Count == 2) // Check if pageChangeBar[0] != null would work.
                {
                    pageNext = pageNextPrev[0];
                    pagePrevious = pageNextPrev[1];

                }

            }

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public bool IsNext ()
        {
            return pageNext.GetAttribute("href") == null;
        }

        public bool IsPrevious ()
        {
            return pagePrevious.GetAttribute("href") == null;
        }

    }
}
