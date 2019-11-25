using System;
using Task_DEV_9.Yandex;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9.Tests
{
    [TestFixture]
    public class LoginTestsYandex
    {
        private IWebDriver driver;

        [SetUp]
        public void Start()
        {
            this.driver = new ChromeDriver();
            this.driver.Navigate().GoToUrl("https://yandex.by");
            this.driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }

        [Test]
        public void Login_CorrectId_Proceed()
        {
            var startPage = new YandexLogin(this.driver);
            var email = "dima.kupeshka@yandex.by";
            var password = "taskdev9";

            var mainPage = startPage.Login(email, password);

            Assert.True(mainPage.SendLetterButton.Displayed);
        }

        [Test]
        public void Login_EmptyInput_ErrorMessage()
        {
            var startPage = new YandexLogin(this.driver);

            startPage.Login_ExpectingError(string.Empty, string.Empty);

            Assert.AreEqual("Логин не указан", startPage.ErrorMessage.Text);
        }

        [Test]
        public void Login_EmptyPassword_ErrorMessage()
        {
            var startPage = new YandexLogin(this.driver);
            var username = "dima.kupeshka@yandex.by";

            startPage.Login_ExpectingError(username, string.Empty);

            Assert.AreEqual("Пароль не указан", startPage.ErrorMessage.Text);
        }

        [Test]
        public void Login_WrongUsername_ErrorMessage()
        {
            var startPage = new YandexLogin(this.driver);
            var username = "Offspring12345678911";

            startPage.Login_ExpectingError(username, string.Empty);

            Assert.AreEqual("Такого аккаунта нет", startPage.ErrorMessage.Text);
        }

        [Test]
        public void Login_WrongPassword_ErrorMessage()
        {
            var startPage = new YandexLogin(this.driver);
            var username = "dima.kupeshka@yandex.by";
            var password = "pup";

            startPage.Login_ExpectingError(username, password);

            Assert.AreEqual("Неверный пароль", startPage.ErrorMessage.Text);
        }

        [TearDown]
        public void Close() => this.driver.Quit();
    }
}