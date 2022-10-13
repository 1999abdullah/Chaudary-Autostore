using AventStack.ExtentReports;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Chaudary_Autostore
{
    // POM 
    public class LoginPage : Common_method
    {


        #region elements

        By myAccount = By.XPath("//a[contains(text(),'My account')]");
        By emaill = By.Id("login-customer[email]");
        By pass1 = By.Id("login-customer[password]");
        By loginButton = By.XPath("//button[contains(text(),'Login')]");
        By buttonenable = By.XPath("//*[@id='shopify-section-template--15891515998462__1649981327094ed3c5']/section/div[2]/div/div/div/button[1]");
        By recaptcha = By.Id("g-recaptcha");
        By recaptchaIfram = By.XPath("//iframe[@title='recaptcha challenge expires in two minutes']");
        By iframeButton = By.XPath("//div[@tabindex='2']");
        By submit = By.XPath("//input[@value='Submit']");
        
        #endregion


        #region Constructor
        public LoginPage(IWebDriver driver1)
        {
            commonDriver = driver1;
        }
        #endregion

        #region operation-methods

        void landingPage(string u)
        {
            commonDriver.Navigate().GoToUrl(" chrome://extensions/");
            log.Info("Open the url");
            driverUrl(u);
            log.Info("Opend url is " + u);
        }

        void clickMyAccount()
        {
            log.Info("Click the My Account button");
            click(myAccount);
            log.Info("clicked button  is " + myAccount);
        }
        void inputEmail(String emailInput)
        {
          
            log.Info("Enter the email address");
            setText(emaill, emailInput);
            ExtentReport.exParentTest.Log(Status.Pass, emailInput);
            log.Info("The entered email  is " + emailInput);
            
        }
        void inputPassword(String passInput)
        {
            log.Info("Enter the password");
            setText(pass1, passInput);
            log.Info("The entered email  is " + passInput);
        }
        void clickLogin()
        {
            log.Info("Click the login button");
            click(loginButton);
            log.Info("Clicked button is "+ loginButton);
        }

        void clickrecaptcha()
        {
            click(recaptcha);
            Thread.Sleep(5000);
           
        }

        void clickSolverButton()
        {

            frameSwitch(recaptchaIfram);
            click(iframeButton);
            Thread.Sleep(3000);

        }
        void clickSubmitButton()
        {

           
            click(submit);
            

        }


        #endregion

        #region login

        public void login(string[] a)
        {

            
            landingPage(a[0]);
            clickMyAccount();
            inputEmail(a[1]);
            inputPassword(a[2]);
            clickLogin();
            clickrecaptcha();
            clickSolverButton();
            clickSubmitButton();
        }

        #endregion

    }
}
