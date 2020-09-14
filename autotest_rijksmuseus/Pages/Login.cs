using OpenQA.Selenium;


namespace autotest_rm.Pages
{
    class Login
    {
        IWebDriver webDriver;

        public Login(IWebDriver webDriver) => this.webDriver = webDriver;

        #region Objects
        public IWebElement EmailTextBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//*[@id='email']"));
            }
        }

        private IWebElement PwdBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//*[@id='wachtwoord']"));
            }
        }

        private IWebElement LoginBtn
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[contains(@class,'button-bold button-primary')][@value='Log in']"));
            }
        }

        private IWebElement LogOutBtn
        {
            get
            {
        
                return webDriver.FindElement(By.XPath("//button[contains(.,'Log out')]"));
            }
        }
        #endregion

        #region Methods
        public string LogIntoSys(string username, string password)
        {

            EmailTextBox.SendKeys(username);
            PwdBox.SendKeys(password);
            LoginBtn.Click();
            string LoginPageTitle = webDriver.Title;
            return LoginPageTitle;

        }
        public string LogOutFromSys()
        {

            LogOutBtn.Click();
            string LogOutPageTitle = webDriver.Title;
            return LogOutPageTitle;

        }
    }
}
#endregion