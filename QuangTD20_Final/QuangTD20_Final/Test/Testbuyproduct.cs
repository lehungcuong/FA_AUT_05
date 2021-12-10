using System;
using System.Collections.Generic;
using System.Threading;
using QuangTD20_Final.Pages;
using Xunit;


namespace QuangTD20_Final.Test
{
    public class Testbuyproduct : Basetest
    {
        readonly Buyproduct buyproduct;
        readonly HomePage homepage;
        readonly TestLoginPage testloginpage;
        readonly Loginpage login;

        public Testbuyproduct()
        {
            buyproduct = new Buyproduct(browserFactory.Driver);
            homepage = new HomePage(browserFactory.Driver);
            login = new Loginpage(browserFactory.Driver);
        }


        [Fact(DisplayName = "Test buy 1 product")]
        public void Buy1produc()
        {
            homepage.clickLoginpage();
            Thread.Sleep(1000);
            login.Login();
            homepage.clickLoginpagetobuy();
            Thread.Sleep(1000);
                       
            buyproduct.Buy1product();
        }


        [Fact(DisplayName = "Test buy 3 product")]
        public void Buy3produc()
        {
            homepage.clickLoginpage();
            Thread.Sleep(1000);
            login.Login();
            homepage.clickLoginpagetobuy();
            Thread.Sleep(1000);         
            Thread.Sleep(1000);
            buyproduct.Buy3product();
        }
    }
}
