using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_DEV_9
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            try
            { /*
                var driver = new MailRu.YandexLogin();
                var loginGmail = "dima.kupeshka@gmail.com";
                var message = "KUKUSHKA";
                driver.GoToLogin();
                driver.Login(loginMailRu, passwordMailRu).GoToSendLetter().SendMessage(loginGmail, message);*/
                var loginRambler = "dima.kupeshka";
                var passwordMailRu = "Taskdev9";
                var driver = new Rambler.RamblerLogin();
                driver.GoToLogin();
                string yandexEmail = "dima.kupeshka@yandex.by";
                driver.Login(loginRambler, passwordMailRu).ChooseUnreadLetter(yandexEmail).ReplyToLetter(yandexEmail);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}
