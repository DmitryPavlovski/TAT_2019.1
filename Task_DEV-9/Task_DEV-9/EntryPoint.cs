using System;
using OpenQA.Selenium.Chrome;

namespace Task_DEV_9
{
    /// <summary>
    /// Prograam login in Yandex email and send on Rambler email letter
    /// Read letter on Rambler and reply with new profile name
    /// After read on Yandex this letter and change profile name
    /// </summary>
    class EntryPoint
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="arg">
        /// arg[0] - yandex email
        /// arg[1] - yandex password
        /// arg[2] - rambler email
        /// arg[3] - rambler password
        /// </param>
        static void Main(string[] arg)
        {
            try
            {
                var driver = new ChromeDriver();
                var yandex = new Yandex.YandexLogin(driver);
                var yandexEmail = arg[0];
                var yandexPassword = arg[1];
                var ramblerEmail = arg[2];
                var ramblerPassword = arg[3];
                var message = "London is the capital of Great Britain";
                var newNickname = "Picachu";

                yandex.GoToLogin();
                yandex.Login(yandexEmail, yandexPassword).GoToSendLetterPage().SendMessage(ramblerEmail, message);
                var rambler = new Rambler.RamblerLogin(driver);
                rambler.GoToLogin();
                rambler.Login(ramblerEmail, ramblerPassword).ChooseUnreadLetter(yandexEmail).ReplyToLetter(newNickname);
                var yandexSecond = new Yandex.YandexLogin(driver);
                yandexSecond.GoToLogin();
                yandexSecond.Login(yandexEmail, yandexPassword).ReadLastLetter().GoToProfilePage().GoToSetting().ChangeNickname(newNickname);
                driver.Quit();

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
