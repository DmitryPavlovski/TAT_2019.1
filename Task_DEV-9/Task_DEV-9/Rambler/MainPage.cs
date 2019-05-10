using OpenQA.Selenium;

namespace Task_DEV_9.Rambler
{
    class MainPage
    {
        IWebDriver Driver { get; set; }
        IWebElement UnreadLetter { get; set; }
        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        public LetterPage ChooseUnreadLetter(string sender)
        {
            this.UnreadLetter = this.Driver.FindElement(
                By.XPath($"//div[contains(@class,'AutoMaillistItem-root-1n AutoMaillistItem-unseen-ad')]//span[contains(@title, '{sender}')]"), 10);
            this.UnreadLetter.Click();

            return new LetterPage(this.Driver);
        }
    }
}
