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

        


    }
}
