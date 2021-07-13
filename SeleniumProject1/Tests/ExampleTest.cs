using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.ExampleTestPages;
using SeleniumProject1.WebPages.TestPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.Tests
{
    [TestFixture]
    public class ExampleTest : TestBase
    {

        HomePage HomePage;
        DemoHomePage DemoHomePage;
        DragAndDropPage DragAndDropPage;
        [Test]
        [Category("Smoke")]
        [Author("Subadhra Raja")]
        public void TestExamples()
        {
            try
            {
                GivenTheUserNavigatesToDragAndDropInDemoSite();
                WhenTheUserDropsAllElement();
                ThenDroppedElemtsAreDisplayedInTheList();

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
                throw e;
            }
        }

        public void GivenTheUserNavigatesToDragAndDropInDemoSite()
        {
            HomePage = NavigateToSite("https://www.seleniumeasy.com/");
        }
        public void WhenTheUserDropsAllElement()
        {
            DemoHomePage =HomePage.ClickDemoButton();
            DragAndDropPage=DemoHomePage.NavigateToDragAndDropPage();
            DragAndDropPage.DropAllElements();
        }
        public void ThenDroppedElemtsAreDisplayedInTheList()
        {
            bool ElementsDropped = DragAndDropPage.VerifyAllElementsDropped();
            Assert.IsTrue(ElementsDropped, "Elements are not dropped properly");
        }











    }
}
