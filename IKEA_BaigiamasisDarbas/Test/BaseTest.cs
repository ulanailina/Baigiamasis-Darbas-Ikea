using IKEA_BaigiamasisDarbas.Drivers;
using IKEA_BaigiamasisDarbas.Page;
using IKEA_BaigiamasisDarbas.Tools;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Test
{
    public class BaseTest
    {                                                                                
        public static IWebDriver driver;
        public static HomePage _homePage;  
        public static LoginAndRegisterPage _loginAndRegisterPage;
        public static SortByFiltersPage _sortByFiltersPage;
        public static ItemFromRoomPage _itemFromRoomPage;      

        [OneTimeSetUp]
        public static void SetUp()
        {
            driver = CustomDriver.GetChromeDriver();
            _homePage = new HomePage(driver);
            _loginAndRegisterPage = new LoginAndRegisterPage(driver);
            _sortByFiltersPage = new SortByFiltersPage(driver);
            _itemFromRoomPage = new ItemFromRoomPage(driver);

            //Console.OutputEncoding = Encoding.UTF8;
            Cookie myCookie = new Cookie("CookieConsent", "{stamp:%27FYAb/AQ4nx13KIzoZQ7TqJgsgPxUMkDNMU0VW9TfHQFZWsj2aepuhg==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1637348337635%2Cregion:%27lt%27}",
           "www.ikea.lt", "/", DateTime.Now.AddDays(5));
            driver.Manage().Cookies.AddCookie(myCookie);
            driver.Navigate().Refresh();
        }

        [TearDown]

        public static void TakeScreenshot()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
                MyScreenshot.MakeScreenshot(driver);
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
           // driver.Quit();
        }
    }
}
