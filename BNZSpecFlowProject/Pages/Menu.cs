using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BNZSpecFlowProject.Pages
{
    public class MenuPage : BasePage
    {
        protected new IWebDriver Driver { get; }


        public MenuPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }

        // Menu page fields

        private readonly By MenuText = By.XPath("//span[text()='Menu']");
        private readonly By Payees = By.XPath("//span[text()='Payees']");
        private readonly By PayeesHeader = By.XPath("(//h1[@class='CustomPage-heading']//span)[2]");


        public void NavigatetoBnzHome()
        {
            Driver.Navigate().GoToUrl("https://www.demo.bnz.co.nz/client/");

        }

        public void Waitfor5seconds()
        {
            System.Threading.Thread.Sleep(5000);
        }

        public void Waitfor2seconds()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public void Waitfor10seconds()
        {
            System.Threading.Thread.Sleep(10000);
        }


        public void clickMenuOption()
        {
            ClickOnElement(MenuText);
        }

        public void clickPayeeOption()
        {
            ClickOnElement(Payees);
        }

        public string paymentTitleVisible()
        {
            return GetElementText(PayeesHeader);

        }

        public void CloseApplication()

        {

            Driver.Dispose();
        }

    }
}
