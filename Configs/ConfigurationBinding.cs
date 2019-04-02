using BoDi;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.Extensions;
using System.Threading;
using TechTalk.SpecFlow;

namespace Project_AntonioGeilson.Configs
{
    [Binding]
    public class ConfigurationBinding
    {
        private readonly IObjectContainer objectContainer;
        public string feature = FeatureContext.Current.FeatureInfo.Title;
        public string scenario = ScenarioContext.Current.ScenarioInfo.Title;
             

        public ConfigurationBinding(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario("web")]
        public void InitializeWebDriver()
        {
            var driver = WebDriverFactory.Create();

            //System.IO.Directory.CreateDirectory("C://repos//automacao//screenshots//" + feature);           

            objectContainer.RegisterInstanceAs<IWebDriver>(driver);
        }

        [AfterScenario("web")]
        public void DisposeWebDriver()
        {
            var driver = objectContainer.Resolve<IWebDriver>();

            Thread.Sleep(100);
            //driver.TakeScreenshot().SaveAsFile("C://repos//automacao//screenshots//" + feature + "//" + scenario + ".png", 0);

            if (driver != null)
            {
                driver.Quit();
            }
        }
    }
}
