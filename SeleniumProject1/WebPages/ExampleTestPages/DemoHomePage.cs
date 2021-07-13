using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class DemoHomePage : TestBase
    {
        BasePage page;
        IWebDriver Driver;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DemoHomePage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);
        }
        #region
        public By OthersDDM = By.XPath("(//div[@id='navbar-brand-centered']//a[@class='dropdown-toggle'])[7]");
        public By DragDropLink = By.XPath("//ul[@class='dropdown-menu']//a[contains(text(),'Drag and Drop')]");
        public By ListBoxDDM = By.XPath("//a[contains(text(),'List Box')]/b");
        public By BSListBox = By.XPath("(//a[contains(text(),'List Box')])[1]//following-sibling::ul//li/a[contains(text(),'Bootstrap List Box')]");
        public By AdvExitBtn = By.XPath("//div/a[contains(text(),'No, thanks!')]");
        public By AdvPopup = By.XPath("//div[@class='at-cv-goal-container']");
        public By TableMenu = By.XPath("(//ul[@class='dropdown-menu']/li/a[contains(text(),'Pagination')]//preceding::a[@class='dropdown-toggle']/b)[3]");
        public By TPagenationLink = By.XPath("//ul[@class='dropdown-menu']/li/a[contains(text(),'Pagination')]");

        #endregion


        ///<summary>
        ///Method to exit out the Add popup
        /// </summary>
        public void ExitPopup()
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(20));
            IWebElement containerModel = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(AdvPopup));
            IWebElement modelContent = containerModel.FindElement(AdvExitBtn);
            Thread.Sleep(3000);
            modelContent.Click();
             
        }

        ///<summary>
        ///Method to navigate to Drag and Drop example page
        /// </summary>
        public DragAndDropPage NavigateToDragAndDropPage()
        {
            page.Click(OthersDDM);
            page.Click(DragDropLink);
            return new DragAndDropPage(driver);
        }
        ///<summary>
        ///Method to navigate to BS example page
        /// </summary>
        public BSListPage NavigateToBSL()
        {
            page.Click(ListBoxDDM);
            page.Click(BSListBox);
            return new BSListPage(driver);
        }

        ///<summary>
        ///Method to navigate to Table example page
        /// </summary>
        public TPPage NavigateToTP()
        {
            page.Click(TableMenu);
            page.Click(TPagenationLink);
            return new TPPage(driver);
        }

    }
}
