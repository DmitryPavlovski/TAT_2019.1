using OpenQA.Selenium;

namespace Task_DEV_9.MailRu
{
    class SendLetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement FildOfRecipient { get; set; }
        IWebElement FildOfMessage { get; set; }
        IWebElement ButtonSend { get; set; }

        public SendLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void SendMessage(string email, string message)
        {
            this.FildOfRecipient = this.Driver.FindElement(By.XPath("//div[@class='js-compose-field mail-Bubbles']"), 10);
            this.FildOfRecipient.SendKeys(email);
            this.FildOfMessage = this.Driver.FindElement(By.XPath("//textarea[@dir]"), 10);
            this.FildOfMessage.SendKeys(message);
            this.ButtonSend = this.Driver.FindElement(By.XPath("//*[contains(text(),'Отправить')]"), 10);
            this.ButtonSend.Click();           
        }
    }
}
