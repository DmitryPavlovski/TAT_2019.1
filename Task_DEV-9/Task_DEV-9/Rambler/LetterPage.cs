using OpenQA.Selenium;

namespace Task_DEV_9.Rambler
{
    /// <summary>
    /// class for page were send and receive letters
    /// </summary>
    class LetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement TextBoxSendLetter => this.Driver.FindElement(By.XPath("//textarea[@placeholder='Быстрый ответ']"), 10);
        IWebElement SendButton => this.Driver.FindElement(By.XPath("//span[contains(text(), 'Отправить письмо')]"), 10);
        public IWebElement TextBoxReceiveLetter => this.Driver.FindElement(By.XPath("//*[@id='part1']/div"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public LetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for reply to letter if right received letter
        /// </summary>
        /// <param name="receivedMessage"></param>
        /// <param name="sendMessage"></param>
        public void ReplyToLetter(string sendMessage)
        {
            this.TextBoxSendLetter.SendKeys(sendMessage);
            this.SendButton.Click();
        }
    }
}
