using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    /// <summary>
    /// class for send letter page
    /// </summary>
    class SendLetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement FildOfRecipient => this.Driver.FindElement(By.XPath("//div[@class='js-compose-field mail-Bubbles']"), 10);
        IWebElement FildOfMessage => this.Driver.FindElement(By.XPath("//textarea[@dir]"), 10);
        IWebElement ButtonSend => this.Driver.FindElement(By.XPath("//button[contains(@title,'(Ctrl + Enter)')]"), 10);
        IWebElement ButtonLetters => this.Driver.FindElement(By.XPath("//div[@data-key='view=folders']/a[1]"), 10);
        IWebElement ButtonAccept => this.Driver.FindElement(By.XPath("//div[@class='_nb-popup-buttons']/button[1]"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public SendLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for send message on email
        /// </summary>
        /// <param name="email"></param>
        /// <param name="message"></param>
        /// <returns></returns>
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
