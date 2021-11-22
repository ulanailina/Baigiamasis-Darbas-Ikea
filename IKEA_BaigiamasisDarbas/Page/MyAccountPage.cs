using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Page
{
    public class MyAccountPage : BasePage
    {
        private const string PageAddress = "https://www.ikea.lt/lt/client/account/favourites";

        private IWebElement buttonYourDetails => Driver.FindElement(By.Id("yourdetails-tab"));
        private IWebElement nameInAccount => Driver.FindElement(By.Id("personalData"));

        private SelectElement options => new SelectElement(Driver.FindElement(By.ClassName(".actionbox")));


        //private IWebElement buttonRedaguoti => Driver.FindElement(By.CssSelector(".actionbox:nth-child(8) > a:nth-child(1)"));

        //private IWebElement pavadinimoField => Driver.FindElement(By.CssSelector("#yourdetails .row:nth-child(1)"));
        //private IWebElement pavadinimoInput => Driver.FindElement(By.Id("name_1"));
        //private IWebElement buttonSave => Driver.FindElement(By.LinkText("Išsaugoti"));

        private IWebElement buttonEdit => Driver.FindElement(By.XPath("//*[@id='yourdetails']/div/div[1]/div[2]/div/div[1]/div[2]/div[7]/a[1]"));
        private IWebElement buttonNe => Driver.FindElement(By.Id("unselected"));
        private IWebElement buttonOfPlace => Driver.FindElement(By.Id("name_1"));
        private IWebElement fieldOfCity => Driver.FindElement(By.Id("city_1"));
        private IWebElement buttonSave => Driver.FindElement(By.XPath("//*[@id='yourdetails']/div/div[1]/div[2]/div/div[1]/div[2]/div[7]/a[2]"));



        public MyAccountPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }
        public MyAccountPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public MyAccountPage ClickButtonToGoToAccount()
        {
            buttonYourDetails.Click();
            return this;
        }

        public MyAccountPage ChangeAddressNew(string NameOfPlace)
        {
            buttonEdit.Click();
            buttonOfPlace.Clear();
            buttonOfPlace.SendKeys(NameOfPlace);
            buttonSave.Click();
            return this;
        }


        public MyAccountPage SelectEditByText(List<string> toDoThings)
        {
            
            Actions action = new Actions(Driver);
            action.KeyDown(Keys.LeftControl);
            foreach (IWebElement option in options.Options)
            {
                if (toDoThings.Contains(option.GetAttribute("text")))
                {
                    action.Click(option);
                    break;
                }
            }
            action.KeyUp(Keys.LeftControl);
            action.Build().Perform();
            action.Click();
            action.Click().Perform();
            return this;
        }














        //public MyAccountPage VerifyAccountNameResult (string name)
        //{ 
        //    Assert.IsTrue(nameInAccount.Text.Contains(name));
        //    return this;
        //}

        //public MyAccountPage ChangeAddress(string nameOfSpot)
        //{
        //    buttonRedaguoti.Click();
        //    button.Click();
        //    pavadinimoField.Click();
        //    pavadinimoInput.Clear();
        //    pavadinimoInput.SendKeys(nameOfSpot);
        //    buttonSave.Click();
        //    return this;
        //}


    }
}
