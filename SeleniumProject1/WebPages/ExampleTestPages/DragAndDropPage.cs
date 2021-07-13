using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class DragAndDropPage :TestBase
    {
        IWebDriver Driver;
        BasePage page;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public DragAndDropPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);
        }
        #region
        public By SourceElement = By.XPath("//span[@draggable='true']");
        public By TargetElement = By.Id("mydropzone");
        public By DroppedList = By.XPath("//div[@id='droppedlist']/span");

        #endregion

        ///<summary>
        ///Method to Drag and Drop elements
        /// </summary>
        public DragAndDropPage DropAllElements()
        {
            IReadOnlyCollection<IWebElement> SourceElements = Driver.FindElements(SourceElement);
            IWebElement TargetElementName = Driver.FindElement(TargetElement);
            foreach(IWebElement ele in SourceElements)
            {
                page.DragDropElement(ele, TargetElementName);
            }
            return this;           
        }
        ///<summary>
        ///Method to verify elements are dropped
        /// </summary>
        public bool VerifyAllElementsDropped()
        {
            IReadOnlyCollection<IWebElement> DroppedLists = Driver.FindElements(DroppedList);
            int count = DroppedLists.Count;
            if (count == 4)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
    }
}
