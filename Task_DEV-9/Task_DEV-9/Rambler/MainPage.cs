using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Task_DEV_9.Rambler
{
    class MainPage
    {
        /// <summary>
        /// class for main page email
        /// </summary>
        IWebDriver Driver { get; set; }
        ReadOnlyCollection<IWebElement> UnreadLetters { get; set; }

        readonly string unreadLetterLocator = "//div[contains(@class,'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad')]";
        IWebElement LettersButton => this.Driver.FindElement(By.XPath("//span[contains(text(),'Входящие')]"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// class for open unread letter from specific sender
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public LetterPage ChooseUnreadLetter(string sender)
        {
            this.LettersButton.Click();
            this.UnreadLetters = this.Driver.FindElements(
                By.XPath(this.unreadLetterLocator + $"//span[contains(@title, '{sender}')]"));
            while(this.UnreadLetters.Count == 0)
            {
                this.Driver.Navigate().Refresh();
            }
            this.UnreadLetters[0].Click();

            return new LetterPage(this.Driver);
        }

        public IWebElement SenderOfMail() => this.Driver.FindElement(By.XPath("//div[@style='position: relative;']/div/div[1]" +
            "//span[contains(@class, 'AutoMaillistItem-sender')]"));
    }
}
