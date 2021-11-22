using IKEA_BaigiamasisDarbas.Page;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IKEA_BaigiamasisDarbas.Test
{
    public class IkeaTest : BaseTest
    {
        [Order(1)]
        [TestCase("5894857", "Neteisingas el.pašto adresas", TestName = "Įvedami skaičiai")]
        [TestCase("*/+-*@gmail.com", "Neteisingas el. pašto adresas", TestName = "Įvedami simboliai")]

        public void TestRegisterInput (string email, string expectedResult)
        {
            _homePage.NavigateToDefaultPage()
                .ClickLoginButton();
            _loginAndRegisterPage.NavigateToDefaultPage()
                .RegisterEmailInput(email)
                .VerifyRegisterInputResult(expectedResult);   
        }

        [Order(2)]
        [Test]
        public void TestToSelectRoomOfItem()
        {
            _homePage.NavigateToDefaultPage()
                .SelectRoomForItem();
            _itemFromRoomPage.VerifySelectedVonia("Vonia");
        }

        [Order(3)]
        [Test]
        public void TestSearchField()
        {
            _homePage.NavigateToDefaultPage()
                .SearchFieldInput("Foteliai")
                .VerifyResult("Foteliai");
        }

        [Order(4)]
        [Test]
        public void TestSortByHighestPrice()
        {
            _sortByFiltersPage.NavigateToDefaultPage()
                .SortByHighestPrice()
                .VerifyResultOfSortBy("Kainą nuo didžiausios");
        }

        [Order(5)]
        [Test]
        public void TestColor()
        {
            _sortByFiltersPage.NavigateToDefaultPage()
                .SortByColors()
                .VerifyResultOfColor("juoda");  
        }

        [Order (6)]
        [Test]
        public void TestPrice()
        {
            _sortByFiltersPage.NavigateToDefaultPage()
                .SortByPrice()
                .VerifyResultOfPrice("Nuo 50 € iki 100 €");  
        }

        [Order(7)]
        [Test]
        public void TestLogin()
        {
            _loginAndRegisterPage.NavigateToDefaultPage()
                .EnterLoginData("ulanaitee.lina@gmail.com", "Ikea1")
                .ClickButtonToConfirmLogin();
                //.ClickWishListButton();
        }
    }
}
