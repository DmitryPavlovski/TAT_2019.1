using OpenQA.Selenium;

namespace Task_DEV_9.Rambler
{
    class LetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement TextFieldSendLetter => this.Driver.FindElement(By.XPath("//textarea[@placeholder='Быстрый ответ']"), 10);
        IWebElement SendButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить письмо')]"), 10);
        IWebElement TextBoxReceiveLetter => this.Driver.FindElement(By.XPath("//*[@id='part1']/div"), 10);

        public LetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public void ReplyToLetter(string receivedMessage, string sendMessage)
        {
            if (this.TextBoxReceiveLetter.Text.Contains(receivedMessage))
            {
                this.TextFieldSendLetter.SendKeys(sendMessage);
                this.SendButton.Click();
            }
        }
    }
}
