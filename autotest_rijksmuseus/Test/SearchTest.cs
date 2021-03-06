﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using autotest_rm.Pages;

namespace autotest_rm.Test
{
    class SearchTest
    {
        IWebDriver webDriver;

        [SetUp]
        public void IntBrowser()
        {
            webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en");
            webDriver.FindElement(By.XPath("//*[text()='Accept']")).Click();
            webDriver.FindElement(By.XPath("//span[text()='Log in']")).Click();
            Login ObjLoginPage = new Login(webDriver);
            ObjLoginPage.LogIntoSys("godmaks@gmail.com", "Qwerty123");
        }

        [Test]
        //positive
        public void TestSearchFF()
        {
            HomePage objSearch = new HomePage(webDriver);
            objSearch.SearchBtn.Click();
            var searchResult = objSearch.SearchgBox("The Milkmaid");
            Assert.AreEqual(205, searchResult.Count);
        }
        [Test]
        //add to collection result
        public void TestAddToCollection()
        {
            SearchPage objSearchPage = new SearchPage(webDriver);
            objSearchPage.AddToCollection.Click();
            webDriver.FindElement(By.XPath("//*[@data-uitest='profile-avatar']")).Click();
            webDriver.FindElement(By.XPath("//*[text()='My first collection']")).Click();
            IWebElement pic = webDriver.FindElement(By.XPath("//img[contains(@data-src,'F=w200')]"));
            Assert.AreEqual(true, pic.Displayed);
        }


        public void BrowserClose()
        {
            webDriver.Quit();
        }
    }
}
