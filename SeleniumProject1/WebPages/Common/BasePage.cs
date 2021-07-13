using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using SeleniumProject1.Test_Utilities;

namespace SeleniumProject1.WebPages.Common
{
    public class BasePage :TestBase
    {
        public IWebDriver Driver;
        
        #region webelements
        #endregion
        public BasePage(IWebDriver driver)
        {
            this.Driver = driver;
        }          
        public void GoBack()
        {
            Driver.Navigate().Back();
        }
        public void GoForward()
        {
            Driver.Navigate().Forward();
        }
        public void Refresh()
        {
            Driver.Navigate().Refresh();
        }
        public void TypeText(By byElement, String text)
        {
            IWebElement element = Driver.FindElement(byElement);
            TypeText(element, text);
        }

        public void TypeText(IWebElement element,String text)
        {
            element.SendKeys(text);
        }

        public void Click(IWebElement element)
        {
            element.Click();
        }
        public void Click(By byElement)
        {
            IWebElement element = Driver.FindElement(byElement);
            Click(element);
        }
        public bool IsElementDisplayed(By byElement)
        {
            IWebElement element = Driver.FindElement(byElement);
            return IsElementDisplayed(element);
        }
        public bool IsElementDisplayed(IWebElement element)
        {
            return element.Displayed;
        }

        public void DragDropElement(IWebElement SourceElement, IWebElement TargetElement)
        {
            // Using Action class for drag and drop.
             Actions act = new Actions(Driver);
            //Dragged and dropped.		
            //act.DragAndDrop(SourceElement, TargetElement).Build().Perform();
            act.ClickAndHold(SourceElement).MoveToElement(TargetElement).Release().Build().Perform();
        }
    }
}


