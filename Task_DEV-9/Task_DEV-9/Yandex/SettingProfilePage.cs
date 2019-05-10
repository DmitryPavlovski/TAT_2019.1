using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    class SettingProfilePage
    {
        IWebDriver Driver { get; set; }
        string NewNickname { get; set; }
        IWebElement PersonalDataButton => this.Driver.FindElement(By.XPath("//*[contains(text(), 'Изменить персональную информацию')]"), 10);

        public SettingProfilePage(IWebDriver driver, string newNickname)
        {
            this.Driver = driver;
            this.NewNickname = newNickname;
        }

        public ChangePersonalDataPage GoToSetting()
        {
            this.PersonalDataButton.Click();

            return new ChangePersonalDataPage(this.Driver, this.NewNickname);
        }
    }
}
