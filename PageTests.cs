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
    public class PageTests
    {


        [Test()]
        [TestCase("rower")]
        [TestCase("kuchenka elektryczna")]
        public void MainPageChangeName(string productName)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl");

            MainPage mainPage = new MainPage(driver);
            Regex productNameMatch = new Regex("(q-)+[a-zA-Z-]+(\\/)");

            /* Testing */

            mainPage.SearchProduct(productName);
            string searchProductName = driver.Url;

            Match match = productNameMatch.Match(searchProductName);
            string testName = match.ToString().Substring(2, match.ToString().Length - 3);

            Assert.That(mainPage.ut.ChangeName(productName), Is.EqualTo(testName));

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        [TestCase("Warszawa")]
        [TestCase("Biała Podlaska")]
        public void MainPageChangLocation(string productLocation)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl");

            MainPage mainPage = new MainPage(driver);
            Regex productNameMatch = new Regex("(\\/)[a-zA-Z-]+(\\/)(q-)+");

            /* Testing */

            mainPage.SearchProduct("rower", productLocation);
            string searchProductName = driver.Url;

            Match match = productNameMatch.Match(searchProductName);
            string testLocation = match.ToString().Substring(1, match.ToString().Length - 4);

            Assert.That(mainPage.ut.ChangeLocation(productLocation), Is.EqualTo(testLocation));

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        [TestCase("rower")]
        [TestCase("kuchenka elektryczna")]
        public void MainPagSearchProduct(string productName)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl");

            MainPage mainPage = new MainPage(driver);

            /* Testing */

            string searchResult = mainPage.SearchProduct(productName);

            Assert.That(driver.Url, Is.Not.EqualTo("https://www.olx.pl"));

            /* Teard down */

            driver.Quit();

        }

        [Test()]
        [TestCase("rower", "Warszawa")]
        [TestCase("kuchenka elektryczna", "Biała Podlaska")]
        public void MainPagSearchProductLocation(string productName, string productLocation)
        {

            /* Test initialization */

            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://www.olx.pl");

            MainPage mainPage = new MainPage(driver);

            /* Testing */

            string searchResult = mainPage.SearchProduct(productName, productLocation);
            Assert.That(driver.Url, Is.Not.EqualTo("https://www.olx.pl"));

            /* Teard down */

            driver.Quit();

        }

    }
}
