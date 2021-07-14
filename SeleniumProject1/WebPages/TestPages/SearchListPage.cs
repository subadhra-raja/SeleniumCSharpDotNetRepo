using OpenQA.Selenium;
using SeleniumProject1.Test_Utilities;
using SeleniumProject1.WebPages.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.WebPages.TestPages
{
    public class SearchListPage :TestBase
    {
        IWebDriver Driver;
        BasePage page;
        /// <summary>
        /// Default Constructor
        /// </summary>
        public SearchListPage(IWebDriver driver)
        {
            this.Driver = driver;
            page = new BasePage(Driver);
        }
        #region
        public By GoogleLogo = By.Id("logo");
        #endregion

        ///<summary>
        ///Method to find Google Logo is available in the page 
        /// </summary>
        ///<param name="element"></param>
        ///<param name="text"></param>
        public bool CheckIfLogoAvailable()
        {
            return page.IsElementDisplayed(GoogleLogo);
        }

    }
}
