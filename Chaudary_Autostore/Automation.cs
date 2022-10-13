using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;
using AventStack.ExtentReports;

namespace Chaudary_Autostore
{
    [TestClass]
    public class Automation : ExtentReport
    {




        public TestContext instance;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            LogReport("chaudary_auto_store_extent_report");
        }

        [ClassCleanup]
        public static void ClassCleanUp()
        {
            extentReports.Flush();
        }



        [TestInitialize]
        public void testInitalize()
        {
            Common_method.log.Info("Test case is run");
            //LogReport(TestContext.TestName);
           // exParentTest = extentReports.CreateTest(TestContext.TestName);
        }


        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Login_Data.XML","LoginWithValidCredentials",DataAccessMethod.Sequential)]
        public void LoginValid()
        {
            exParentTest = extentReports.CreateTest("login valid");
           // exChildTest = exParentTest.CreateNode("Login valid");


            string url = TestContext.DataRow["url"].ToString();

            string user = TestContext.DataRow["email"].ToString();

            string pass = TestContext.DataRow["password"].ToString();
            string[] values = new string[] { url, user, pass };

            IWebDriver automationDriver = Common_method.webDriver("chrome");

            LoginPage loginPage = new LoginPage(automationDriver);
            loginPage.login(values);
           

        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML","Login_Data.XML","LoginWithInvalidCredentials",DataAccessMethod.Sequential)]
        public void LoginInvalid()
        {

            exParentTest = extentReports.CreateTest("login invalid");
            // exChildTest = exParentTest.CreateNode("Login invalid");


            string url = TestContext.DataRow["url"].ToString();

            string user = TestContext.DataRow["email"].ToString();

            string pass = TestContext.DataRow["password"].ToString();
            string[] values = new string[] { url, user, pass };

            IWebDriver automationDriver = Common_method.webDriver("Chrome");

            LoginPage loginPage = new LoginPage(automationDriver);
            loginPage.login(values);
            

        }


        [TestCleanup]
        public void testClose()
        {
            exParentTest = null;
            //Common_method.close();
            Common_method.log.Info("Test case is close");
        }
    }
}
