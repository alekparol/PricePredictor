using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace WebScraper
{
    public class MainCategory
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

        protected string mainCategoryName;
        protected string mainCategoryURL;

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

        public string MainCategoryName
        {

            get
            {
                return mainCategoryName;
            }
            set
            {
                mainCategoryName = value;
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


        public MainCategory ()
        {

        }


        public MainCategory (string productCategory)
        {

            this.productCategory = productCategory;
            string[] categoryAuxilliary = productCategory.Split("»");

            mainCategoryName = categoryAuxilliary[0].Trim();
            mainCategoryURL = baseURL + "/" + mainCategoryName.ToLower().Replace(" ", "-") + "/";

        }

        /* ============= */
        /* Class Methods */
        /* ============= */

        public void DisplayCategory ()
        {

            Console.WriteLine("Product main category is: {0}", mainCategoryName);

        }

        public void DisplayCategoryInPolish ()
        {

            Console.WriteLine("Glowna kategoria produtku to: {0}", mainCategoryName);

        }

        public string GoToCategory (IWebDriver driver)
        {

            driver.Navigate().GoToUrl(mainCategoryURL);
            return mainCategoryURL;

        }

    }

    public class SubCategory:MainCategory
    {

        private string subCategoryName;
        private string subCategoryURL;

        /* =================== */
        /* Getters and Setters */
        /* =================== */

        public string SubCategoryName
        {

            get
            {
                return subCategoryName;
            }
            set
            {
                subCategoryName = value;
            }

        }

        public string SubCategoryURL
        {

            get
            {
                return subCategoryURL;
            }
            set
            {
                subCategoryURL = value;
            }

        }

        /* ============ */
        /* Constructors */
        /* ============ */

        public SubCategory()
        {

        }


        public SubCategory (string productCategory):base(productCategory)
        {
        
            string[] categoryAuxilliary = productCategory.Split("»");

            subCategoryName = categoryAuxilliary[1].Trim();
            subCategoryURL = mainCategoryURL + subCategoryName.ToLower().Replace(" ", "-") + "/";

        }


        /* ============= */
        /* Class Methods */
        /* ============= */

        public void DisplayCategory()
        {

            Console.WriteLine("Product main category is: {0}", mainCategoryName);
            Console.WriteLine("Product subcategory is: {0}", subCategoryName);

        }

        public void DisplayCategoryInPolish()
        {

            Console.WriteLine("Glowna kategoria produtku to: {0}", mainCategoryName);
            Console.WriteLine("Podkategoria produktu to: {0}", subCategoryName);

        }

        public string GoToSubCategory(IWebDriver driver)
        {

            driver.Navigate().GoToUrl(subCategoryURL);
            return subCategoryURL;

        }

    }

}

