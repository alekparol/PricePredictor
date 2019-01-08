using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Chrome;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using WebScraper;

/**
* TODO: Add a function which will be changing polish letters to their english substitute. Like change ł into l in biała-podlaska. This function should be use
* in both change funtions.   
* ^ This is the code: 
* string accentedStr;
* byte[] tempBytes;
* tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(accentedStr);
* string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);  
* 
*/


namespace WebScraper
{
    public class Utilities
    {
        public string ChangeString(string stringToBeChanged, string precidingString)
        {

            stringToBeChanged = precidingString + stringToBeChanged.ToLower().Replace(" i ", "-").Replace(" ", "-") + "/";
            return stringToBeChanged;

        }

        public string ChangeName(string productName)
        {

            productName = productName.Replace(" ", "-").ToLower();
            return productName;

        }

        public string ChangeLink(string baseURL, string productName)
        {
            string nextPageURL = baseURL + "/oferty/q-" + ChangeName(productName) + "/";
            return nextPageURL;
        }

        public string ChangeLink(string baseURL, string productName, string productLocation)
        {
            string nextPageURL = baseURL + "/" + ChangeLocation(productLocation) + "/q-" + ChangeName(productName) + "/";
            return nextPageURL;
        }

        /**
         * TODO: Check how url changes for different search locations. 
         */

        public string ChangeLocation(string productLocation)
        {

            productLocation = productLocation.Replace(" ", "-").ToLower();
            return productLocation;

        }

        public string ChangePolishSings (string defaultString)
        {

            byte[] tempBytes = System.Text.Encoding.GetEncoding("ISO-8859-8").GetBytes(defaultString);
            string asciiStr = System.Text.Encoding.UTF8.GetString(tempBytes);
            return asciiStr;

        }

        /**
         * nextPageURL = baseURL + "/oferty/q-" + ut.ChangeName(productName) + "/"; for SearchProduct(string productName).
         * nextPageURL = baseURL + "/" + ut.ChangeLocation(productLocation) + "/q-" + ut.ChangeName(productName) + "/";  for SearchProduct(string productName, string productLocation).
         * Int32.Parse(matchNumber.ToString().Replace(" ","")) in ProductsList.        
        */


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
