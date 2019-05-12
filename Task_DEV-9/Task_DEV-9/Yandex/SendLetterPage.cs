using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    class SendLetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement FildOfRecipient => this.Driver.FindElement(By.XPath("//div[@class='js-compose-field mail-Bubbles']"), 10);
        IWebElement FildOfMessage => this.Driver.FindElement(By.XPath("//textarea[@dir]"), 10);
        IWebElement ButtonSend => this.Driver.FindElement(By.XPath("//*[contains(text(),'Отправить')]"), 10);
        IWebElement ButtonLetters => this.Driver.FindElement(By.XPath("//*[contains(text(), 'Входящие')]"), 10);
        IWebElement ButtonAccept => this.Driver.FindElement(By.XPath("//button[.//*[contains(text(), 'Сохранить и перейти')]]"), 10);

        public SendLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public MainPage SendMessage(string email, string message)
        {
            this.FildOfRecipient.SendKeys(email);
            this.FildOfMessage.SendKeys(message);
            this.ButtonSend.Click();
            this.ButtonLetters.Click();
            this.ButtonAccept.Click();

            return new MainPage(this.Driver);
        }
    }
}
