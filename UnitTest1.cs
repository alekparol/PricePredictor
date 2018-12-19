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
        public void TestMainCategorEmpty()
        {

            MainCategory testMainCategory = new MainCategory();
            Assert.That(testMainCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testMainCategory.MainCategoryName, Is.EqualTo(null));
            Assert.That(testMainCategory.MainCategoryURL, Is.EqualTo(null));

        }

        /**
         * Test of GoToCategory() can be done only after initializing a IWebDriver. So this has to be moved to another test.        
         *      
        */

        [Test]
        [TestCase("Rowery")]
        [TestCase("Muzyka i Elektronika")]
        [TestCase("dziecko")]
        [TestCase("dasd awdasd sad2")]
        public void TestMainCategoryNonEmpty(string productCategory)
        {

            MainCategory testMainCategory = new MainCategory(productCategory);
            Assert.That(testMainCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testMainCategory.MainCategoryName, Is.EqualTo(productCategory));
            Assert.That(testMainCategory.MainCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

        }

        [Test]
        public void TestSubCategorEmpty()
        {

            SubCategory testSubCategory = new SubCategory();
            Assert.That(testSubCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testSubCategory.MainCategoryName, Is.EqualTo(null));
            Assert.That(testSubCategory.MainCategoryURL, Is.EqualTo(null));

            Assert.That(testSubCategory.SubCategoryName, Is.EqualTo(null));
            Assert.That(testSubCategory.SubCategoryURL, Is.EqualTo(null));

        }

        [Test]
        [TestCase("Rowery")]
        [TestCase("Muzyka i Elektronika")]
        [TestCase("dziecko")]
        [TestCase("dasd awdasd sad2")]
        public void TesSubCategoryNonEmpty(string productCategory)
        {

            MainCategory testMainCategory = new MainCategory(productCategory);
            Assert.That(testMainCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testMainCategory.MainCategoryName, Is.EqualTo(productCategory));
            Assert.That(testMainCategory.MainCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

        }

        [Test]
        public void Test1()
        {
            IWebDriver chromeDriver = new ChromeDriver();
            chromeDriver.Manage().Timeouts().PageLoad = TimeSpan.FromMinutes(2);

            MainPage mainPage = new MainPage(chromeDriver);
            string nextPageURL = mainPage.SearchProduct("marshall major");
            SearchPage searchPage = new SearchPage(chromeDriver);

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            searchPage.CountResults(chromeDriver);
            searchPage.CountPageElements(chromeDriver);
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