using OpenQA.Selenium;
using System.Collections.Generic;
using OpenQA.Selenium.Interactions;

namespace autotest_rm.Pages
{
    class HomePage
    {
        IWebDriver webDriver;
        public HomePage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }

        #region Objects
        public IWebElement SearchBtn
        {
            get
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(webDriver.FindElement(By.XPath("//input[contains(@class,'autosuggest-submit button-icon button-search')]"))).Click();
                webDriver.FindElement(By.XPath("//input[contains(@class,'button-search')]")).Click();
                return SearchBox;
            }
        }
        public IWebElement SearchBox
        {
            get
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(webDriver.FindElement(By.XPath("//*[contains(@class,'autosuggest-form block-right')]")));
                return webDriver.FindElement(By.XPath("//*[@id='site - header - search']"));
            }
        }
        public IWebElement AddToFavorite
        {
            get
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(webDriver.FindElement(By.XPath("//input[contains(@class,'autosuggest-submit button-icon button-search')]")));
                return AddToFavorite;

            }
        }

        #endregion

        #region Methods
        public string GetHomePageTitle()
        {
            string HomePageTitle = webDriver.Title;
            return HomePageTitle;
        }
        public ICollection<IWebElement> SearchgBox(string search)
        {

            SearchBox.SendKeys(search + Keys.Enter);
            var searchResults = webDriver.FindElements(By.TagName("article"));
            return searchResults;
        }
        #endregion

    }
}
