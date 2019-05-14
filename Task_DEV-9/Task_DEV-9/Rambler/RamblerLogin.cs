using OpenQA.Selenium;

namespace Task_DEV_9.Rambler
{
    /// <summary>
    /// class for login page
    /// </summary>
    class RamblerLogin
    {
        IWebDriver Driver { get; set; }
        IWebElement LoginBox => this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
        IWebElement PasswordBox => this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
        IWebElement CheckBox => this.Driver.FindElement(By.XPath("//span[@class = 'rui-Checkbox-fake']"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public RamblerLogin(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for go to login page
        /// </summary>
        public void GoToLogin() => this.Driver.Navigate().GoToUrl("https://www.mail.rambler.ru/");

        /// <summary>
        /// method for autorisation
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MainPage Login(string login, string password)
        {
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe"), 10));
            this.LoginBox.SendKeys(login);
            this.PasswordBox.SendKeys(password);

            if (!this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.PasswordBox.SendKeys(Keys.Enter);

            return new MainPage(this.Driver);
        }
    }
}
