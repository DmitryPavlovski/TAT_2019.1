using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9.Yandex
{
    class YandexLogin
    {
        private object v;

        IWebDriver Driver { get; set; }
        IWebElement ButtonEntry => this.Driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"), 10);
        IWebElement LoginBox => this.Driver.FindElement(By.XPath("//input[@name='login']"), 10);
        IWebElement PasswordBox => this.Driver.FindElement(By.XPath("//input[@name='passwd']"), 10);

        public YandexLogin(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public YandexLogin(object v)
        {
            this.v = v;
        }

        public void GoToLogin() => this.Driver.Navigate().GoToUrl("https://yandex.by/");

        public MainPage Login(string login, string password)
        {
            this.ButtonEntry.Click();
            this.LoginBox.SendKeys(login + Keys.Enter);
            this.PasswordBox.SendKeys(password + Keys.Enter);

            return new MainPage(this.Driver);
        }
    }
}
