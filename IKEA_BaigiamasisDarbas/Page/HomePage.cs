using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Page
{
    public class HomePage : BasePage
    {
        private const string PageAddress = "https://www.ikea.lt/lt";
        private const string room = "Vonia";
        private IWebElement buttonToCreateAccount => Driver.FindElement(By.CssSelector("#hideOnScroll > ul.navbar.navbar-nav.py-0.ml-lg-auto.align-items-start.px-0.userMenu > li.nav-item.nav-link.pr-0 > a"));
        private IWebElement searchField => Driver.FindElement(By.Id("header_searcher_desktop_input"));
        private IWebElement searchFieldButton => Driver.FindElement(By.CssSelector(".input-group-append"));
        private IWebElement resultText => Driver.FindElement(By.CssSelector("#contentWrapper > div.container-fluid > div > div > h2"));
        private IWebElement selectRoom => Driver.FindElement(By.CssSelector("#navbarDropdownRooms > span"));
        private IWebElement selectSetOfRoom => Driver.FindElement(By.LinkText(room));
        //private IWebElement buttonWishList => Driver.FindElement(By.CssSelector(".d-none .icon"));

        public HomePage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public HomePage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }
        
        public HomePage ClickLoginButton()
        {
            buttonToCreateAccount.Click();
            return this;
        }

        public HomePage SearchFieldInput(string baldas)
        {
            searchField.Clear();
            searchField.SendKeys(baldas);
            searchFieldButton.Click();
            return this;
        }

        public HomePage VerifyResult(string baldas)
        {
            Assert.IsTrue(resultText.Text.Contains(baldas), $"Rezultate nera nurodytas paieskos zodis");
            return this;
        }

        public HomePage SelectRoomForItem()
        {
            selectRoom.Click();
            selectSetOfRoom.Click();
            return this;
        }
    }
}
