using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    class ChangePersonalDataPage
    {
        IWebDriver Driver { get; set; }
        string NewNickname { get; set; }
        IWebElement FirstNameBox => this.Driver.FindElement(By.XPath("//input[@id='firstname']"), 10);
        IWebElement SaveButton => this.Driver.FindElement(By.XPath("//*[contains(text(),'Сохранить')]"), 10);

        public ChangePersonalDataPage(IWebDriver driver, string newNickname)
        {
            this.Driver = driver;
            this.NewNickname = newNickname;
        }
        public void ChangeNickname()
        {
            this.FirstNameBox.Clear();
            this.FirstNameBox.Clear();
            this.FirstNameBox.SendKeys(this.NewNickname);
            this.SaveButton.Click();
        }
    }
}
