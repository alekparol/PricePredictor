using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebScraper
{
    public class OLXProduct
    {

        private int productNumber;

        private string xpathPrice = "./td/div/table/tbody/tr[1]/td[3]/div/p/strong";
        private string xpathURL = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a";

        private string xpathDate = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[2]/span";
        private string xpathLocalization = "./td/div/table/tbody/tr[2]/td[1]/div/p/small[1]/span";

        private string xpathName = "./td/div/table/tbody/tr[1]/td[2]/div/h3/a/strong";
        private string xpathCategory = "./td/div/table/tbody/tr[1]/td[2]/div/p/small";


        private string productURL;

        private string productName;
        private Category productCategory;

        private Price productPrice;

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

        public Category ProductCategory
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

        public Price ProductPrice
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

        /**
         * TODO: Change function from Utilities and make it constructor in this class. 
         */

        public OLXProduct (IWebDriver driver, int productNumber)
        {

            List<IWebElement> listOfProducts = new List<IWebElement>(driver.FindElements(By.ClassName("wrap")));

            productURL = listOfProducts[productNumber].FindElement(By.XPath(xpathURL)).GetAttribute("href");
            productName = listOfProducts[productNumber].FindElement(By.XPath(xpathName)).Text;

            productDate = new Date(listOfProducts[productNumber].FindElement(By.XPath(xpathDate)).Text);
            productLocalization = new Location(listOfProducts[productNumber].FindElement(By.XPath(xpathLocalization)).Text);
            productPrice = new Price(listOfProducts[productNumber].FindElement(By.XPath(xpathPrice)).Text);
            productCategory = new Category(listOfProducts[productNumber].FindElement(By.XPath(xpathCategory)).Text);


        }

        public void DisplayProductInfo ()
        {

            productDate.DisplayDate();
            productLocalization.DisplayLocation();
            productPrice.DisplayPrice();
            productCategory.DisplayCategory();

        }

    }
}
