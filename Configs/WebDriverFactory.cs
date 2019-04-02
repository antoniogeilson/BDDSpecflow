using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Configuration;
using System.IO;

namespace Project_AntonioGeilson.Configs
{
    public enum DriverType
    {
        Chrome, Firefox, IE, PhantomJS, AppiumDriver
    }

    public static class WebDriverFactory
    {
        public static IWebDriver Create()
        {
            var driver = new ChromeDriver(DriversPath);

            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(60);
            return driver;
        }

        public static string DriversPath
        {
            get
            {
                return Path.Combine(AppContext.BaseDirectory, "Drivers");
            }
        }

        public static object Message { get; private set; }

    }
}