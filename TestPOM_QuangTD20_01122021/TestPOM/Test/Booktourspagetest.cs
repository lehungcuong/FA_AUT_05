using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using TestPOM.constants;
using TestPOM.Pages;
using RestSharp;
using Xunit;

namespace TestPOM.Test
{
    public class Booktourspagetest : Basetest
    {
        readonly Tourspage tourspage;
        readonly Homepage homepage;


        public Booktourspagetest()
        {
            homepage = new Homepage(browserFactory.Driver);
            tourspage = new Tourspage(browserFactory.Driver);


        }



        /*

        [Fact(DisplayName = "Test Book Tours")]
        public void TestBookTours()
        {

            // input page tours
            /*  homepage.bnttours();
              Thread.Sleep(2000);
              //input infomation of user 
              tourspage.Choosetours();*/
      //}
        
        /// read information in LineData
        /*
        #region LineData
         [Theory(DisplayName = "Booking Tour Test InlineData")]
         [InlineData("Quang", "Tran", "quangtran@gmail.com", "123456789", "83/2C", "Quang", "Tran", "Quang", "Tran")]

         public void ReadinfomationInlineData(string Firstname, string Lastname, string Email, string Phone, string Address,
           string FirstName1, string ClassName1, string FirstName2, string ClassName2)
         {
           // Assert.True(browserFactory.Driver.Url == "https://phptravels.net/");
            string urlhomepage;
            string title;
            
            urlhomepage = browserFactory.Driver.Url;
          tourspage.fluentAssert(urlhomepage, "https://phptravels.net/", "Url not True");
            
            homepage.bnttours();
            //Assert.True(browserFactory.Title == "Search Tours - PHPTRAVELS");
            title = browserFactory.Driver.Title;
            tourspage.fluentAssert(title, "Search Tours - PHPTRAVELS", "Title page not True");

            Thread.Sleep(2000);
             //input infomation of user 
             tourspage.Bookingtoursbydata(Firstname, Lastname, Email, Phone, Address, FirstName1, ClassName1, FirstName2, ClassName2);
         }
       #endregion

      
        /*
        /// read information in ClassData
        #region ClassData
        [Theory(DisplayName = "Booking Tour Test ClassData")]
        [ClassData(typeof(TestDataGenerator))]
        public void ReadinfomationInCLassData(string Firstname, string Lastname, string Email, string Phone, string Address,
           string FirstName1, string ClassName1, string FirstName2, string ClassName2)
        {
            string urlhomepage;
            string title;

            urlhomepage = browserFactory.Driver.Url;
            tourspage.fluentAssert(urlhomepage, "https://phptravels.net/", "Url not True");

            homepage.bnttours();
            //Assert.True(browserFactory.Title == "Search Tours - PHPTRAVELS");
            title = browserFactory.Driver.Title;
            tourspage.fluentAssert(title, "Search Tours - PHPTRAVELS", "Title page not True");

            Thread.Sleep(2000);
            //input infomation of user 
            tourspage.Bookingtoursbydata(Firstname, Lastname, Email, Phone, Address, FirstName1, ClassName1, FirstName2, ClassName2);
        }
        
        public class TestDataGenerator : IEnumerable<object[]>
        {
            private readonly List<object[]> _data = new List<object[]>
            {
                new object[] { "Quang", "Tran", "quangtran@gmail.com", "123456789", "83/2C", "Quang", "Tran", "Quang", "Tran"}, };

            public IEnumerator<object[]> GetEnumerator() => _data.GetEnumerator();

            IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        }
        #endregion


        #region MemberData
        /// read information in MemberData
        public static IEnumerable<object[]> GetNumbers()
        {
            yield return new object[] { "Quang", "Tran", "quangtran@gmail.com", "123456789", "83/2C", "Quang", "Tran", "Quang", "Tran" };
           
        }

        [Theory]
        [MemberData(nameof(GetNumbers))]
        public void AllNumbers_AreOdd_WithMemberData(string Firstname, string Lastname, string Email, string Phone, string Address,
           string FirstName1, string ClassName1, string FirstName2, string ClassName2)
        {
            string urlhomepage;
            string title;

            urlhomepage = browserFactory.Driver.Url;
            tourspage.fluentAssert(urlhomepage, "https://phptravels.net/", "Url not True");

            homepage.bnttours();
            //Assert.True(browserFactory.Title == "Search Tours - PHPTRAVELS");
            title = browserFactory.Driver.Title;
            tourspage.fluentAssert(title, "Search Tours - PHPTRAVELS", "Title page not True");

            Thread.Sleep(2000);
            //input infomation of user 
            tourspage.Bookingtoursbydata(Firstname, Lastname, Email, Phone, Address, FirstName1, ClassName1, FirstName2, ClassName2);
        }
        #endregion


        // read information in JSON
        #region JsonReader
        [Theory(DisplayName = "JsonReader")]
        [JsonReader( "DataInformationUser")]
        public void ReadDataWithJson(string Firstname, string Lastname, string Email, string Phone, string Address,
          string FirstName1, string ClassName1, string FirstName2, string ClassName2)
        {
            string urlhomepage;
            string title;

            urlhomepage = browserFactory.Driver.Url;
            tourspage.fluentAssert(urlhomepage, "https://phptravels.net/", "Url not True");

            homepage.bnttours();
            //Assert.True(browserFactory.Title == "Search Tours - PHPTRAVELS");
            title = browserFactory.Driver.Title;
            tourspage.fluentAssert(title, "Search Tours - PHPTRAVELS", "Title page not True");

            Thread.Sleep(2000);
            //input infomation of user 
            tourspage.Bookingtoursbydata(Firstname, Lastname, Email, Phone, Address, FirstName1, ClassName1, FirstName2, ClassName2);
        }
        #endregion
        */
    }
}