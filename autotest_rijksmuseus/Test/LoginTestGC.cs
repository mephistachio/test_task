using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using autotest_rm.Pages;

namespace autotest_rm
{
    public class LoginTestGC
    {
        IWebDriver webDriver;

        [SetUp]
        public void IntBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en");
            webDriver.FindElement(By.XPath("//span[text()='Log in']")).Click();
        }

        [Test]
        public void TestLoginGC()
        {
            Login ObjLoginPage = new Login(webDriver);
            string LoginPageTitle = ObjLoginPage.LogIntoSys("godmaks@gmail.com", "Qwerty123");
            Assert.AreEqual("Rijksmuseum – The Museum of the Netherlands - in Amsterdam", LoginPageTitle);
        }
        [Test]
        public void TestLogOutGC()
        {
            webDriver.FindElement(By.XPath("//*[@data-uitest='profile-avatar']")).Click();
            webDriver.FindElement(By.XPath("//button[contains(.,'Log out')]"));
            string LogOutPageTitle = webDriver.Title;
            Assert.AreEqual("Rijksmuseum – The Museum of the Netherlands - in Amsterdam", LogOutPageTitle);
        }

        public void BrowserClose()
        {
            webDriver.Quit();
        }

    }
}