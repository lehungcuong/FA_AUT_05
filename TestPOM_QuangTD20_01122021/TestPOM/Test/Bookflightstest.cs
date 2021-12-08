/*
using Xunit;
using System.Threading;
using TestPOM.Pages;

namespace TestPOM.Test
{
    public class Bookflightstest : Basetest
    {
        private readonly FlightsPage flightspage;
        private readonly Homepage homepage;

        public Bookflightstest()
        {
            homepage = new Homepage(browserFactory.Driver);
            
            flightspage = new FlightsPage(browserFactory.Driver);
        }


        [Fact(DisplayName = "Test Book Flights")]
        public void Testbookflight()
        {
            // verify link in Basetest ( Home page)
            //Assert.True(browserFactory.Driver.Url == "https://phptravels.net/");
            homepage.bntflights();
            // verify link in Basepage when click flights 
            //Assert.True(browserFactory.Driver.Url == "https://phptravels.net/flights");            
            Thread.Sleep(2000);
            //   input "DUB" and "LCG" and click Search and Click frist "book now"
            flightspage.InputSearch();
           
            Thread.Sleep(2000);
            //input infomation of user 
            flightspage.Inputinfomation();
        }


       
            
    }
}
*/