using System.Collections.Generic;
using OpenQA.Selenium;

namespace ClassWork10
{
    /// <summary>
    /// class for main page site
    /// </summary>
    class MainPage
    {
        IWebDriver Driver { get; set;}
        static string Web { get; set; } = "https://myfin.by/currency/gbp";
        IWebElement CostOfDollars => this.Driver.FindElement(By.XPath("//a[contains(text(),'Доллар США')]/../../td[2]"), 10);
        IWebElement CostOfEuro => this.Driver.FindElement(By.XPath("//a[contains(text(),'Евро')]/../../td[2]"), 10);
        IWebElement CostOfRusRub => this.Driver.FindElement(By.XPath("//a[contains(text(),'Российский рубль')]/../../td[2]"), 10);
        IWebElement CostOfFunt => this.Driver.FindElement(By.XPath("//a[contains(text(),'Фунт стерлингов')]/../../td[2]"), 10);

        /// <summary>
        /// constructor
        /// </summary>
        /// <param name="driver"></param>
        public MainPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        /// <summary>
        /// method for go to main page
        /// </summary>
        public void GoToPage() => this.Driver.Navigate().GoToUrl(Web);

        /// <summary>
        /// method for get cost dollars
        /// </summary>
        /// <returns></returns>
        public string GetCostOfDollars() => this.CostOfDollars.Text.ToString();

        /// <summary>
        /// method for get cost Euro
        /// </summary>
        /// <returns></returns>
        public string GetCostOfEuro() => this.CostOfEuro.Text.ToString();

        /// <summary>
        /// method for get cost Rus Rub
        /// </summary>
        /// <returns></returns>
        public string GetCostOfRusRub() => this.CostOfRusRub.Text.ToString();

        /// <summary>
        /// method for get cost funt
        /// </summary>
        /// <returns></returns>
        public string GetCostOfFunt() => this.CostOfFunt.Text.ToString();

        /// <summary>
        /// method for get all currencis
        /// </summary>
        /// <returns></returns>
        public List<Currency> GetAllCurrency()
        {
            var list = new List<Currency>
            {
                new Currency(CurrencyName.Dollors.ToString(), this.GetCostOfDollars()),
                new Currency(CurrencyName.Euro.ToString(), this.GetCostOfEuro()),
                new Currency(CurrencyName.Funt.ToString(), this.GetCostOfFunt()),
                new Currency(CurrencyName.RusRub.ToString(), this.GetCostOfRusRub())
            };

            return list;
        }

        /// <summary>
        /// method for Exit
        /// </summary>
        public void Exit() => this.Driver.Quit();
    }
}
