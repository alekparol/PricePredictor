using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using WebScraper;

namespace OLXScraper
{
    public class Utilities
    {
   
        public string SearchOLX(IWebDriver driver, string productName)
        {

            string pageURL = "https://www.olx.pl";
            driver.Navigate().GoToUrl(pageURL);

            driver.FindElement(By.Id("headerSearch")).SendKeys(productName);
            driver.FindElement(By.Id("submit-searchmain")).Click();

            productName = ChangeProductName(productName);

            pageURL = pageURL + "/oferty/q-" + productName + "/"; // That will do only if product name is one word. In other case between two words has to be "-" sign.
            return pageURL; // It helps with testing if driver navigated to the right page. 

        }

        public string ChangeProductName(string productName)
        {

            /**
        * TODO: user should be able to use localization of the seek product. 
        * TODO: pageURL should change with the localization typed with the user.             
       */

            return productName.Replace(' ', '-');

        }

        public void CountResults(IWebDriver driver)
        {

            string numberOfResults = driver.FindElement(By.XPath("//*[@id=\"offers_table\"]/tbody/tr[1]/td//div[2]/h2")).Text;
            Regex foundResults = new Regex("\\d+");

            Match matchNumber = foundResults.Match(numberOfResults);
            Console.WriteLine(matchNumber);

        }

        /**
         * BASE //*[@id="offers_table"]/tbody/tr[3]
         * URL //td/div/table/tbody/tr[1]/td[2]/div/h3/a
         * PRICE //td/div/table/tbody/tr[1]/td[3]/div/p/strong        
         * TIME //td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span    
         * LOCALIZATION //td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span
         * NAME //td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong       
         * CATEGORY //td/div/table/tbody/tr[1]/td[2]/div/p/small 
         * 
         * 
         * Console.WriteLine(listOfProducts[productNumber].FindElement(By.ClassName("price")).Text);
         * string xpath = "//*[@id=\"offers_table\"]/tbody/tr[" + productNumber.ToString() + "]";        
        */

        public OLXProduct SaveProductMainPage(IWebDriver driver, int productNumber)
        {

            string xpathPrice = "./td/div/table/tbody/tr[1]/td[3]/div/p/strong";
            string xpathURL = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a";

            string xpathDate = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span";
            string xpathLocalization = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span";

            string xpathName = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong";
            string xpathCategory = "./td/div/table/tbody/tr[1]/td[2]/div/p/small";

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            OLXProduct product = new OLXProduct();

            product.ProductURL = listOfProducts[productNumber].FindElement(By.XPath(xpathURL)).GetAttribute("href");
            product.ProductName = listOfProducts[productNumber].FindElement(By.XPath(xpathName)).Text;

            product.ProductDate = new Date(listOfProducts[productNumber].FindElement(By.XPath(xpathDate)).Text);
            product.ProductLocalization = new Location(listOfProducts[productNumber].FindElement(By.XPath(xpathLocalization)).Text);
            product.ProductPrice = new Price(listOfProducts[productNumber].FindElement(By.XPath(xpathPrice)).Text);
            product.ProductCategory = new Category(listOfProducts[productNumber].FindElement(By.XPath(xpathCategory)).Text);

            product.ProductDate.DisplayDate();
            product.ProductLocalization.DisplayLocation();
            product.ProductPrice.DisplayPrice();
            product.ProductCategory.DisplayCategory();

            return product;

        }


    }
}
