using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class WebPageInteraction
    {
        // Framework Project - Element Interaction and Waits implementations
        // Region to create and declare WebElements
        #region elements definition
        By linkAccountAndLists = By.CssSelector("#nav-tools>a:nth-of-type(1)>span:nth-of-type(1)");
        //By btnIdentifyFlyout = By.CssSelector("#nav-flyout-ya-signin>a");
        By inputEmail = By.CssSelector("#ap_email");
        By btnContinue = By.CssSelector("#continue");
        By inputPassword = By.CssSelector("#ap_password");
        By btnSignIn = By.CssSelector("#signInSubmit");
        By InputSearchBar = By.CssSelector("#twotabsearchtextbox");
        By BtnSearch = By.CssSelector("#nav-search>form>div:nth-of-type(3)>div");
        By LblFirstPrice = By.XPath("//*[@id='search']/div[1]/div[2]/div[1]/span/div[2]/div[2]/div/span/div[1]/div[1]/div[4]/div/div/div/a/span[1]/span[1]");

        By PriceFirstProduct = By.CssSelector("//*[contains(@id,'search')]/div[1]/div[2]/div[1]/span/div[2]/div[1]/div/span/div[1]/div[1]/div[4]");
        By LinkFirstProduct = By.XPath("//*[contains(@id,'search')]/div[1]/div[2]/div[1]/span/div[2]/div[1]/div/span/div[1]/div[1]/div[2]/h2/a[1]"); 
        By LinkFirstProductWithPrice = By.XPath("//*[contains(@id,'search')]/div[1]/div[2]/div[1]/span/div[2]/div[2]/div/span/div[1]/div[1]/div[2]/h2/a[1]");

        By ProductPrice = By.CssSelector("#priceblock_ourprice");
        By BtnAddToCart = By.XPath("//*[@id='addToCart_feature_div'][1]");
        By CartAmount = By.XPath("//div[@id='nav-cart-count-container']/span");
        By CartPrice = By.XPath("//div[@id='hlb-subcart']/div/span/span[2]");
        By LinkCloseSideSheet = By.XPath("//a[@id='attach-close_sideSheet-link']"); 
        #endregion
        
        public void GotoWebSite(IWebDriver driver, String webSite)
        {
            driver.Navigate().GoToUrl(webSite);
        }

        public void LoginWithValidCreds(string Email, string Password, IWebDriver driver)
        {
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            ClickWebElement(linkAccountAndLists, driver);
            //ClickWebElement(linkAccountAndLists, driver);
            //ClickWebElement(btnIdentifyFlyout, driver);
            WaitWebElement(inputEmail, driver); 
            SendKeysAction(inputEmail, Email, driver); 
            ClickWebElement(btnContinue, driver);
            WaitWebElement(inputPassword, driver);
            SendKeysAction(inputPassword, Password, driver);
            ClickWebElement(btnSignIn, driver);            
        }

        public void SearchProduct(string ProductName, IWebDriver driver)
        {
            WaitWebElement(InputSearchBar, driver);
            SendKeysAction(InputSearchBar, ProductName, driver);
            WaitWebElement(BtnSearch, driver);
            ClickWebElement(BtnSearch, driver); 
        }

        public string SelectFirstProductSavePrice(IWebDriver driver)
        {
            WaitWebElement(LinkFirstProduct, driver);
            return driver.FindElement(LblFirstPrice).GetAttribute("innerHTML");            
        }

        public void ClickTheProduct(IWebDriver driver)
        {
            WaitWebElement(LinkFirstProductWithPrice, driver);
            ClickWebElement(LinkFirstProductWithPrice, driver);
        }

        public void ClickProduct(IWebDriver driver)
        {
            WaitWebElement(LinkFirstProduct, driver);
            ClickWebElement(LinkFirstProduct, driver);
        }

        public string GetDetailPrice(IWebDriver driver)
        { 
            WaitWebElement(ProductPrice, driver);
            return driver.FindElement(ProductPrice).Text.ToString();
        }

        public void AddToCart(IWebDriver driver)
        {
            WaitWebElement(BtnAddToCart, driver);
            ClickWebElement(BtnAddToCart, driver);
            if (driver.FindElements(LinkCloseSideSheet).Count > 0)
            {
                ClickWebElement(LinkCloseSideSheet, driver);
            }                
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public string GetCartPrice(IWebDriver driver)
        {
            WaitWebElement(CartPrice, driver);
            return driver.FindElement(CartPrice).GetAttribute("innerHTML");
             
        }

        public string GetCartAmount(IWebDriver driver)
        {
            WaitWebElement(CartAmount, driver);
            return driver.FindElement(CartAmount).GetAttribute("innerHTML");
        }

        void WaitWebElement(By byElement, IWebDriver driver)
        {
            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(ExpectedConditions.ElementIsVisible(byElement));
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }

        void ClickWebElement(By byElement, IWebDriver driver)
        {
            try
            {
                driver.FindElement(byElement).Click();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
        }
        public void SendKeysAction(By ByElement, String strValue, IWebDriver driver)
        {
            driver.FindElement(ByElement).SendKeys(strValue);
        }

    }
}
