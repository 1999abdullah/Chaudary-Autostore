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
      



        public TestContext instance;
        public TestContext TestContext
        {

            set { instance = value; }
            get { return instance; }

        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Login_Data.XML","LoginWithValidCredentials",DataAccessMethod.Sequential)]
        public void LoginValid()
        {

            string url = TestContext.DataRow["url"].ToString();

            string user = TestContext.DataRow["email"].ToString();

            string pass = TestContext.DataRow["password"].ToString();


            IWebDriver automationDriver = Common_method.webDriver("chrome");

            LoginPage loginPage = new LoginPage(automationDriver);
            loginPage.login(url,user, pass);


        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Login_Data.XML","LoginWithInvalidCredentials",DataAccessMethod.Sequential)]
        public void LoginInvalid()
        {

            string url = TestContext.DataRow["url"].ToString();

            string user = TestContext.DataRow["email"].ToString();

            string pass = TestContext.DataRow["password"].ToString();


            IWebDriver automationDriver = Common_method.webDriver("Chrome");

            LoginPage loginPage = new LoginPage(automationDriver);
            loginPage.login(url,user, pass);


        }


        [TestCleanup]
        public void testClose()
        {
            Common_method.close();
        }
    }
}
