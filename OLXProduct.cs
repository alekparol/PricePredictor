using System;
using System.Collections.Generic;
using System.Text;

namespace WebScraper
{
    public class OLXProduct
    {

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

    }
}
