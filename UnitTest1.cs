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
 * TODO: Change sequence of methods and class initialization -> 
 * 1. Firstly we initialize main page with given driver.
 * 2. Then We call methon searchProduct() on the mainPage.
 * 3. Then We initialize searchPage() object with a driver.  
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

            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("marshall major");
            SearchPage searchPage = new SearchPage(chromeDriver);
            ProductsList productsList = new ProductsList(chromeDriver);

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            searchPage.DisplayAll();
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

            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("ns eccentric");
            SearchPage searchPage = new SearchPage();

            Thread.Sleep(100);


            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
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

            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("mebel");
            SearchPage searchPage = new SearchPage(chromeDriver);

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            searchPage.DisplayAll();
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

            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("telefon", "Warszawa");
            SearchPage searchPage = new SearchPage(chromeDriver);

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            OLXProduct product = new OLXProduct(chromeDriver, 10);
            product.DisplayProductInfo();
            searchPage.DisplayAll();
            /*for (int i = 4; i < 7; i ++)
            {
                product = new OLXProduct(chromeDriver, i);

            }*/
            chromeDriver.Close();

        }

    }
}