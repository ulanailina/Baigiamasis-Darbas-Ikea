using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;

namespace IKEA_BaigiamasisDarbas.Page
{
    public class LoginAndRegisterPage : BasePage
    {
        private const string PageAddress = "https://www.ikea.lt/lt/client";

        private IWebElement registerEmailInput => Driver.FindElement(By.Id("loginForm_emailCreate"));
        private IWebElement buttonRegister => Driver.FindElement(By.Id("loginForm_createAccount"));
        private IWebElement actualRegisterResult => Driver.FindElement(By.XPath("//*[@id=contentWrapper]/div/div/div[1]/div[2]/div/form/div[1]/p"));
        private IWebElement emailInput => Driver.FindElement(By.Id("loginForm_email"));
        private IWebElement passwordInput => Driver.FindElement(By.Id("loginForm_password"));
        private IWebElement buttonToConfirmLogin => Driver.FindElement(By.Id("btnSubmitLogin"));
        private IWebElement buttonWishList => Driver.FindElement(By.CssSelector(".d-none .icon"));

        public LoginAndRegisterPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public LoginAndRegisterPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public LoginAndRegisterPage RegisterEmailInput(string registerEmail)
        {
            registerEmailInput.Clear();
            registerEmailInput.SendKeys(registerEmail);
            buttonRegister.Click();
            return this;
        }

        public LoginAndRegisterPage VerifyRegisterInputResult(string expectedResult)
        {
            Assert.IsTrue(actualRegisterResult.Text.Equals(expectedResult));
            return this;
        }

        private LoginAndRegisterPage EnterEmail(string email)
        {
            emailInput.Clear();   
            emailInput.SendKeys(email);
            return this;
        }

        private LoginAndRegisterPage EnterPassword(string password)
        {
            passwordInput.Clear();
            passwordInput.SendKeys(password);
            return this;
        }

        public LoginAndRegisterPage EnterLoginData(string email, string password)
        {
            EnterEmail(email);
            EnterPassword(password);
            return this;
        }

        public LoginAndRegisterPage ClickButtonToConfirmLogin()
        {
            buttonToConfirmLogin.Click();
            return this;
        }
    }
}
