using TestProject1.Pages;
using TestProject1.ReportHelper;
using Xunit;

namespace TestProject1.Test
{
    public class CartTest : BaseTest
    {
        private readonly HomePage homePage;
        private readonly DetailPage detailPage;
        private readonly OrderPage orderPage;



        public CartTest()
        {
            homePage = new HomePage(browserFactory.driver);
            detailPage = new DetailPage(browserFactory.driver);
            orderPage = new OrderPage(browserFactory.driver);
        }
        /// <summary>
        /// Verify Cart Test
        /// </summary>
        [Fact]
        public void VerifyCartTest()

        {
            //Choose product 1st
            ExtentReportsHelper.CreateTestReporst("Test case Cart");
            ExtentReportsHelper.extentTest.Pass("Navigate to Detail page");
            homePage.ValidateOpenPage();
            homePage.AssertGoToHomeByTittle("My Store");
            homePage.NavigateToDetailPage();
            
            ExtentReportsHelper.extentTest.Pass("Navigate to Order page");
            homePage.AssertGoToHomeByTittle("My Store");
            detailPage.NavigateToOrderPage();

            //ExtentReportsHelper.extentTest.Pass("Navigate to Address Order page");
            //orderPage.AssertGoToAddressOderInByTittle("Order - My Store");
            //orderPage.NavigateToAddressOrderPage();




        }
    }
}
