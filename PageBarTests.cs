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
    public class PageBarTests
    {
        [Test()]
        public void EmptyPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            Assert.That(pageBar.PageList.NumberOfPages, Is.EqualTo(14));

            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));
            Assert.That(pageBar.PageList.LastPageNumber, Is.EqualTo(20));

            Assert.That(pageBar.NextPrev.IsNext(), Is.True);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.False);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void FewPages()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBat = new PageBar(driver);

            /* Testing */



            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void MultiplePages()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBat = new PageBar(driver);

            /* Testing */



            /* Teard down */

            driver.Quit();

        }

    }
}
