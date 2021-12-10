using Auto.Page;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Auto.Test
{
    public class ProductTest : BaseTest
    {
        HomePage homePage;
        ProductPage productPage;
        SumaryPage sumaryPage;
        AddressPage addressPage;
        ShippingPage shippingPage;
        PaymentPage paymentPage;
        LoginPage loginPage;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProductTest()
        {
            homePage = new HomePage(browsers.driver);
            productPage = new ProductPage(browsers.driver);
            sumaryPage = new SumaryPage(browsers.driver);
            addressPage = new AddressPage(browsers.driver);
            shippingPage = new ShippingPage(browsers.driver);
            paymentPage = new PaymentPage(browsers.driver);
            loginPage = new LoginPage(browsers.driver);
        }
        /// <summary>
        /// Test case buy 1 product with infomation correct
        /// </summary>
        [Fact(DisplayName ="Buy 1 product with infomatin correct")]
        public void Buy1Product()
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits("ntnhien19091999@gmail.com", "12345");
            loginPage.ClickLogo();
            bool result2 = homePage.VerifyGotoHomePage();
            result2.Should().BeTrue();
            homePage.ClickBtnBestSeller();        
            productPage.ClickAddToCard();
            bool result3 = sumaryPage.VerifyGotoSummaryPage();
            result3.Should().BeTrue();
            sumaryPage.ClickButtonProcessToCheckOut();
            bool result4 = addressPage.VerifyAddressPage();
            result4.Should().BeTrue();
            addressPage.ClickBtnProccessToCheckout();
            bool result5 = shippingPage.VerifyShippngPage();
            result5.Should().BeTrue();
            shippingPage.ClickButtonProcessToCheckout();
            bool result6 = paymentPage.VerifyPaymentPage();
            result6.Should().BeTrue();
            paymentPage.ClickConFirmMyOrder();
            
        }
        /// <summary>
        /// Test case buy 3 product 
        /// </summary>
        [Fact(DisplayName = "Buy 3 difference products  ")]
        public void Buy3Product()
        {
            homePage.ClickBtnCreateAnAccount();
            bool result = loginPage.VerifyGoToREGISTEREDPage();
            result.Should().BeTrue();
            loginPage.LoginWithAccountExits("ntnhien19091999@gmail.com", "12345");
            loginPage.ClickLogo();
            bool result2 = homePage.VerifyGotoHomePage();
            result2.Should().BeTrue();
            homePage.Click3Product();
            sumaryPage.ClickButtonProcessToCheckOut();
            bool result4 = addressPage.VerifyAddressPage();
            sumaryPage.ClickButtonProcessToCheckOut();
            result4.Should().BeTrue();
            addressPage.ClickBtnProccessToCheckout();
            bool result5 = shippingPage.VerifyShippngPage();
            result5.Should().BeTrue();
            shippingPage.ClickButtonProcessToCheckout();
            bool result6 = paymentPage.VerifyPaymentPage();
            result6.Should().BeTrue();
            paymentPage.ClickConFirmMyOrder();
        }
    }
}
