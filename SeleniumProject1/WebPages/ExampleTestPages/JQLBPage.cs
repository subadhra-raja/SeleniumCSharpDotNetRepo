using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class JQLBPage : TestBase
    {
        IWebDriver Driver;
        BasePage page;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public JQLBPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);

        }
        #region
        public By NameList = By.XPath("//select[contains(@class, 'pickListSelect pickData')]");
        public By OptionList = By.XPath("//select[contains(@class, 'pickListSelect pickData')]/option");
        public By AddBtn = By.XPath("(//div/button[contains(text(),'Add')])[1]");
        public By AddedList = By.XPath("//select[contains(@class, 'pickListResult')]");
        #endregion

        ///<summary>
        ///Method to Pick a value from List and add to other List
        /// </summary>
        public bool PickAndAdd(string OptionToSelect)
        {
            Actions builder = new Actions(Driver);
            IWebElement NamesList = Driver.FindElement(NameList);
            SelectElement oSelect = new SelectElement(NamesList);
            oSelect.SelectByText(OptionToSelect);
            page.Click(AddBtn);
            IWebElement AddedLists = Driver.FindElement(AddedList);
            SelectElement aSelectd = new SelectElement(AddedLists);
            IList<IWebElement> SelectedOptions = aSelectd.Options;
            foreach (IWebElement option in SelectedOptions)
            {
                if (OptionToSelect.Equals(option.Text))
                {
                    return true;
                }
            }
            return false;
        }
        
    }
}
