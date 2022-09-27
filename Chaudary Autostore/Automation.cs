using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace Chaudary_Autostore
{
    [TestClass]
    public class Automation 
    {
        

        [TestMethod]
        public void Login()
        {
            IWebDriver automationDriver = new ChromeDriver();
            automationDriver.Manage().Window.Maximize();
            automationDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            automationDriver.Url = "https://chaudhryautostore.com/";

            LoginPage loginPage = new LoginPage(automationDriver);
            loginPage.login("abdullah@gmail.com", "1999Phonex");
            automationDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            loginPage.login("abdullah@gmail.com", "1999Phonex");

        }
    }
}
