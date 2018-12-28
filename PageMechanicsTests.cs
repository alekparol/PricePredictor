using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using WebScraper;

namespace WebScraperTests
{
    [TestFixture()]
    public class PageMechanicsTests
    {
        [Test()]
        public void TestCase()
        {

            IWebDriver driver = new ChromeDriver();
            MainPage mainPage = new MainPage(driver);

            mainPage.SearchProduct("rower gorski", "Warszawa");
            Assert.That(mainPage.NextPageURL, Is.EqualTo(driver.Url));

            SearchPage searchPage = new SearchPage(driver);

            /**
             * NOTE: number of pages could change during the test so it has to be taken into account.            
            */

            for (int i = 1; i <= searchPage.PageBar.PageList.LastPageNumber; i++)
            {
                searchPage.DisplayAll();
                searchPage.GoToNextPage(driver);
                searchPage = new SearchPage(driver);
            }

            driver.Quit();

        }

    }
}
