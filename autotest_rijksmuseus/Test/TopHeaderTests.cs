using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumPOTest.Pages;
using System;

namespace SeleniumPOTest
{
    public class GloginTest
    {
        IWebDriver webDriver;


        [SetUp]
        public void IntBrowser()
        {
            webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://www.dnvgl.com/");
            webDriver.Manage().Window.Maximize();

        }

        [Test]
        public void TestSectorsList()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TestServisesDropDown()
        {
            Assert.Inconclusive();
        }

        [Test]
        public void TestInsightsDropDown()
        {
            Assert.Inconclusive();
        }


        [Test]
        public void TestAboutUsDropDown()
        {
            Assert.Inconclusive();
        }
        public void BClose()
        {
            webDriver.Quit();
        }

    }
}
  