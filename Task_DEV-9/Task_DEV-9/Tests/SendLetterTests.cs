using System;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9.Tests
{
    [TestFixture]
    public class SendLetterTests
    {
        private IWebDriver driver;
        private readonly string ramblerAddress = "dima.kupeshka@rambler.ru";
        private readonly string yandexAddress = "dima.kupeshka@yandex.by";
        private readonly string passwordRambler = "Taskdev9";
        private readonly string passwordYandex = "taskdev9";

        [SetUp]
        public void StartBrowser()
        {
            this.driver = new ChromeDriver();
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void SendLetter()
        {
            var letterText = "Letter text";

            this.driver.Url = "https://yandex.by";
            var yandexLoginPage = new Yandex.YandexLogin(this.driver);
            var yandexMainPage = yandexLoginPage.Login(this.yandexAddress, this.passwordYandex);
            var yandexWriterPage = yandexMainPage.GoToSendLetterPage();
            yandexWriterPage.SendMessage(this.ramblerAddress, letterText);

            this.driver.Url = "https://www.mail.rambler.ru/";
            var ramblerLoginPage = new Rambler.RamblerLogin(this.driver);
            var ramblerMainPage = ramblerLoginPage.Login(this.ramblerAddress, this.passwordRambler);
            Assert.True(ramblerMainPage.SenderOfMail().GetAttribute("title").Contains(this.yandexAddress));
            var ramblerReadPage = ramblerMainPage.ChooseUnreadLetter(this.yandexAddress);
            var letterRecievedText = ramblerReadPage.TextBoxReceiveLetter.Text;
            Assert.AreEqual(letterText, letterRecievedText);
        }

        [Test]
        public void SendReplyAndChangeNickname()
        {
            var newNicknameToSend = "Rambler";
            this.driver.Navigate().GoToUrl("https://yandex.by");

            var yandex = new Yandex.YandexLogin(this.driver);
            yandex.Login(this.yandexAddress, this.passwordYandex).ReadLastLetter().GoToProfilePage().GoToSetting().ChangeNickname(newNicknameToSend);
            var changePersonalDataPage = new Yandex.ChangePersonalDataPage(this.driver);
            var nickname = changePersonalDataPage.FirstNameBox.GetAttribute("value");

            Assert.AreEqual(newNicknameToSend, nickname);
        }

        [TearDown]
        public void CloseBrowser() => this.driver.Quit();
    }
}