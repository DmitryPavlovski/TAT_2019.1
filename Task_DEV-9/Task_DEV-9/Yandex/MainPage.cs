using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace Task_DEV_9.MailRu
{
    class MainPage
    {
        IWebDriver Driver { get; set; }
        IWebElement SendLetterBox { get; set; }

        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public SendLetterPage GoToSendLetter()
        {
            this.SendLetterBox = this.Driver.FindElement(By.XPath("//a[.//*[contains(text(), 'Написать')]]"), 10);
            this.SendLetterBox.Click();

            return new SendLetterPage(this.Driver);
        }
    }
}
