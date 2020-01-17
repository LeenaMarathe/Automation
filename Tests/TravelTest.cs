using System;
using Automation.TestPHPTravel.Factories;
using Automation.TestPHPTravel.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Automation.TestPHPTravel
{
    [TestClass]
    public class TravelTest
    {
        HomePage homepage;
        AdminPage adminpage;
        LoginPage loginpage;

        [TestInitialize]
        public void TestInitialize()
        {
            DriverFactory.OpenBrowser();
            homepage = new HomePage();
            adminpage = new AdminPage();
            loginpage = new LoginPage();

        }
        [TestCleanup]
        public void TestCleanup()
        {
            DriverFactory.CloseBrowser();
        }
        [TestMethod]
        public void SearchHotels()
        {
            homepage.Navigate();
            ResultsPage result = homepage.Search("Michigan City", "29/01/2020","30/01/2020");
            Assert.IsTrue(result.VerifyResultTitle("Michigan-City"));
            result.PrintResults();            
        }

        [TestMethod]
        public void UpdateReviews()
        {
            loginpage.Navigate();
            adminpage = loginpage.Login("admin@phptravels.com", "demoadmin");
            adminpage.VerifyDashboardTitle("DASHBOARD");
            adminpage.ClickToursMenu();
            adminpage.ClickReviewMenu();
            adminpage.ClickEdit();
            adminpage.ClickOverallTab();
            adminpage.StoreRating();
            adminpage.SelectRating("Review Clean*", "4");
            adminpage.SelectRating("Review Comfort*", "5");
            adminpage.SelectRating("Review Location*", "7");
            adminpage.SelectRating("Review Facilities*", "5");
            adminpage.SelectRating("Review Staff*", "2");
            Assert.IsTrue(adminpage.CompareRating());
            adminpage.SaveRating();
        }
    }
}
