using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ClassWork10
{
    /// <summary>
    /// class for extention method
    /// </summary>
    static class WebDriverExtension
    {
        /// <summary>
        /// extention method with waiting for an element to appear
        /// </summary>
        /// <param name="driver"></param>
        /// <param name="by"></param>
        /// <param name="timeoutInSeconds"></param>
        /// <returns></returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }

            return driver.FindElement(by);
        }
    }
}