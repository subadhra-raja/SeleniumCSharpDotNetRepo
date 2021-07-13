using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.ExampleTestPages
{
    public class TPPage : TestBase
    {
        IWebDriver Driver;
        BasePage page;
        IWebElement webTable;
        int TotalRows = 0;

        /// <summary>
        /// Default Constructor
        /// </summary>
        public TPPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);

        }
        #region
        public By WebTable = By.XPath("//div[@class='table-responsive']");
        public By AllRows = By.XPath("//tbody[@Id='myTable']/tr[@style='display: table-row;']");
        public By NextLink = By.XPath("//a[@class='next_link']");
        public By TableMenu = By.XPath("(//ul[@class='dropdown-menu']/li/a[contains(text(),'Pagination')]//preceding::a[@class='dropdown-toggle']/b)[3]");
        public By TableDataSearchLink = By.XPath("(//a[contains(text(),'Table Data Search')])[1]");

        #endregion

        ///<summary>
        ///Method to count rows in table
        /// </summary>
        public void CountRows()
        {
            webTable = Driver.FindElement(WebTable);
            IList<IWebElement> rows = webTable.FindElements(AllRows);
            int RowCount = rows.Count;            
            TotalRows = RowCount + TotalRows;
        }

        ///<summary>
        ///Method to NaviagteTable
        /// </summary>
        public void NavigateTable()
        {
            for (int i = 0; i <= 2; i++)
            {
                if (i != 2)
                {
                    CountRows();
                    page.Click(NextLink);
                }
                else
                {
                    CountRows();
                }
            }
        }


        ///<summary>
        ///Method to navigate to Table data search page
        /// </summary>
        public TDSPage NavigateToTDS()
        {
            page.Click(TableMenu);
            page.Click(TableDataSearchLink);
            return new TDSPage(driver);
        }

    }
}
