using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Chaudary_Autostore
{
    public class Common_method
    {
        public static IWebDriver commonDriver;
        Actions action;

        #region Webdriver

        public static IWebDriver webDriver(string driver)
        {
            if (driver == "Chrome")
            {
                commonDriver = new ChromeDriver();
            }
            else if (driver == "firefox")
            {
                commonDriver = new FirefoxDriver();

            }
            else if (driver == "edge")
            {
                commonDriver = new EdgeDriver();

            }
            commonDriver.Manage().Window.Maximize();
            return commonDriver;
        }

        #endregion

        #region General Method


        #region Find element
        public IWebElement findElement(By Locate)
        {

            return commonDriver.FindElement(Locate);
        }

        #endregion


        #region Url calling
        public void driverUrl(string url)
        {
            commonDriver.Url = url;
            //commonDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        #endregion

        #region Send Text 
        public void setText(By locate, string text)
        {
            IWebElement findedElement = findElement(locate);
            findedElement.Clear();
            removeElemntText(findedElement);
            findedElement.SendKeys(text + Keys.Tab);
        }
        #endregion

        #region Click 

        public void click(By locator)
        {
            action = new Actions(commonDriver);
            action.Click(findElement(locator)).Build().Perform();
        }
        #endregion

        #region Removing the Text 

        public void removeElemntText(IWebElement element)
        {
            int a = element.Text.Length;

            while (a > 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }
        #endregion

        #region Close Driver
        public static void close()
        {
            commonDriver.Close();
        }

        #endregion

        #region Sleep method
        public void sleep()
        {
            Thread.Sleep(5000);
            //commonDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }
        #endregion

        #region Get Element Text
        public string getElementText(By locator)
        {
            string text;
            try
            {
                text = findElement(locator).Text;
            }
            catch
            {
                try
                {
                    text = findElement(locator).GetAttribute("Value");
                }
                catch
                {
                    text = findElement(locator).GetAttribute("innerHTML");

                }
            }
            return text;

        }
        #endregion

        #region Is Element Text Feild
        public  bool isElementTextFeild(By locator)
        {

            try
            {
                //bool resultText = Convert.ToBoolean(commonDriver.FindElement(locator)
                //    .GetAttribute("type")
                //    .Equals("text"));
                bool resultpass = Convert.ToBoolean(commonDriver.FindElement(locator)
                    .GetAttribute("type")
                    .Equals("Paassword"));
                bool a =resultpass == true  /*|| resultpass == false*/ ? true : false;
                return a;
                
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #endregion



    }
}
