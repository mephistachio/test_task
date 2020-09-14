using OpenQA.Selenium;


namespace autotest_rm.Pages
{
    class SignUp
    {
        IWebDriver webDriver;

        public SignUp(IWebDriver webDriver) => this.webDriver = webDriver;

        #region Objects
        public IWebElement UserNameBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@placeholder='Rijksstudio name']"));
            }
        }
        public IWebElement EmailTextBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@id='register_email']"));
            }
        }
        private IWebElement RegPwdBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@id='register_password']"));
            }
        }
        private IWebElement RepeatPwdBox
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[@id='register_password2']"));
            }
        }
        private IWebElement SignUpBtn
        {
            get
            {
                return webDriver.FindElement(By.XPath("//input[contains(@class,'button-big')][@value='Sign up']"));
            }
        }
        #endregion

        #region Methods
        public string SingUpFirstTime(string username, string useremail, string password)
        {
            UserNameBox.SendKeys(username);
            EmailTextBox.SendKeys(useremail);
            RegPwdBox.SendKeys(password);
            RepeatPwdBox.SendKeys(password);
            SignUpBtn.Click();
            string LoginPageTitle = webDriver.Title;
            return LoginPageTitle;

        }

    }
}
#endregion