using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebScraper
{
    public class Category
    {

        /**
         * TODO: Test Category URL.      
         * TODO: Move all functions which are used in differents modules to the one utility component. OR use changeName(), changeLocalation() etc. as a method of page class, 
         * as those methods do the same job - baseURL + / + component_first + / component_second + /.         
         */

        private string baseURL = "https://www.olx.pl/";
        private string productCategory;

        private string mainCategory;
        private string subCategory;

        private string categoryURL;

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

        public string MainCategory
        {

            get
            {
                return mainCategory;
            }
            set
            {
                mainCategory = value;
            }

        }

        public string SubCategory
        {

            get
            {
                return subCategory;
            }
            set
            {
                subCategory = value;
            }

        }

        public string CategoryURL
        {

            get
            {
                return categoryURL;
            }
            set
            {
                categoryURL = value;
            }

        }

        public Category (string productCategory)
        {

            this.productCategory = productCategory;
            string[] categoryAuxilliary = productCategory.Split("»");

            mainCategory = categoryAuxilliary[0].Trim();
            subCategory = categoryAuxilliary[1].Trim();

            categoryURL = baseURL + "/" + mainCategory.ToLower().Replace(" ", "-") + "/" + subCategory.ToLower().Replace(" ", "-") + "/";

        }

        public void DisplayCategory ()
        {

            Console.WriteLine("Product main category is: {0}", mainCategory);
            Console.WriteLine("Product subcategory is: {0}", subCategory);

        }

        public string GoToCategory (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(categoryURL);
            return categoryURL;

        }

    }
}
