using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using OpenQA.Selenium.Support.UI;

namespace autotest_rm.Pages
{
    class SearchPage
    {
        IWebDriver webDriver;
        public SearchPage(IWebDriver webDriver)
        {
            this.webDriver = webDriver;
        }
        #region Objects
        public IWebElement NameBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//*[@id='token - input - QueryDescriptor_AdvancedSearchOptions_ArtistCriteria_InvolvedMakerName']"));
            }
        }
        public IWebElement RoleBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[contains(@id,'Role')][@id='token-input-QueryDescriptor_AdvancedSearchOptions_ArtistCriteria_Role']"));
            }
        }
        public IWebElement TitleBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//*[@id='QueryDescriptor_AdvancedSearchOptions_ObjectCriteria_Title']"));
            }
        }
        public IWebElement CheckBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@data-val-required='The Only with image field is required.']"));
            }
        }
        public IWebElement StartDate
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@class='block-left half-width'][contains(@id,'StartDate')]"));
            }
        }
        public IWebElement EndDate
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@class='block-right half-width'][contains(@id,'EndDate')]"));
            }
        }
        public IWebElement FindBtn
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[contains(@value,'Find')]"));
            }
        }
        #endregion
        #region Methods
        public IWebElement AddToCollection
        {
            get
            {
                Actions action = new Actions(webDriver);
                action.MoveToElement(webDriver.FindElement(By.XPath("///*[contains(@class,'button-like')][@data-object-number='SK-A-2344']"))).Click();
                new WebDriverWait(webDriver, TimeSpan.FromSeconds(3)).Until(x => x.FindElement(By.XPath("//*[contains(text(),'To which of your Rijksstudio sets would you like to add this?')]")));
                webDriver.FindElement(By.XPath("//*[contains(text(),'My first collection')]")).Click();
                return AddToCollection;
            }
        }
        public string AdvancedSearch(string name, string title, string startdate, string enddate)
        {
            NameBox.SendKeys(name);
            TitleBox.SendKeys(title);
            CheckBox.Click();
            StartDate.SendKeys(startdate);
            EndDate.SendKeys(enddate);
            FindBtn.Click();
            string SearchResult = webDriver.FindElement(By.XPath("//a[contains(.,'4 works')]")).ToString();
            return SearchResult;
        }
    }
}
#endregion