using System;
using System.Collections.Generic;
using System.Threading;
using QuangTD20_Final.Pages;
using Xunit;

namespace QuangTD20_Final.Test
{
    public class TestLoginPage : Basetest
    {
        readonly Loginpage login;
        readonly HomePage homepage;

        public TestLoginPage()
        {
            homepage = new HomePage(browserFactory.Driver);
            login = new Loginpage(browserFactory.Driver);
        }

        [Fact(DisplayName = "Test Login pase")]
        public void Loginpage()
        {
            homepage.clickLoginpage();
            Thread.Sleep(1000);
            login.Login();
        }
        /*
        #region MemberData
        /// read information in MemberData
        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] {"quangtrangk111@gmail.com", "0123456789"};

        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void AllNumbers_AreOdd_WithMemberData(string email, string password)
        {
          
            homepage.clickLoginpage();
            Thread.Sleep(1000);
            login.Loginbydata(email,password);     
        }
        #endregion
        */
    }
}
