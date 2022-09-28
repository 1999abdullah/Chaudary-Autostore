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
       public static  IWebDriver commonDriver;
        Actions action;

        #region Webdriver

        public static IWebDriver driver(string driver)
        {
            if(driver == "Chrome" )
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

        #region frequent_mathods

        // Find Element

        public IWebElement findElement(By Locate)
        {

            return commonDriver.FindElement(Locate);
        }

        // Send Text in input Feild

        public void setText(By locate,string text)
        {
            IWebElement findedElement = findElement(locate);
            findedElement.Clear();
            removeElemntText(findedElement);    
            findedElement.SendKeys(text+Keys.Tab);
        }

        // Click on the element

       public void click(By locator)
        {
            action = new Actions(commonDriver);
            action.Click(findElement(locator)).Build().Perform();
        }

        // Removing the Text in input feild

       public void removeElemntText(IWebElement element)
        {
            int a = element.Text.Length;

            while(a> 0)
            {
                element.SendKeys(Keys.Backspace);
            }
        }


        //Close Driver
        public static void close()
        {
            commonDriver.Close();
        }

        //Sleep method
        public void sleep()
        {
            Thread.Sleep(5000);
            //commonDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
        }

        
        #endregion



    }
}
