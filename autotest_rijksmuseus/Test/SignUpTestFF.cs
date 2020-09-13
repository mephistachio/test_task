using NUnit.Framework;
using OpenQA.Selenium;
using autotest_rm.Pages;
using OpenQA.Selenium.Firefox;

namespace autotest_rm
{
    class SignUpTestFF
    {
        IWebDriver webDriver;


        [SetUp]

        public void IntBrowser()
        {
            webDriver = new FirefoxDriver();
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en");
            webDriver.FindElement(By.XPath("//*[text()='Accept']")).Click();
            webDriver.FindElement(By.XPath("//span[text()='Log in']")).Click();
            webDriver.FindElement(By.XPath("//*[@class='reset-button-all link-like']")).Click();
            webDriver.FindElement(By.XPath("//*[@class='button-primary button-like button-bold button-combo-end button-forward']"));
            webDriver.Manage().Window.Maximize();
        }
        [Test]
        public void TestSingUpFF()
        {
            HomePage ObjHomePage = new HomePage(webDriver);
            SignUp ObjSignUpPage = new SignUp(webDriver);

            string SignPageTitle = ObjSignUpPage.SingUpFirstTime("Max", "max@gmail.com", "Qwerty123");
            Assert.AreEqual("Rijksmuseum – The Museum of the Netherlands - in Amsterdam", SignPageTitle);
            string homepageTitle = ObjHomePage.GetHomePageTitle();
            Assert.AreEqual("Rijksmuseum – The Museum of the Netherlands - in Amsterdam", homepageTitle);
        }
    }
}
