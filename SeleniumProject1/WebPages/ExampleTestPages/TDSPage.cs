using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class TDSPage : TestBase
    {
        IWebDriver Driver;
        BasePage page;
        IWebElement webTable;
        

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TDSPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);

        }
        #region
        public By WebTable = By.XPath("//table[@id='task-table']");
        public By AllRows = By.XPath("//tbody/tr");
        public By SearchBox = By.XPath("//input[@id='task-table-filter']");
        #endregion

        ///<summary>
        ///Method to count rows in table
        /// </summary>
        public bool SearchTable(string SearchText)
        {
            IWebElement Table = Driver.FindElement(WebTable);
            Driver.FindElement(SearchBox).SendKeys(SearchText);
            IList<IWebElement> rows = Table.FindElements(AllRows);
            IList<IWebElement> rowTD;
            foreach(IWebElement row in rows)
            {
                rowTD = row.FindElements(By.TagName("td"));
                if (rowTD[1].Text.Equals(SearchText))
                {
                    return true;
                }                
            }
            return false;
        }        
    }
}
