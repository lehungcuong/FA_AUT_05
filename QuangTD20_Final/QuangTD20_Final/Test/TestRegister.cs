using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using QuangTD20_Final;
using QuangTD20_Final.Pages;
using Xunit;

namespace QuangTD20_Final.Test
{
    public class TestRegister : Basetest
    {
        readonly RegisterPage register;
        readonly HomePage homepage;

        public TestRegister()
        {
            register = new RegisterPage(browserFactory.Driver);
            homepage = new HomePage(browserFactory.Driver);
        }

        [Fact(DisplayName = "Test Book Tours")]
        public void Registeraccount()
        {
            homepage.clickLoginpage();
            Thread.Sleep(1000);
            register.Register();
            Thread.Sleep(1000);
            register.Inputinfomation();

        }
    }
}
