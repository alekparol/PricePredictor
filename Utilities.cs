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
        public string ChangeString(string stringToBeChanged, string precidingString)
        {

            stringToBeChanged = precidingString + stringToBeChanged.ToLower().Replace(" i ", "-").Replace(" ", "-") + "/";
            return stringToBeChanged;

        }
        /**
         * 
         * About class name "wrap" - there are two kinds of elements on the OLX page: 
         * sponsored content, and others. With both categories there are elements of the 
         * class named "wrap", but in each of those, there are two "empty" elements on the
         * beginning of the list. 
         * 
         */

        /**
         * BASE //*[@id="offers_table"]/tbody/tr[3]
         * URL //td/div/table/tbody/tr[1]/td[2]/div/h3/a
         * PRICE //td/div/table/tbody/tr[1]/td[3]/div/p/strong        
         * TIME //td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span    
         * LOCALIZATION //td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span
         * NAME //td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong       
         * CATEGORY //td/div/table/tbody/tr[1]/td[2]/div/p/small    
        */


    }
}
