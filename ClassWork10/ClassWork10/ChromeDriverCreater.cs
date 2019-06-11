using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ClassWork10
{
    /// <summary>
    /// class for create Chrome driver
    /// </summary>
    public class ChromeDriverCreater : ICreater
    {
        /// <summary>
        /// method for create Crome driver
        /// </summary>
        /// <returns></returns>
        public IWebDriver Create() => new ChromeDriver();
    }
}