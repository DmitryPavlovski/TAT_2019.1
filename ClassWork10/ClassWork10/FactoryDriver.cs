namespace ClassWork10
{
    /// <summary>
    /// class for creat driver
    /// </summary>
    class FactoryDriver
    {
            const string nameChrome = "chrome";

            /// <summary>
            /// The method returns webdriver.
            /// </summary>
            /// <param name="request"></param>
            /// <returns></returns>
            public ICreater GetDriver(string request)
            {
                int startIndex = request.IndexOf(' ');
                string driverName = request.Substring(startIndex + 1);

                switch (driverName)
                {
                    case nameChrome:
                        return new ChromeDriverCreater();
                    default:
                        return null;
                }
            }
    }
}
