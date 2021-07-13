using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class BSListPage : TestBase
    {
        IWebDriver Driver;
        BasePage page;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public BSListPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);

        }
        #region
        public By SourceElement = By.XPath("//span[@draggable='true']");
        public By TargetElement = By.Id("mydropzone");
        public By DroppedList = By.XPath("//div[@id='droppedlist']/span");
        public By LeftSB = By.XPath("//input[@name='SearchDualList']");
        public By SearchedOption = By.XPath("//ul[@class='list-group']//li[text()='bootstrap-duallist ']");
        public By LeftSelectALL = By.XPath("//a[@title='select all']/i");
        public By MoveRightBtn = By.XPath("//button[contains(@class,'move-right')]");
        public By RightListGrpItems = By.XPath("//ul[@class='list-group']//li[@class='list-group-item active']");
        public By ListBoxDDM = By.XPath("//a[contains(text(),'List Box')]/b");
        public By JQListBox = By.XPath("(//a[contains(text(),'List Box')])[1]//following-sibling::ul//li/a[contains(text(),'JQuery List Box')]");

        #endregion

        ///<summary>
        ///Method to move element from left list to right list
        /// </summary>
        public BSListPage MoveItemLftToRight(string ElementOption)
        {
            Driver.FindElement(LeftSB).SendKeys(ElementOption);
            page.Click(SearchedOption);
            page.Click(LeftSelectALL);
            page.Click(MoveRightBtn);
            return this;
        }
        ///<summary>
        ///Method to verify elements are moved
        /// </summary>
        public bool VerifyElementmoved(string ElementOption)
        {
            IReadOnlyCollection<IWebElement> ListItems = Driver.FindElements(RightListGrpItems);
            foreach (IWebElement Item in ListItems)
            {
                string IText = Item.Text;
                if (ElementOption.Equals(IText))
                {
                    return true;
                }
            }
            return false;
        }

        ///<summary>
        ///Method to navigate to JQuery LB
        /// </summary>
        public JQLBPage NavigateToJQLB()
        {
            page.Click(ListBoxDDM);
            page.Click(JQListBox);
            return new JQLBPage(Driver);
        }
    }

}
