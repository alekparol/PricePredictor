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

/**
 * TODO: Change test timeouts from 60 seconds.
 * TODO: Check how much time consumes every method and try to optimilize.
 */

namespace WebScraperTests
{
    /**
     * TODO: Make tests in which both classes would be used.
     */ 

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
            Assert.That(pageBar.PageList.LastPageNumber, Is.EqualTo(19));

            Assert.That(pageBar.NextPrev.IsNext(), Is.True);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.False);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void LastPAge()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            Assert.That(pageBar.PageList.LastPageNumber, Is.EqualTo(19));
            pageBar = pageBar.GoToLastPage(driver);

            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=19"));

            Assert.That(pageBar.PageList.NumberOfPages, Is.EqualTo(12));
            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));
           
            Assert.That(pageBar.NextPrev.IsNext(), Is.False);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void NextPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

            pageBar = pageBar.GoToNextPage(driver);
            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=2"));

            Assert.That(pageBar.PageList.NumberOfPages, Is.EqualTo(14));
            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

            Assert.That(pageBar.NextPrev.IsNext(), Is.True);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void NextPageFor()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */
    
            for (int i = 2; i <= pageBar.PageList.LastPageNumber; i++)
            {

                pageBar = pageBar.GoToNextPage(driver);
                Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=" + i.ToString()));

                Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

                if (i != pageBar.PageList.LastPageNumber)
                {

                    Assert.That(pageBar.NextPrev.IsNext(), Is.True);
                    Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

                } 
                else
                {

                    Assert.That(pageBar.NextPrev.IsNext(), Is.False);
                    Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

                }

            }

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void FirstPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            pageBar = pageBar.GoToNextPage(driver);

            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));
            pageBar = pageBar.GoToFirstPage(driver);

            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/"));

            Assert.That(pageBar.PageList.NumberOfPages, Is.EqualTo(14));
            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

            Assert.That(pageBar.NextPrev.IsNext(), Is.True);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.False);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void PreviousPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            Assert.That(pageBar.PageList.LastPageNumber, Is.EqualTo(19));
            pageBar = pageBar.GoToLastPage(driver);

            pageBar = pageBar.GoToPreviousPage(driver);
            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=18"));

            Assert.That(pageBar.PageList.NumberOfPages, Is.EqualTo(12));
            Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

            Assert.That(pageBar.NextPrev.IsNext(), Is.True);
            Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        public void PreviousPageFor()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            PageBar pageBar = new PageBar(driver);

            /* Testing */

            pageBar = pageBar.GoToLastPage(driver);

            for (int i = pageBar.PageList.LastPageNumber - 1; i >= 0; i--)
            {

                pageBar = pageBar.GoToPreviousPage(driver);

                Assert.That(pageBar.PageList.FirstPageNumber, Is.EqualTo(1));

                if (i != 0)
                {
                    Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=" + i.ToString()));

                    Assert.That(pageBar.NextPrev.IsNext(), Is.True);
                    Assert.That(pageBar.NextPrev.IsPrevious(), Is.True);

                }
                else
                {
                    Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/"));

                    Assert.That(pageBar.NextPrev.IsNext(), Is.True);
                    Assert.That(pageBar.NextPrev.IsPrevious(), Is.False);

                }

            }

            /* Teard down */

            driver.Quit();

        }

    }
}
