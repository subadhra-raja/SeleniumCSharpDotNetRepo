using NUnit.Framework;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.ExampleTestPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.Tests 
{
    [TestFixture]
    public class ExampleTest1 : TestBase
    {
        HomePage HomePage;
        DemoHomePage DemoHomePage;
        BSListPage BSListPage;
        JQLBPage JQLBPage;

        
        [Test]
        public void BSList()
        {
            try
            {
                HomePage = NavigateToSite("https://www.seleniumeasy.com/");
                DemoHomePage = HomePage.ClickDemoButton();
                DemoHomePage.ExitPopup();
                BSListPage = DemoHomePage.NavigateToBSL();
                BSListPage.MoveItemLftToRight("bootstrap-duallist");
                bool ItemMoved = BSListPage.VerifyElementmoved("bootstrap-duallist");
                Assert.IsTrue(ItemMoved, "The given Item is not moved from Right to left");
                JQLBPage = BSListPage.NavigateToJQLB();
                bool optionAdded = JQLBPage.PickAndAdd("Manuela");
                Assert.IsTrue(optionAdded, "Given Option not added to List");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }

    }
}