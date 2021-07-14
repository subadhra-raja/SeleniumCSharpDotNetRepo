using AventStack.ExtentReports;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumProject1.Test_Utilities.Reporting;
using SeleniumProject1.WebPages.TestPages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProject1.Test_Utilities
{
    public class TestBase
    {
        public static IWebDriver driver;
        [SetUp]
        public void SetUp()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();            
        }
        [TearDown]
        public void TearDown()
        {
            IWebDriver openedWindow = null;
            try
            {
                string mainWindow = driver.CurrentWindowHandle;
                foreach (string handle in driver.WindowHandles)
                {
                    openedWindow = driver.SwitchTo().Window(handle);
                    openedWindow.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            finally
            {
                try
                {
                    driver.Quit();                    
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            }
        }
       
        public MessageDemoPage NavigateToDemoSite(String Url)
        {
            driver.Navigate().GoToUrl(Url);
            return new MessageDemoPage(driver);
        }
    }    
}
