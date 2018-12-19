using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support;
using OpenQA.Selenium.Firefox;
using System.Threading;
using WebScraper;
using System;

namespace WebScraper
{
    [TestFixture]
    public class CategoryTests
    {

        [Test]
        public void TestMainCategorEmpty()
        {

            MainCategory testMainCategory = new MainCategory();
            Assert.That(testMainCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testMainCategory.MainCategoryName, Is.EqualTo(null));
            Assert.That(testMainCategory.MainCategoryURL, Is.EqualTo(null));

        }

        [Test]
        [TestCase("Rowery")]
        [TestCase("Muzyka i Elektronika")]
        [TestCase("dziecko")]
        [TestCase("dasd awdasd sad2")]
        public void TestMainCategoryNonEmpty(string productCategory)
        {

            MainCategory testMainCategory = new MainCategory(productCategory);
            Assert.That(testMainCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testMainCategory.MainCategoryName, Is.EqualTo(productCategory));
            Assert.That(testMainCategory.MainCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

        }

        [Test]
        public void TestSubCategorEmpty()
        {

            SubCategory testSubCategory = new SubCategory();
            Assert.That(testSubCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testSubCategory.MainCategoryName, Is.EqualTo(null));
            Assert.That(testSubCategory.MainCategoryURL, Is.EqualTo(null));

            Assert.That(testSubCategory.SubCategoryName, Is.EqualTo(null));
            Assert.That(testSubCategory.SubCategoryURL, Is.EqualTo(null));

        }

        [Test]
        [TestCase("Rowery")]
        [TestCase("Muzyka i Elektronika")]
        [TestCase("dziecko")]
        [TestCase("dasd awdasd sad2")]
        public void TesSubCategoryNonEmpty(string productCategory)
        {

            SubCategory testSubCategory = new SubCategory(productCategory);
            Assert.That(testSubCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testSubCategory.MainCategoryName, Is.EqualTo(productCategory));
            Assert.That(testSubCategory.MainCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

        }

        [Test]
        [TestCase("Rowery » Rowery Gorskie")]
        [TestCase("Muzyka i Elektronika » Zabawki i Costam")]
        [TestCase("dziecko » ")]
        [TestCase(" » dasd awdasd sad2")]
        public void TestCategoryNonEmpty(string productCategory)
        {

            SubCategory testSubCategory = new SubCategory(productCategory);
            Assert.That(testSubCategory.BaseURL, Is.EqualTo("https://www.olx.pl/"));

            Assert.That(testSubCategory.MainCategoryName, Is.EqualTo(productCategory.Split("»")[0].Trim()));
            Assert.That(testSubCategory.MainCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Split("»")[0].Trim().Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

            Assert.That(testSubCategory.SubCategoryName, Is.EqualTo(productCategory.Split("»")[1].Trim()));
            Assert.That(testSubCategory.SubCategoryURL, Is.EqualTo("https://www.olx.pl/" + productCategory.Split("»")[1].Trim().Replace(" i ", "-").Replace(" ", "-").ToLower() + "/"));

        }

    }
}
