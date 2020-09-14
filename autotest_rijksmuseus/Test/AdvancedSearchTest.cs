using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using autotest_rm.Pages;

namespace autotest_rm
{
    class AdvancedSearchTest
    {
        IWebDriver webDriver;

        [SetUp]
        public void IntBrowser()
        {
            webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en");
            webDriver.FindElement(By.XPath("//*[text()='Accept']")).Click();
            webDriver.FindElement(By.XPath("//span[text()='Log in']")).Click();
            Login ObjLoginPage = new Login(webDriver);
            ObjLoginPage.LogIntoSys("godmaks@gmail.com", "Qwerty123");
            webDriver.Navigate().GoToUrl("https://www.rijksmuseum.nl/en/search/advanced");
        }

        [Test]
        //positive
        public void TestSearchFF()
        {
            SearchPage objSearchPage = new SearchPage(webDriver);
            string AdvSearch = objSearchPage.AdvancedSearch("UTAGAWA KUNIYOSHI", "DE CHOFU TAMA", "1846", "1850");
            Assert.AreEqual(4, AdvSearch);
        }
        public void BrowserClose()
        {
            webDriver.Quit();
        }
    }
}
