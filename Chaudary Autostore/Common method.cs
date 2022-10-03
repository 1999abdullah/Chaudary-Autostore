﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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
using System.Windows.Forms;
using Keys = OpenQA.Selenium.Keys;

namespace Chaudary_Autostore
{
    // Common Method

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

            bool a= isElementTextFeild(locate);
            if (a== true)
            {
                IWebElement findedElement = findElement(locate);
                findedElement.Clear();
                removeElemntText(findedElement);
                findedElement.SendKeys(text + Keys.Tab);
            }
            else if (a== false)
            {
                MessageBox.Show("Element feild is not corerect");
            }
           
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
        public void sleep(int seconds)
        {
            Thread.Sleep(seconds);
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
        private  bool isElementTextFeild(By locator)
        {
            IWebElement element = findElement(locator);

            try
            {
                bool resultEmail = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("email"));
                bool resultText = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("text"));
                bool resultpass = Convert.ToBoolean(element
                    .GetAttribute("type")
                    .Equals("password"));
                bool a =resultpass == true || resultText == true || resultEmail == true ? true : false;
                return a;
                
            }
            catch
            {
                return false;
            }
        }

        #endregion

        #region Get Element State
        public string getElementState(By locator)
        {
            string state= findElement(locator).GetAttribute("Disabled");
             return state == null ? "enabled" : state == "true" ? "disabled" : "Invalid";

        }
        #endregion


        #region Scroll To Element
        public void scrollToElement(By locator)
        {
            IWebElement state = findElement(locator);
            IJavaScriptExecutor commonExecuter = (IJavaScriptExecutor)commonDriver;
            commonExecuter.ExecuteScript("arguments[0].scrollIntoView(true); ", state);


        }
        #endregion


        #region Java Script Executer
        public static string ExecuteJavaScriptCode(string javascriptCode)
        {
            string value = null;
            try
            {
                IJavaScriptExecutor js = (IJavaScriptExecutor)commonDriver;
                value = (string)js.ExecuteScript(javascriptCode);
            }
            catch (Exception)
            {

            }
            return value;
        }

        #endregion

        #endregion





    }
}
