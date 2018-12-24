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
    public class SearchBarTests
    {
        [Test()]
        [TestCase("rower", "Warszawa")]
        [TestCase("marshall major", "Bydgoszcz")]
        [TestCase("kuchenka mikrofalowa", "Katowice")]
        public void SearchMain(string productName, string productLocation)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl");

            SearchBarMain pageBar = new SearchBarMain(driver);

            /* Testing */

            pageBar.TypeProductName(productName);
            pageBar.TypeLocation(productLocation);

            pageBar.SubmitSearch();
            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/" + productLocation.Trim().Replace(" ", "-").ToLower() + "/q-" + productName.Trim().Replace(" ", "-").ToLower() + "/"));

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        [TestCase("rower", "Warszawa")]
        [TestCase("marshall major", "Bydgoszcz")]
        [TestCase("kuchenka mikrofalowa", "Katowice")]
        public void SearchSearch(string productName, string productLocation)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl/warszawa/q-lodowka");

            SearchBarSearch pageBar = new SearchBarSearch(driver);

            /* Testing */

            pageBar.ClearProductName();
            pageBar.ClearLocation();

            pageBar.TypeProductName(productName);
            pageBar.TypeLocation(productLocation);

            pageBar.SubmitSearch();
            Assert.That(driver.Url, Is.EqualTo("https://www.olx.pl/" + productLocation.Trim().Replace(" ", "-").ToLower() + "/q-" + productName.Trim().Replace(" ", "-").ToLower() + "/"));

            /* Teard down */

            driver.Quit();

        }
    }
}
