using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using SeleniumPOTest.Pages;
using System;

namespace SeleniumPOTest
{
    public class GLoginTestFF
    {
        IWebDriver webDriver;
       

        [SetUp]

        public void IntBrowser()
        {
            webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://www.dnvgl.com/");
            webDriver.FindElement(By.ClassName("the-header__login")).Click();
            webDriver.Manage().Window.Maximize();
            //webDriver.Navigate().GoToUrl("https://www.veracity.com/auth/login");
        }
                
        [Test]
        //positive test
        public void TestTopHeader()
        {
        HomePage ObjHomePage = new HomePage(webDriver);
        Login ObjLoginPage = new Login(webDriver);
        string LoginPageTitle = ObjLoginPage.LogIntoSys("mephistachio@gmail.com", "Qazxsw123");
        Assert.AreEqual("Sign In", LoginPageTitle);
        string homepageTitle = ObjHomePage.GetHomePageTitle();
       Assert.AreEqual("Working...", homepageTitle);
            new WebDriverWait(webDriver, TimeSpan.FromSeconds(3)).Until(x=>x.Url == "https://www.veracity.com/");
            Assert.AreEqual("https://www.veracity.com/", webDriver.Url);
            webDriver.Navigate().Back();
            Assert.AreEqual("https://www.veracity.com/auth/oidc/loginreturn", webDriver.Url);
            //Assert.AreEqual("Error", homepageTitle);
         }

        
        public void BClose()
        {
        webDriver.Quit();
        }

    }
}
  