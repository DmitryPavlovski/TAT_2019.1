using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    class MainPage
    {
        IWebDriver Driver { get; set; }
        IWebElement SendLetterBox => this.Driver.FindElement(By.XPath("//a[.//*[contains(text(), 'Написать')]]"), 10);
        IWebElement MainLastLetter => this.Driver.FindElement(By.XPath("//*[contains(@class,'ns-view-container-desc mail-MessagesList ')]/*[1]"), 10);
        IWebElement LastLetter => this.Driver.FindElement(By.XPath("//*[contains(@class,'ns-view-container-desc mail-MessagesList')]/*[1]/*/*[2]/*/div"), 10);

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public SendLetterPage GoToSendLetterPage()
        {
            this.SendLetterBox.Click();

            return new SendLetterPage(this.Driver);
        }

        public ReadLetterPage ReadLastLetter()
        {
            this.MainLastLetter.Click();
            this.LastLetter.Click();

            return new ReadLetterPage(this.Driver);
        }
    }
}
