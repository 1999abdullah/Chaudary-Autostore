using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
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
            driverUrl(u);
        }

        void clickMyAccount()
        {
            click(myAccount);
        }
        void inputEmail(String emailInput)
        {
            //bool b = isElementTextFeild(pass1);
            //MessageBox.Show(b.ToString());
            setText(emaill, emailInput);
        }
        void inputPassword(String passInput)
        {
            setText(pass1, passInput);
        }
        void clickLogin()
        {
            click(loginButton);
        }

        void clickrecaptcha()
        {
            click(recaptcha);

        }

        //void close()
        //{
        //    commonDriver.Navigate().Back();
        //    commonDriver.Navigate().Refresh();
        //}
        #endregion

        #region login

        public void login(string url, string email, string pass)
        {
            landingPage(url);
           // string text = getElementText(myAccount);
            //scrollToElement(buttonenable);
            //string state = getElementState(buttonenable);
            //MessageBox.Show(state);
            //scrollToElement(myAccount);
            clickMyAccount();

            inputEmail(email);
           
            inputPassword(pass);
            clickLogin();
            // MessageBox.Show(text);
            sleep(5000);
            clickrecaptcha();
            sleep(5000);
        }

        #endregion

    }
}
