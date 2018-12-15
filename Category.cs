using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper
{
    public class Category
    {

        private string productCategory;

        private string mainCategory;
        private string subCategory;

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

        public Category(string productCategory)
        {

            this.productCategory = productCategory;

            string[] categoryAuxilliary = productCategory.Split("»");

            mainCategory = categoryAuxilliary[0].Trim();
            subCategory = categoryAuxilliary[1].Trim();

        }

        public void DisplayCategory()
        {

            Console.WriteLine("Product main category is: {0}", mainCategory);
            Console.WriteLine("Product subcategory is: {0}", subCategory);

        }

    }
}
