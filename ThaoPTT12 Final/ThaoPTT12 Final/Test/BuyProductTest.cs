using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThaoPTT12_Final.Pages;
using WebDriver;
using Xunit;

namespace ThaoPTT12_Final.Test 
{
    public class BuyProductTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly WomanPage womanPage;
        public BuyProductTest()
        {
            homePage = new HomePage(browserFactory.Driver);
            womanPage = new WomanPage(browserFactory.Driver);
        }

        [Fact(DisplayName = "Buy Product Test")]
        public void BuyProductTestcase()
        {
            homePage.ClickOnButtonWomen();
            Thread.Sleep(5000);

            womanPage.ClickChooseProduct();
            Thread.Sleep(3000);

            womanPage.AddToCart();
            Thread.Sleep(3000);

            womanPage.ProceedToCheckout1();
            Thread.Sleep(3000);

            womanPage.ProceedToCheckout2();
            Thread.Sleep(3000);

            womanPage.ProceedToCheckout3();
            Thread.Sleep(3000);

            womanPage.ProceedToCheckout4();
            Thread.Sleep(3000);

            womanPage.TickPayByCheck();
            Thread.Sleep(3000);

            womanPage.ProceedToCheckout5();
            Thread.Sleep(3000);

        }
    }
}
