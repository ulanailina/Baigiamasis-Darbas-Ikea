using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas
{
    class ikeaPVZ
    {
        private static IWebDriver _driver;

        [OneTimeSetUp]
        public static void SetUp()
        {
            _driver = new ChromeDriver();
            _driver.Navigate().GoToUrl("https://www.ikea.lt/lt");
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _driver.Manage().Window.Maximize();
            //Console.OutputEncoding = Encoding.UTF8;
            Cookie myCookie = new Cookie("CookieConsent", "{stamp:%27FYAb/AQ4nx13KIzoZQ7TqJgsgPxUMkDNMU0VW9TfHQFZWsj2aepuhg==%27%2Cnecessary:true%2Cpreferences:false%2Cstatistics:false%2Cmarketing:false%2Cver:1%2Cutc:1637348337635%2Cregion:%27lt%27}",
           "www.ikea.lt", "/",
               DateTime.Now.AddDays(5));
            _driver.Manage().Cookies.AddCookie(myCookie);
            _driver.Navigate().Refresh();
        }

        [OneTimeTearDown]
        public static void TearDown()
        {
            //  _driver.Quit();
        }

        [Order(1)]
        [Test]
        public static void SearchInput()
        {
            IWebElement searchField = _driver.FindElement(By.Id("header_searcher_desktop_input"));
            searchField.SendKeys("Čiužiniai");
            IWebElement searchFieldButton = _driver.FindElement(By.CssSelector(".input-group-append"));
            searchFieldButton.Click();
            IWebElement resultText = _driver.FindElement(By.CssSelector("#contentWrapper > div.container-fluid > div > div > h2"));
            Assert.IsTrue(resultText.Text.Contains("Foteliai"), $"Rezultate nėra nurodytas paieškos žodis.");
        }

        [Order(2)]
        [Test]
        public static void SortByRekomenduojamas()
        {
            IWebElement dropDown = _driver.FindElement(By.CssSelector(".d-none #orderFilter"));
            dropDown.Click();
            IWebElement toChooseRekomenduojamas = _driver.FindElement(By.CssSelector(".d-none li:nth-child(1)"));
            toChooseRekomenduojamas.Click();
        }
        //By.CssSelector("#orderFilter > span")
        [Order(3)]
        [Test]
        public static void SortByColorAndPrice()
        {
            IWebElement toChooseColor = _driver.FindElement(By.Id("colorFilter"));
            toChooseColor.Click();
            IWebElement toChooseColorBlack = _driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(3) > ul > li:nth-child(9) > span.icheck.icheck_minimal > div > ins"));
            toChooseColorBlack.Click();
            IWebElement resultTextOfColor = _driver.FindElement(By.CssSelector("#color-juoda"));
            Thread.Sleep(2000);
            Assert.IsTrue(resultTextOfColor.Text.Contains("juoda"), $"Rezultate nera zodzio: juoda");

            IWebElement toChoosePrice = _driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(1) > div"));
            toChoosePrice.Click();
            IWebElement toChoosePriceFrom50upTo100 = _driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(1) > ul > li:nth-child(3) > span > div > ins"));
            toChoosePriceFrom50upTo100.Click();
            IWebElement clickOnSide = _driver.FindElement(By.Id("contentWrapper"));
            clickOnSide.Click();
        }

        [Test]
        public static void TestAddToWishlist()
        {
            IWebElement selectRoom = _driver.FindElement(By.CssSelector("#navbarDropdownRooms > span"));
            selectRoom.Click();
            IWebElement selectVonia = _driver.FindElement(By.LinkText("Vonia"));
            selectVonia.Click();
            IWebElement selectItemField = _driver.FindElement(By.CssSelector(".col-6:nth-child(4) img"));
            selectItemField.Click();
            IWebElement dropdown = _driver.FindElement(By.CssSelector(".d-none #orderFilter"));
            dropdown.Click();
            IWebElement dropdownLowestPrice = _driver.FindElement(By.CssSelector(".d-none li:nth-child(3) > .name"));
            dropdownLowestPrice.Click();
            // IWebElement selectingItem = _driver.FindElement(By.CssSelector(".col-6:nth-child(1) .display-7"));
            IWebElement selectGreitaPerziura = _driver.FindElement(By.CssSelector("#contentWrapper > div > div > div.products_list.w-100.d-flex.flex-wrap > div:nth-child(3) > div > div.card-footer > button"));
            selectGreitaPerziura.Click();
        }

            [Test]

            public static void TestCart()
            {
                IWebElement enterCart = _driver.FindElement(By.CssSelector(".d-none > #iconCart-lg"));
            enterCart.Click();
            }

            











           
            // stai cia man stringa ir meta klaida: 
            //Message:
            //OpenQA.Selenium.StaleElementReferenceException : stale element reference: element is not attached to the page document
            //(Session info: chrome = 96.0.4664.45)

            //  Stack Trace: 
            //WebDriver.UnpackAndThrowOnError(Response errorResponse)
            //WebDriver.Execute(String driverCommandToExecute, Dictionary`2 parameters)
            //WebDriver.InternalExecute(String driverCommandToExecute, Dictionary`2 parameters)
            //WebElement.Execute(String commandToExecute, Dictionary`2 parameters)
            //WebElement.Click()
            //ikeaPVZ.TestAddToWishlist() line 94

            //selectingItem.Click();
            //IWebElement addToWishlist = _driver.FindElement(By.CssSelector(".icon-addfav"));
            //addToWishlist.Click();
        
    }
}
