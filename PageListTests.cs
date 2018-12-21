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
    /**
     * TODO: Make a test on the page which is on the half way to the end - to check how page behaves with the first page number.   
    */

    [TestFixture()]
    public class PageListTests
    {
        [Test()]
        public void TestCase()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/?page=3");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageList pageList = new PageList(driver, pageChangeBar);

            /* Testing */

            Assert.That(pageList.FirstPage, Is.Not.Null);
            Assert.That(pageList.LastPage, Is.Not.Null);

            Assert.That(pageList.LastPageNumber, Is.EqualTo(20));
            Assert.That(pageList.FirstPageNumber, Is.EqualTo(1));

            Assert.That(pageList.NumberOfPages, Is.EqualTo(14));

            /* Teard down */

            driver.Quit();

        }
    }
}
