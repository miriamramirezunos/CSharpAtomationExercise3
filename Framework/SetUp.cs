using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Edge; 

namespace Framework
{
    //  Framework Project - Browser Set Up
    public class SetUp
    {
        public IWebDriver driver;
        public IWebDriver SetUpMethod()
        {
            try
            {
                driver = new EdgeDriver();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            return driver;
        }
    }
}
