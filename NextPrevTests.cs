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
    public class NextPrevTests
    {
        [Test()]
        public void TestCase()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List <IWebElement> pageChangeBar = new List<IWebElement> (driver.FindElements(By.ClassName("pager")));
            NextPrev nextPrev = new NextPrev(driver, pageChangeBar);

            /* Testing */

            Assert.That(nextPrev.IsNext(), Is.True);
            Assert.That(nextPrev.IsPrevious, Is.False);

            /* Teard down */

            driver.Quit();

        }
    }
}
