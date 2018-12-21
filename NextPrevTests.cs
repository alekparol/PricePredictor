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
        [Test()] /* First page of the multipage search - isNext should be true, isPrevious should be false. */
        public void FirstPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/");

            List <IWebElement> pageChangeBar = new List<IWebElement> (driver.FindElements(By.XPath("//*[@id=\"body-container\"]/div[3]/div/div[8]")));
            NextPrev nextPrev = new NextPrev(driver, pageChangeBar);

            /* Testing */

            Assert.That(nextPrev, Is.Not.Null);
            Assert.That(nextPrev.PageNextPrev.Count, Is.Not.EqualTo(0));

            Assert.That(nextPrev.PageNext, Is.Not.Null);
            Assert.That(nextPrev.PagePrevious, Is.Not.Null);

            Assert.That(nextPrev.PageNext.GetAttribute("data-cy"), Is.EqualTo("page-link-next"));
            Assert.That(nextPrev.PagePrevious.GetAttribute("data-cy"), Is.EqualTo("page-link-prev"));

            Assert.That(nextPrev.PageNext.GetAttribute("href"), Is.Not.Null);
            Assert.That(nextPrev.PagePrevious.GetAttribute("href"), Is.Null);

            Assert.That(nextPrev.IsNext(), Is.True);
            Assert.That(nextPrev.IsPrevious(), Is.False);

            /* Teard down */

            driver.Quit();

        }

        [Test()] /* Second page of the multipage search - isNext should be true, isPrevious should be true. */
        public void SecondPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka/?page=2");

            List <IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));
            NextPrev nextPrev = new NextPrev(driver, pageChangeBar);

            /* Testing */

            Assert.That(nextPrev, Is.Not.Null);
            Assert.That(nextPrev.PageNextPrev.Count, Is.Not.EqualTo(0));

            Assert.That(nextPrev.PageNext, Is.Not.Null);
            Assert.That(nextPrev.PagePrevious, Is.Not.Null);

            Assert.That(nextPrev.PageNext.GetAttribute("href"), Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/"));
            Assert.That(nextPrev.PagePrevious.GetAttribute("href"), Is.EqualTo("https://www.olx.pl/warszawa/q-lodowka/?page=3"));

            //Assert.That(nextPrev.IsNext(), Is.True);
            //Assert.That(nextPrev.IsPrevious(), Is.True);

            /* Teard down */

            driver.Quit();

        }


        [Test()] /* Last page of the multiple page search - isNext should be false, isPrevious shoulde be true. */
        public void LastPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/oferty/q-marshall-major/?page=4");

            List <IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));
            NextPrev nextPrev = new NextPrev(driver, pageChangeBar);

            /* Testing */

            Assert.That(nextPrev, Is.Not.Null);
            Assert.That(nextPrev.PageNextPrev.Count, Is.Not.EqualTo(0));

            Assert.That(nextPrev.PageNext, Is.Not.Null);
            Assert.That(nextPrev.PagePrevious, Is.Not.Null);

            Assert.That(nextPrev.PagePrevious.GetAttribute("href"), Is.Null);
            Assert.That(nextPrev.PageNext.GetAttribute("href"), Is.Not.Empty);

            //Assert.That(nextPrev.IsNext(), Is.False);
            //Assert.That(nextPrev.IsPrevious(), Is.True);

            /* Teard down */

            driver.Quit();

        }

        [Test()] /* Empty search - isNext should be false, isPrevious should be false. */
        public void EmptyPage()
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-htrgsdfadf/");

            List<IWebElement> pageChangeBar = new List<IWebElement>(driver.FindElements(By.ClassName("pager")));
            NextPrev nextPrev = new NextPrev(driver, pageChangeBar);

            /* Testing */

            Assert.That(nextPrev, Is.Not.Null);
            Assert.That(nextPrev.PageNextPrev.Count, Is.EqualTo(0));

            Assert.That(nextPrev.PageNext, Is.Null);
            Assert.That(nextPrev.PagePrevious, Is.Null);

            //Assert.That(nextPrev.IsNext, Is.Null);

            /* Teard down */

            driver.Quit();

        }

    }
}
