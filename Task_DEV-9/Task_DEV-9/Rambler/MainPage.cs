using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace Task_DEV_9.Rambler
{
    class MainPage
    {
        IWebDriver Driver { get; set; }
        ReadOnlyCollection<IWebElement> UnreadLetters { get; set; }

        readonly string unreadLetterLocator = "//div[contains(@class,'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad')]";
        IWebElement LettersButton => this.Driver.FindElement(By.XPath("//span[contains(text(),'Входящие')]"), 10);

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
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
    }
}
