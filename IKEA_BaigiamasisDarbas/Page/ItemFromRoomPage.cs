using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Page
{
    public class ItemFromRoomPage : BasePage
    {
        private const string PageAddress = "https://www.ikea.lt/lt/rooms/vonia";
        private IWebElement resultVonia => Driver.FindElement(By.ClassName(".display-5.text-center.mb-5"));

        public ItemFromRoomPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public ItemFromRoomPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        public ItemFromRoomPage VerifySelectedVonia(string roomName)
        {
            Assert.IsTrue(resultVonia.Text.Equals(roomName));
            return this;
        }  
    }
}
