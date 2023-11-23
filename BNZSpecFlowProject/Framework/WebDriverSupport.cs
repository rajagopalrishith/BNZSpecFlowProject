using BoDi;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace BNZSpecFlowProject
{
    [Binding]
    public class WebDriverSupport : IDisposable
    {
        private readonly IObjectContainer objectContainer;
        private IWait<IWebDriver> _defaultWait = null;
        private IWebDriver Driver = null;

        public WebDriverSupport(IObjectContainer objectContainer)
        {
            this.objectContainer = objectContainer;
        }

        [BeforeScenario]
        public void InitializeWebDriver()
        {
            this.Driver = new ChromeDriver();
            {
            };
            objectContainer.RegisterInstanceAs(Driver, typeof(IWebDriver));
            int timeout = 5000;
            int pollInterval = 100;
            _defaultWait = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(timeout))
            {
                PollingInterval = TimeSpan.FromMilliseconds(pollInterval)
            };
            objectContainer.RegisterInstanceAs(_defaultWait, typeof(IWait<IWebDriver>));
        }

        [AfterScenario]
        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver.Dispose();
            }
        }
    }
}