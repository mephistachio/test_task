using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using autotest_rm.Pages;

namespace autotest_rm
{
    public class GloginTestIE
    {
        IWebDriver webDriver;
        
        [SetUp]
        public void IntBrowser()
        {
            webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en");
            webDriver.FindElement(By.XPath("//*[text()='Accept']")).Click();
            webDriver.FindElement(By.XPath("//span[text()='Log in']")).Click();
        }

        [Test]
        public void TestLoginFF()
        {
            Login ObjLoginPage = new Login(webDriver);
            string LoginPageTitle = ObjLoginPage.LogIntoSys("godmaks@gmail.com", "Qwerty123");
            Assert.AreEqual("Rijksmuseum – The Museum of the Netherlands - in Amsterdam", LoginPageTitle);
        }

        public void BClose()
        {
            webDriver.Quit();
        }

    }
}
  