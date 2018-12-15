using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System.Threading;

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
            IWebDriver chromeDriver = new ChromeDriver("C:\\Users\\User\\Documents\\GitHub\\OLXScraper\\packages\\Selenium.WebDriver.ChromeDriver.2.45.0\\driver\\win32");

            OLXScraper.Utilities ut = new OLXScraper.Utilities();
            string nextPageURL = ut.SearchOLX(chromeDriver, "ns eccentric");

            Thread.Sleep(100);

            Assert.That(nextPageURL, Is.EqualTo(chromeDriver.Url));
            ut.CountResults(chromeDriver);
            ut.SaveProductMainPage(chromeDriver, 7); // With xpath it has to be done from the third element. 

            chromeDriver.Close();
        }

    }
}