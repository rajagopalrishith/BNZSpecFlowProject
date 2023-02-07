using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using System.Threading.Tasks;
using BNZSpecFlowProject;

namespace BNZ.Pages
{
    public class LandingPage : BasePage
    {
        protected new IWebDriver Driver { get; }


        public LandingPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }

        //Landing Page Fields

        private readonly By checkItOut = By.XPath("//a[@class='button' and contains(.,'Check it out')]");

        private readonly By ClickMenu = By.XPath("//span[text()='Menu']");

        private readonly By ClickPayees = By.XPath("//span[text()='Payees']");

        private readonly By SelectPayeesSearchBar = By.XPath("//input[@type='text' and @placeholder='Search payees']");

        //Landing  Page Methods

        public void NavigatetoBNZDemoHomePage()
        {
            Driver.Navigate().GoToUrl("https://demo.bnz.co.nz/demo/");
        }

        public void Waitfor2seconds()
        {
            System.Threading.Thread.Sleep(2000);
        }


        public void Waitfor5seconds()
        {
            System.Threading.Thread.Sleep(5000);
        }
        public void clickCheckitOutbutton()
        {
            ClickOnElement(checkItOut);
        }

        public void clickMenuFlyout()
        {
            ClickOnElement(ClickMenu);
        }

        public void clickPayees()
        {
            ClickOnElement(ClickPayees);
        }

        public bool IsSelectPayeesFound()
        {
            return IsElementDisplayed(SelectPayeesSearchBar);
        }
    }
}
