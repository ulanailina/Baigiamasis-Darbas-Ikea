using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Page
{
    public class SortByFiltersPage : BasePage
    {
        private const string PageAddress = "https://www.ikea.lt/lt/products/svetaine/sofos-ir-foteliai/foteliai";

        private IWebElement dropDownSortBy => Driver.FindElement(By.CssSelector(".d-none #orderFilter"));
        private IWebElement toChooseFromHighestPrice => Driver.FindElement(By.CssSelector(".d-none li:nth-child(4)"));
        private IWebElement resultTextOfSortBy => Driver.FindElement(By.CssSelector("#orderFilter > span"));

        private IWebElement toChooseColor => Driver.FindElement(By.Id("colorFilter"));
        private IWebElement toChooseColorBlack => Driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(3) > ul > li:nth-child(8) > span.icheck.icheck_minimal > div > ins"));
        private IWebElement resultTextOfColor => Driver.FindElement(By.CssSelector("#color-juoda"));

        private IWebElement toChoosePrice => Driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(1) > div"));
        private IWebElement toChoosePriceFrom50upTo100 => Driver.FindElement(By.CssSelector("#filterSelectors > div > div > nav > div > div.filterContainerMultiple > div:nth-child(1) > ul > li:nth-child(3) > span > div > ins"));
        private IWebElement resultTextOfPrice => Driver.FindElement(By.Id("pmin-pmin"));

        public SortByFiltersPage(IWebDriver webdriver) : base(webdriver)
        {
            Driver.Url = PageAddress;
        }

        public SortByFiltersPage NavigateToDefaultPage()
        {
            if (Driver.Url != PageAddress)
                Driver.Url = PageAddress;
            return this;
        }

        // 4 testui
        public SortByFiltersPage SortByHighestPrice()
        {
            dropDownSortBy.Click(); 
            toChooseFromHighestPrice.Click();

            return this;
        }

        public SortByFiltersPage VerifyResultOfSortBy(string actualText)
        {
            Assert.IsTrue(resultTextOfSortBy.Text.Contains(actualText), $"Pasirinktas kitas rūšiavimo būdas.");
            return this;
        }

        // 5 testui
        public SortByFiltersPage SortByColors()
        {
            toChooseColor.Click();
            toChooseColorBlack.Click();
            return this;
        }

        public SortByFiltersPage VerifyResultOfColor(string color)
        {
            Assert.IsTrue(resultTextOfColor.Text.Contains(color), $"Pasirinktas kita rūšis.");
            return this;
        }

        // 6 testui
        public SortByFiltersPage SortByPrice()
        { 
            toChoosePrice.Click();
            toChoosePriceFrom50upTo100.Click();
            toChoosePrice.Click();
            return this;
        }

        public SortByFiltersPage VerifyResultOfPrice(string priceResult)
        {
            Thread.Sleep(1000);
            Assert.IsTrue(resultTextOfPrice.Text.Contains(priceResult), $"Pasirinkta kita kaina.");
            return this;
        }
    }
}
