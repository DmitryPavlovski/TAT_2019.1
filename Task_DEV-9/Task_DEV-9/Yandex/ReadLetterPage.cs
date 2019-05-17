using OpenQA.Selenium;

namespace Task_DEV_9.Yandex
{
    /// <summary>
    /// class for read letter page
    /// </summary>
    class ReadLetterPage
    {
        IWebDriver Driver { get; set; }
        IWebElement ButtunProfile =>  this.Driver.FindElement(By.XPath("//*[@data-key='view=head-user']"), 10);
        IWebElement ButtonProfileSetting => this.Driver.FindElement(By.XPath("//*[contains(text(), 'Управление аккаунтом')]"), 10);
        IWebElement MessageTextBox => this.Driver.FindElement(By.XPath("//*[@class='mail-Message-Body-Content']"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public ReadLetterPage(IWebDriver driver)
        {
            this.Driver = driver;
        }
        
        /// <summary>
        /// method for go to profile page
        /// </summary>
        /// <returns></returns>
        public SettingProfilePage GoToProfilePage()
        {
            var text = this.MessageTextBox.Text;
            this.Driver.SwitchTo().ParentFrame();
            this.ButtunProfile.Click();
            this.ButtonProfileSetting.Click();

            return new SettingProfilePage(this.Driver);
        }
    }
}
