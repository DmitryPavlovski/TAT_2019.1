using OpenQA.Selenium;

namespace ClassWork10
{
    public interface ICreater
    {
        /// <summary>
        /// The method creates webdriver.
        /// </summary>
        /// <returns></returns>
        IWebDriver Create();
    }
}
