using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    class SendLetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement FildOfRecipient => this.Driver.FindElement(By.XPath("//div[@class='js-compose-field mail-Bubbles']"), 10);
        IWebElement FildOfMessage => this.Driver.FindElement(By.XPath("//textarea[@dir]"), 10);
        IWebElement ButtonSend => this.Driver.FindElement(By.XPath("//*[contains(text(),'Отправить')]"), 10);

        public SendLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void SendMessage(string email, string message)
        {
            this.FildOfRecipient.SendKeys(email);
            this.FildOfMessage.SendKeys(message);
            this.ButtonSend.Click();
        }
    }
}
