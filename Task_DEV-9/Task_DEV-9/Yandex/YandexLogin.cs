using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9.MailRu
{
    class YandexLogin
    {
        public IWebDriver Driver { get; set; }
        IWebElement LoginBox { get; set; }
        IWebElement PasswordBox { get; set; }

        public YandexLogin()
        {
            this.Driver = new ChromeDriver();
        }

        public void GoToLogin() => this.Driver.Navigate().GoToUrl("https://yandex.by/");

        public MainPage Login(string login, string password)
        {
            this.Driver.FindElement(By.XPath("//a[contains(@class,'button desk-notif-card__login-enter-expanded')]"), 10).Click();
            this.LoginBox = this.Driver.FindElement(By.XPath("//input[@name='login']"), 10);
            this.LoginBox.SendKeys(login + Keys.Enter);
            this.PasswordBox = this.Driver.FindElement(By.XPath("//input[@name='passwd']"), 10);
            this.PasswordBox.SendKeys(password + Keys.Enter);

            return new MainPage(this.Driver);
        }
    }
}
