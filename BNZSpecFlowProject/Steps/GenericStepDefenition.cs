using BNZ.Pages;
using BNZSpecFlowProject.Context;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BNZSpecFlowProject.Steps
{
    [Binding]
    public class GenericStepDefenitions
    {
        private LandingPage _LandingPage { get; }
        private PayeesPage _PayeePage { get; }

        private DataContext DataContext;

        public GenericStepDefenitions(LandingPage landingPage, PayeesPage payeesPage, DataContext dataContext)
        {
            _LandingPage = landingPage;
            _PayeePage = payeesPage;
            DataContext = dataContext;
        }

        [When(@"I open the bnz demo application home page")]
        [Then(@"I open the bnz demo application home page")]
        [Given(@"I open the bnz demo application home page")]
        public void GivenIOpenTheBuggyApplication()
        {
            _LandingPage.NavigatetoBNZDemoHomePage();
            _LandingPage.Waitfor2seconds();
        }


        [Given(@"I click CheckitOut Option")]
        public void GivenIClickCheckitOutOption()
        {
            _LandingPage.clickCheckitOutbutton();
            _LandingPage.Waitfor5seconds();
        }

        [When(@"I select Menu")]
        public void WhenISelectMenu()
        {
            _LandingPage.clickMenuFlyout();
        }

        [When(@"I select Payees")]
        public void WhenISelectPayees()
        {
            _LandingPage.clickPayees();
        }

        [Then(@"I verify payees page is loaded")]
        public void ThenIVerifyPayeesPageIsLoaded()
        {
            Assert.IsTrue(_LandingPage.IsSelectPayeesFound(), "Select Payees search bar not found");
        }

        [When(@"I click Add Payees Option")]
        public void WhenIClickAddPayeesOption()
        {
            _PayeePage.clickAddpayees();
            _LandingPage.Waitfor2seconds();
        }

        [When(@"I enter Payee Name ([^']*)")]
        public void WhenIEnterPayeeName(string payeename)
        {
            _PayeePage.TypePayeeName(payeename);
            _PayeePage.SelectPlaceholder();
            _LandingPage.Waitfor2seconds();
        }

        [When(@"I click submit button")]
        public void WhenIClickSubmitButton()
        {

            _PayeePage.Waitfor5seconds();
            _PayeePage.clickAddpayeesSubmitbutton();

        }


        [When(@"I click disabled submit button")]
        public void WhenIClickDisabledSubmitButton()
        {
            _PayeePage.clickAddpayeesSubmitbuttonDisabled();
        }



        [Then(@"I verify Payee with name ([^']*) is in the list of Payees added")]
        public void ThenIVerifyPayeeWithNameIsInTheListOfPayeesAdded(string message)
        {
            Assert.IsTrue(_PayeePage.IsPayeeNameDisplayedPayeesNames(message), "payee name is not displayed");
        }

        [When(@"I verify mandatory message is shown for Payee field")]
        public void WhenIVerifyMandatoryMessageIsShownForPayeeField()
        {
            _PayeePage.Waitfor2seconds();
            Assert.IsTrue(_PayeePage.IsPayeeRequiredMessageDisplayed(), "required message is displayed");
        }

        [Then(@"I verify the list is sorted ascending by default")]
        public void ThenIVerifyTheListIsSortedAscendingByDefault()
        {
            var PayeeNames = _PayeePage.GetallPayees();
            var sorted = new List<string>();


        }


        [When(@"I click Pay or transfer option")]
        public void WhenIClickPayOrTransferOption()
        {
            _PayeePage.clickPayorTransfer();
            _PayeePage.Waitfor2seconds();
        }


        [Given(@"I fetch balances of accounts")]
        public void GivenIFetchBalancesOfAccounts()
        {
            var everdaybalance = Double.Parse(_PayeePage.GetEverydayaccountBalance().Replace(",", ""));
            var everdaybills = Double.Parse(_PayeePage.GetBillsBalance().Replace(",", ""));
            System.Threading.Thread.Sleep(2000);
            DataContext.EverydayAccountBalance = everdaybalance;
            DataContext.BillsAccountBalance = everdaybills;
        }


        [Then(@"I verify the list is sorted ([^']*) by default")]
        public void ThenIVerifyTheListIsSortedByDefault(string sortorder)
        {
            var PayeeNames = _PayeePage.GetallPayees();
            var sorted = new List<string>();
            if (sortorder == "Ascending")
            {
                sorted.AddRange(PayeeNames.OrderBy(o => o));
            }
            else
            {
                sorted.AddRange(PayeeNames.OrderByDescending(o => o));
            }
            Assert.IsTrue(PayeeNames.SequenceEqual(sorted));
            _PayeePage.Waitfor2seconds();
        }


        [Then(@"I sort the payees list by name")]
        public void ThenISortThePayeesListByName()
        {
            _PayeePage.clickSortByName();
            _PayeePage.Waitfor2seconds();
        }


        [Then(@"I verify Payee added message is displayed")]
        public void ThenIVerifyPayeeAddedMessageIsDisplayed()
        {
            _PayeePage.Waitfor2seconds();
            Assert.IsTrue(_PayeePage.IsPayeeAddedToastDisplayed(), "Message is not displayed");
        }



        [When(@"I transfer amount as per below parameters")]
        public void WhenITransferAmountAsPerBelowParameters(Table table)
        {
            foreach (var item in table.Rows)

            {
                string FromAccount = item.GetString("FromAccount");
                string ToAccount = item.GetString("ToAccount");
                string Amount = item.GetString("Amount");
                if (FromAccount != null && FromAccount != string.Empty)
                {
                    _PayeePage.clickChooseFromAccount();
                    _PayeePage.SelectFromAccount(FromAccount);
                }

                if (ToAccount != null && ToAccount != string.Empty)
                {
                    _PayeePage.clickChooseToccount();
                    _PayeePage.ClickSelectAccountCategoryfromTo();
                    _PayeePage.SelectToAccount(ToAccount);
                }
                _PayeePage.SetAmount(Amount);
                _PayeePage.ClickTransferButtonforPayments();
            }
        }


        [When(@"I enter bank information as below")]
        public void WhenIEnterBankInformationAsBelow(Table table)
        {
            foreach (var item in table.Rows)

            {
                string bank = item.GetString("Bank");
                string branch = item.GetString("Branch");
                string account = item.GetString("Account");
                string suffix = item.GetString("Suffix");

                if (bank != null && bank != string.Empty)
                {
                    _PayeePage.TypeBankDetails(bank);
                }
                if (branch != null && branch != string.Empty)
                {
                    _PayeePage.TypeBranchDetails(branch);
                }

                if (account != null && account != string.Empty)
                {
                    _PayeePage.TypeAccountDetails(account);
                }
                if (suffix != null && suffix != string.Empty)
                {
                    _PayeePage.TypeSuffixDetails(suffix);
                }

            }

        }

        [Then(@"I verify the accounts are updated as per below table")]
        public void ThenIVerifyTheAccountsAreUpdatedAsPerBelowTable(Table table)
        {
            foreach (var item in table.Rows)
            {
                var amount = int.Parse(item.GetString("Amount"));
                System.Threading.Thread.Sleep(2000);
                var CurrentEverydayaccountBalance = Double.Parse(_PayeePage.GetEverydayaccountBalance().Replace(",", ""));
                var CurrentEveryDayBillBalance = Double.Parse(_PayeePage.GetBillsBalance().Replace(",", ""));
                var ExpectedEveryDayBalanceAmount = 0.0;
                var ExpectedBillBalanceAmount = 0.0;
                Assert.That(DataContext.EverydayAccountBalance - amount, Is.EqualTo(CurrentEverydayaccountBalance), "Amount calculation is incorrect");
                Assert.That(DataContext.BillsAccountBalance + amount, Is.EqualTo(CurrentEveryDayBillBalance), "Amount calculation is incorrect");
            }

        }


    }

}
