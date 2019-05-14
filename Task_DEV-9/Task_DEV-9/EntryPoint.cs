using System;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9
{
    /// <summary>
    /// entry point class
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// entry point
        /// </summary>
        static void Main()
        {
            try
            {
                var driver = new ChromeDriver();
                var yandex = new Yandex.YandexLogin(driver);
                var yandexEmail = "dima.kupeshka@yandex.by";
                var yandexPassword = "taskdev9";
                var ramblerEmail = "dima.kupeshka@rambler.ru";
                var ramblerPassword = "Taskdev9";
                var message = "London is the capital of Great Britain aaaaaaaaaaaaaaaaa";
                var newNickname = "Picachu";

                yandex.GoToLogin();
                yandex.Login(yandexEmail, yandexPassword).GoToSendLetterPage().SendMessage(ramblerEmail, message);
                var rambler = new Rambler.RamblerLogin(driver);
                rambler.GoToLogin();
                rambler.Login(ramblerEmail, ramblerPassword).ChooseUnreadLetter(yandexEmail).ReplyToLetter(message, newNickname);
                var yandexSecond = new Yandex.YandexLogin(driver);
                yandexSecond.GoToLogin();
                yandexSecond.EntryAgain().ReadLastLetter().GoToProfilePage().GoToSetting().ChangeNickname();
                driver.Quit();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
