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
            //bool b = isElementTextFeild(pass1);
            //MessageBox.Show(b.ToString());
            log.Info("Enter the email address");
            setText(emaill, emailInput);
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

        }

        
        #endregion

        #region login

        public void login(string[] a)
        {

            
            landingPage(a[0]);
            
            //string text = getElementText(myAccount);
            //scrollToElement(buttonenable);
            //string state = getElementState(buttonenable);
            //MessageBox.Show(state);
            //scrollToElement(myAccount);

            clickMyAccount();

            inputEmail(a[1]);

            inputPassword(a[2]);
            clickLogin();
            // MessageBox.Show(text);
            sleep(5000);
            clickrecaptcha();
            sleep(5000);
        }

        #endregion

    }
}
