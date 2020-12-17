// Dependency on Framework Project
using Framework; 
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Support; 
using TechTalk.SpecFlow;
using System;
using System.Text.RegularExpressions;

namespace E3AutomationCSharp
{
    // Execution class implementing MS Test & SpecFlow
    [TestClass, Binding]
    public class Feature1Steps
    {
        private IWebDriver driver;
        public String StrWebSite { get; set; }
        public String StrUserEmail { get; set; }
        public String StrUserPassword { get; set; }
        public string Product1SearchedPrice { get; set; }
        public string Product1SearchedPriceDec{ get; set; }
        public string Product1DetailPrice { get; set; }
        public string ProductCartPrice { get; set; }
        public string AmountCart { get; set; }

        [BeforeScenario, TestInitialize]
        public void BrowserCreation()
        {
            try
            {
                var MySetup = new Framework.SetUp();
                driver = MySetup.SetUpMethod();
                driver.Manage().Window.Maximize();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        [Given(@"Go to Amazon\.com\.mx")]
        public void GivenGoToAmazon_Com_Mx()
        {
            try
            {
                var readMyFile = new Framework.ReadConfigFile();
                var AmazonTest = new Framework.WebPageInteraction();
                StrWebSite = readMyFile.ReadData("WebSite"); 
                AmazonTest.GotoWebSite(driver, StrWebSite);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        [When(@"Login with valid credentials")]
        public void WhenLoginWithValidCredentials()
        {
            var readMyFile = new Framework.ReadConfigFile();
            var AmazonTest = new Framework.WebPageInteraction();
            StrUserEmail = readMyFile.ReadData("Email");
            StrUserPassword = readMyFile.ReadData("Password"); 
            AmazonTest.LoginWithValidCreds(StrUserEmail, StrUserPassword, driver); 
        }

        [When(@"Search for product: '(.*)'")]
        public void WhenSearchForProduct(string ProductName)
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmazonTest.SearchProduct(ProductName, driver); 
        }

        [When(@"Select first product with price and save the price")]
        public void WhenSelectFirstProductAndSaveThePrice()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            Product1SearchedPrice = AmazonTest.SelectFirstProductSavePrice(driver);
        }

        [When(@"Click on the product")]
        public void WhenClickOnTheProduct()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmazonTest.ClickTheProduct(driver); 
        }

        [Then(@"Validate first price vs detail price")]
        public void ThenValidateFirstPriceVsDetailPrice()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            Product1DetailPrice = AmazonTest.GetDetailPrice(driver);
            Assert.AreEqual(Product1SearchedPrice, Product1DetailPrice); 

        }

        [When(@"Click on Add to Cart")]
        public void WhenClickOnAddToCart()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmazonTest.AddToCart(driver);
        }

        [Then(@"Validate again, first price vs current price")]
        public void ThenValidateAgainFirstPriceVsCurrentPrice()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            ProductCartPrice = AmazonTest.GetCartPrice(driver);
            Assert.AreEqual(Product1SearchedPrice, ProductCartPrice);
        }

        [Then(@"Validate that the Shop car has '(.*)' as a number")]
        public void ThenValidateThatTheShopCarHasAsANumber(string Amount)
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmountCart = Regex.Match(AmazonTest.GetCartAmount(driver), @"\d+").Value;
            Assert.AreEqual(AmountCart, Amount);
        }

        [When(@"Search for another product: '(.*)'")]
        public void WhenSearchForAnotherProduct(string ProductName)
        {
                var AmazonTest = new Framework.WebPageInteraction();
                AmazonTest.SearchProduct(ProductName, driver);
        }

        [When(@"Select First product")]
        public void WhenSelectFirstProduct()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmazonTest.ClickProduct(driver);
        }

        [When(@"Add to Cart")]
        public void WhenAddToCart()
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmazonTest.AddToCart(driver);
        }

        [Then(@"Verify that the cart number is now '(.*)'")]
        public void ThenVerifyThatTheCartNumberIsNow(string Amount)
        {
            var AmazonTest = new Framework.WebPageInteraction();
            AmountCart = Regex.Match(AmazonTest.GetCartAmount(driver), @"\d+").Value;
            Assert.AreEqual(AmountCart, Amount);
        }

        [AfterScenario, TestMethod]
        public void CloseTheBrowser()
        {
            try
            {
                driver.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
    }
}
