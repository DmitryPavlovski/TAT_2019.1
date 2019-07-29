using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    /// <summary>
    /// class for page where change personal data
    /// </summary>
    class ChangePersonalDataPage
    {
        IWebDriver Driver { get; set; }
        public IWebElement FirstNameBox => this.Driver.FindElement(By.XPath("//input[@id='firstname']"), 10);
        IWebElement SaveButton => this.Driver.FindElement(By.XPath("//div[contains(@class, 'right personal-saveblock')].."), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="bufferData"></param>
        public ChangePersonalDataPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for change nickname
        /// </summary>
        public SettingProfilePage ChangeNickname(string newNickname)
        {
            this.FirstNameBox.SendKeys(Keys.Shift + Keys.Home);
            this.FirstNameBox.SendKeys(newNickname);
            this.SaveButton.Click();

            return new SettingProfilePage(this.Driver);
        }
    }
}
