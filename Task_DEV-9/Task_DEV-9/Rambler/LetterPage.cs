using OpenQA.Selenium;
using System;

namespace Task_DEV_9.Rambler
{
    class LetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement TextField { get; set; }
        IWebElement SendButton { get; set; }

        public LetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void ReplyToLetter(string sendMessage)
        {
            this.TextField = this.Driver.FindElement(By.XPath("//textarea[@placeholder='Быстрый ответ']"), 10);
            this.TextField.SendKeys(sendMessage);
            this.SendButton = this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить письмо')]"), 10);
            this.SendButton.Click();
        }
    }
}
