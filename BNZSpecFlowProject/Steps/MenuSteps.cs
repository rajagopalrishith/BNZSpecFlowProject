using BNZSpecFlowProject.Context;
using BNZSpecFlowProject.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace BNZSpecFlowProject.Steps
{
    [Binding]
    public class MenuSteps
    {
        private MenuPage _MenuPage { get; set; }

        private DataContext DataContext;

        public MenuSteps(MenuPage menuPage, DataContext dataContext)
        {
            _MenuPage = menuPage;
            DataContext = dataContext;
        }

        [Then(@"I open the bnz application home page")]
        [When(@"I open the bnz application home page")]
        [Given(@"I open the bnz application home page")]
        public void GivenIOpenTheBnzApplicationHomePage()
        {
            _MenuPage.NavigatetoBnzHome();
            _MenuPage.Waitfor5seconds();
        }

        [When(@"I click Menu option")]
        public void WhenIClickMenuOption()
        {
            _MenuPage.clickMenuOption();
        }


     

        [Then(@"I click Payees link from the menulist")]
        public void ThenIClickPayeesLinkFromTheMenulist()
        {
            _MenuPage.clickPayeeOption();
        }


        [Then(@"Verify Payees page is loaded")]
        public void ThenVerifyPayeesPageIsLoaded()
        {
            string expectedlabel = "Payees";
            string actuallabel = _MenuPage.paymentTitleVisible();
            Assert.AreEqual(expectedlabel, actuallabel, "Payees page is opened");
        }





    }
}
