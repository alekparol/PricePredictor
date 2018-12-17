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
         * TODO: Change getters and setter to read only or write only. 
         * TODO: Think about inheritance and changing private to protected.         
         * TODO: Provide translation for categories and subcategories with google translate (yep, that is pretty stupid idea).         
         */

        private string baseURL = "https://www.olx.pl/";
        private string productCategory;

        private string mainCategory;
        private string subCategory;

        private string mainCategoryURL;
        private string subCategoryURL;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string ProductCategory
        {

            get
            {
                return productCategory; // Readonly.
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

        public string MainCategoryURL
        {

            get
            {
                return mainCategoryURL;
            }
            set
            {
                mainCategoryURL = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */


        public Category ()
        {

        }


        public Category (string productCategory)
        {

            this.productCategory = productCategory;
            string[] categoryAuxilliary = productCategory.Split("»");

            mainCategory = categoryAuxilliary[0].Trim();
            subCategory = categoryAuxilliary[1].Trim();

            mainCategoryURL = baseURL + "/" + mainCategory.ToLower().Replace(" ", "-") + "/";
            subCategoryURL = mainCategoryURL + subCategory.ToLower().Replace(" ", "-") + "/";

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void DisplayCategory ()
        {

            Console.WriteLine("Product main category is: {0}", mainCategory);
            Console.WriteLine("Product subcategory is: {0}", subCategory);

        }

        public void DisplayCategoryInPolish ()
        {

            Console.WriteLine("Glowna kategoria produtku to: {0}", mainCategory);
            Console.WriteLine("Podkategoria produktu to: {0}", subCategory);

        }

        public string GoToCategory (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(mainCategoryURL);
            return mainCategoryURL;

        }

        public string GoToSubCategory(IWebDriver driver)
        {

            driver.Navigate().GoToUrl(subCategoryURL);
            return subCategoryURL;

        }



    }
}
