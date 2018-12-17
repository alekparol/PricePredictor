using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System.Threading;
using WebScraper;
using System;

/**  
 * TODO: Check if localization parser works for locations without districts and in other formats thab "City, District".        
*/

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

            SearchPage searchPage = new SearchPage();
            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("marshall major");

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            searchPage.CountResults(chromeDriver);
            searchPage.CountPageElements(chromeDriver);
            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            /*for (int i = 4; i < 7; i ++)
            {
                product = new OLXProduct(chromeDriver, i);

            }*/
            chromeDriver.Close();

        }

        [Test]
        public void Test2()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

            SearchPage searchPage = new SearchPage();
            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("ns eccentric");

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));

            searchPage.CountResults(chromeDriver);
            searchPage.CountPageElements(chromeDriver);

            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            /*for (int i = 4; i < 7; i ++)
            {
                product = new OLXProduct(chromeDriver, i);

            }*/
            chromeDriver.Close();

        }


        [Test]
        public void Test3()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

            SearchPage searchPage = new SearchPage();
            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("mebel");

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));

            searchPage.CountResults(chromeDriver);
            searchPage.CountPageElements(chromeDriver);

            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            /*for (int i = 4; i < 7; i ++)
            {
                product = new OLXProduct(chromeDriver, i);

            }*/
            chromeDriver.Close();

        }

        [Test]
        public void Test4()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

            SearchPage searchPage = new SearchPage();
            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("mebel", "Warszawa");

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));

            searchPage.CountResults(chromeDriver);
            searchPage.CountPageElements(chromeDriver);

            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            /*for (int i = 4; i < 7; i ++)
            {
                product = new OLXProduct(chromeDriver, i);

            }*/
            chromeDriver.Close();

        }

    }
}