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

        public class OLXProduct
        {

            private string productURL;

            private string productName;
            private string productCategory;

            private string productPrice;

            private Location productLocalization;
            private Date productDate;

            /* Getters and Setters */

            public string ProductURL
            {

                get
                {

                    return productURL;

                }
                set
                {

                    productURL = value;

                }

            }

            public string ProductName
            {

                get
                {

                    return productName;

                }
                set
                {

                    productName = value;

                }

            }

            public string ProductCategory
            {

                get
                {

                    return productCategory;

                }
                set
                {

                    productCategory = value;

                }

            }

            public string ProductPrice
            {

                get
                {

                    return productPrice;

                }
                set
                {

                    productPrice = value;

                }

            }

            public Location ProductLocalization
            {

                get
                {
                    return productLocalization;
                }
                set
                {
                    productLocalization = value;
                }

            }

            public Date ProductDate
            {

                get
                {
                    return productDate;
                }
                set
                {
                    productDate = value;
                }

            }

            public int PriceToInteger()
            {

                string dateAuxilliary = productPrice.Remove(productPrice.Length - 3).Replace(" ", ""); // Changes "X XXX zl" format to the "XXXX" for parse to be available.
                int price = Int32.Parse(dateAuxilliary);

                return price;

            }

        }

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
          * This function can be written in two versions:
          *  1. Less memory usage and less info -> driver will scrape data from the main page. 
          *  2. More memory usage, more time resources, more infor -> driver will navigate to each product's subpage and scrape the data from there.
          * Second option could be an easier one because all the data on the main page are available only by XPath. 
          * Product number should be dependend on the page number.                      
          * NOTE : on every search result page, list of <tr> has two elements before products (<wrap>).             
          * //*[@id="offers_table"]/tbody/tr[5]/td/div/table/tbody/tr[1]/td[2]/div/h3/a
          * //*[@id="offers_table"]/tbody/tr[6]/td/div/table/tbody/tr[1]/td[2]/div/h3/a 
          * //*[@id="offers_table"]/tbody/tr[6] product list element.
          */

        public void SaveProduct(IWebDriver driver, int productNumber)
        {


            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            OLXProduct product = new OLXProduct();

            string productURL = listOfProducts[0].FindElement(By.XPath("//td/div/table/tbody/tr[1]/td[2]/div/h3/a")).GetAttribute("href");
            Console.WriteLine(productURL);

            driver.Navigate().GoToUrl(productURL);

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

            string xpathPrice = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span";
            string xpathURL = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a";

            string xpathDate = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span";
            string xpathLocalization = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span";

            string xpathName = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong";
            string xpathCategory = "./td/div/table/tbody/tr[1]/td[2]/div/p/small";

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));
            OLXProduct product = new OLXProduct();

            Date dat = new Date(listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span")).Text);
            Location loc = new Location(listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span")).Text);
            Price pr = new Price(listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[3]/div/p/strong")).Text);
            Category cr = new Category(listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[2]/div/p/small")).Text);

            product.ProductPrice = listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[3]/div/p/strong")).Text;
            product.ProductURL = listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[2]/div/h3/a")).GetAttribute("href");
            //product.ProductDate = dat;
            product.ProductLocalization = loc;
            product.ProductName = listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong")).Text;
            product.ProductCategory = listOfProducts[productNumber].FindElement(By.XPath("./td/div/table/tbody/tr[1]/td[2]/div/p/small")).Text;

            Console.WriteLine(pr.Amount);
            Console.WriteLine(pr.Currency);
            Console.WriteLine(product.ProductURL);
            //Console.WriteLine(product.ProductDate.Days);
            //Console.WriteLine(product.ProductDate.Hours);
            //Console.WriteLine(product.ProductDate.Minutes);
            Console.WriteLine(product.ProductLocalization);
            Console.WriteLine(product.ProductName);
            Console.WriteLine(product.ProductCategory);

            Console.WriteLine(product.PriceToInteger());
            Console.WriteLine(product.ProductLocalization.City);
            Console.WriteLine(product.ProductLocalization.District);


            dat.DisplayDate();
            loc.DisplayLocation();
            pr.DisplayPrice();
            cr.DisplayCategory();
            return product;


        }


    }
}
