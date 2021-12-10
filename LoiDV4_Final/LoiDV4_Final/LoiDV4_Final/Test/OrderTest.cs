using FluentAssertions;
using LoiDV4_Final.Common;
using LoiDV4_Final.Page;
using Xunit;

namespace LoiDV4_Final.Test
{
    public class OrderTest : BaseTest
    {
        private readonly HomePage homePage;

        public OrderTest()
        {
            homePage = new HomePage(browser);
          
         
        }

        /// <summary>
        /// Verify user can purchased 1 product with correct product information
        /// </summary>
        [Fact(DisplayName = "Verify user can purchased 1 product with correct product information")]
        public void VerifyOrder1Product()
        {
            homePage.ClickTabWomen();
            string orderConfirmationTitle = WebKeywords.GetTitle();
            orderConfirmationTitle.Should().Be("Order confirmation - My Store");

        }


        /// <summary>
        /// Verify user can purchased 3 difference products with correct products information
        /// </summary>
        [Theory(DisplayName = "Verify user can purchased 3 difference products with correct products information")]
        [InlineData("//img[@title='Faded Short Sleeve T-shirts']")]
        [InlineData("//img[@title='Blouse']")]
        [InlineData("(//img[@title='Printed Dress'])[1]")]
        public void VerifyOrder3Product(string pathProduct)
        {
            homePage.ClickTabWomenWithDataDriven(pathProduct);
            string orderConfirmationTitle = WebKeywords.GetTitle();
            orderConfirmationTitle.Should().Be("Order confirmation - My Store");

        }
    }
}
