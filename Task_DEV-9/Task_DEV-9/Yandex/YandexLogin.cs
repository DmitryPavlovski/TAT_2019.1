using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    /// <summary>
    /// class for login page
    /// </summary>
    class YandexLogin
    {
        IWebDriver Driver { get; set; }
        IWebElement ButtonEntry => this.Driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"), 10);
        IWebElement LoginBox => this.Driver.FindElement(By.XPath("//input[@name='login']"), 10);
        IWebElement PasswordBox => this.Driver.FindElement(By.XPath("//input[@name='passwd']"), 10);
        IWebElement ButtonLetters => this.Driver.FindElement(By.XPath("//a[.//*[contains(text(), 'Почта')]]"), 10);
        public IWebElement ErrorMessage => this.Driver.FindElement(By.XPath("//div[@class='passp-form-field__error']"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public YandexLogin(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for go to login page
        /// </summary>
        public void GoToLogin() => this.Driver.Navigate().GoToUrl("https://yandex.by/");

        /// <summary>
        /// method for autorisation
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public MainPage Login(string login, string password)
        {
            this.ButtonEntry.Click();
            this.LoginBox.SendKeys(login + Keys.Enter);
            this.PasswordBox.SendKeys(password + Keys.Enter);

            return new MainPage(this.Driver);
        }

        /// <summary>
        /// method for login if logged before
        /// </summary>
        /// <returns></returns>
        public MainPage EntryAgain()
        {
            this.ButtonLetters.Click();

            return new MainPage(this.Driver);
        }

        public YandexLogin Login_ExpectingError(string username, string password)
        {
            this.ButtonEntry.Click();
            this.LoginBox.SendKeys(Keys.Enter);
            this.LoginBox.SendKeys(username + Keys.Enter);
            if (this.Driver.FindElements(By.XPath("//div[@class='passp-form-field__error']")).Count == 0)
            {
                this.PasswordBox.SendKeys(password + Keys.Enter);
            }

            return this;
        }
    }
}
