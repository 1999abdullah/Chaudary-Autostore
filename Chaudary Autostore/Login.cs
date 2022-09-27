using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;

namespace Chaudary_Autostore
{
    
    public class LoginPage : Common_method
    {
        

        #region elements

        By myAccount = By.XPath("//a[contains(text(),'My account')]");
        By email = By.Id("login-customer[email]");
        By pass1 = By.Id("login-customer[password]");
        By loginButton = By.XPath("//button[contains(text(),'Login')]");

        #endregion

        #region Constructor
        public LoginPage(IWebDriver driver1)
        {
            commonDriver =driver1;
        }
        #endregion

        #region operation-methods
        
        void clickMyAccount()
        {
            click(myAccount);
        }
        void inputEmail(String emailInput)
        {
            setText(email, emailInput);
        }
        void inputPassword(String passInput)
        {
            setText(pass1, passInput);
        }
        void clickLogin()
        {
            click(loginButton);
        }

        void close()
        {
            commonDriver.Navigate().Back();
            commonDriver.Navigate().Refresh();
        }
        #endregion

        #region login

        public void login(string email,string pass)
        {
            clickMyAccount();
            inputEmail(email);
          //click(pass1);
            inputPassword(pass);
            clickLogin();
            close();
        }

        #endregion

    }
}
