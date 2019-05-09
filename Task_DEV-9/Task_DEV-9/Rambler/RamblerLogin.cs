using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9.Rambler
{
    class RamblerLogin
    {
        IWebDriver Driver { get; set; }
        IWebElement LoginBox { get; set; }
        IWebElement PasswordBox { get; set; }
        IWebElement CheckBox { get; set; }
        
        public RamblerLogin()
        {
            this.Driver = new ChromeDriver();
        }

        public void GoToLogin() => this.Driver.Navigate().GoToUrl("https://www.mail.rambler.ru/");

        public MainPage Login(string login, string password)
        {
            this.Driver.SwitchTo().Frame(this.Driver.FindElement(By.XPath("//iframe"), 10));
            this.LoginBox = this.Driver.FindElement(By.XPath("//input[@name = 'login']"), 10);
            this.LoginBox.SendKeys(login);
            this.PasswordBox = this.Driver.FindElement(By.XPath("//input[@name = 'password']"), 10);
            this.PasswordBox.SendKeys(password);
            this.CheckBox = this.Driver.FindElement(By.XPath("//span[@class = 'rui-Checkbox-fake']"), 10);

            if (!this.CheckBox.Selected)
            {
                this.CheckBox.Click();
            }

            this.PasswordBox.SendKeys(Keys.Enter);

            return new MainPage(this.Driver);
        }
    }
}
