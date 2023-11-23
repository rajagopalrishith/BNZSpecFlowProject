using BNZSpecFlowProject.Context;
using BNZSpecFlowProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium.DevTools.V107.Console;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace BNZSpecFlowProject.Steps
{
 

[Binding]


    public class PayeesSteps
    {
       
        
        private PayeesPage _PayeesPage { get; set; }
        private MenuPage _MenuPage { get; set; }
        private DataContext DataContext;
        private int integerInput;
        private string stringResult;

        public PayeesSteps( PayeesPage payeesPage, MenuPage menuPage, DataContext dataContext)
        {
            _MenuPage = menuPage;
            _PayeesPage = payeesPage;
            DataContext = dataContext;
        }

        [Given(@"Navigate to Payees page")]
        public void GivenNavigateToPayeesPage()
        {
            _MenuPage.NavigatetoBnzHome();
            _MenuPage.Waitfor5seconds();
            _MenuPage.clickMenuOption();
            _MenuPage.clickPayeeOption();
        }



        [When(@"Click ‘Add’ button above Payees list")]
        public void WhenClickAddButtonAbovePayeesList()
        {
            _PayeesPage.clickAddButton();
        }


        [Then(@"Enter data in Payee Name field")]
        public void ThenEnterDataInPayeeNameField(Table table)
        {
            foreach (var item in table.Rows)

            {
                string payeename = item.GetString("payeename");

                if (payeename != null && payeename != string.Empty)
                {
                    _PayeesPage.clickPayeeNameField();
                    _PayeesPage.enterDataInPayeeName(payeename);
                    _MenuPage.Waitfor2seconds();
                    _PayeesPage.selectNewPayeeName(payeename);
                   
                }
            }


        }




        [Then(@"Enter data in Payee Bank Account fields")]
        public void ThenEnterDataInPayeeBankAccountFields(Table table)
        {
            foreach (var item in table.Rows)

            {

                string bankcode = item.GetString("bankcode");
                string branchnamecode = item.GetString("branchnamecode");
                string account = item.GetString("account");
                string suffix = item.GetString("suffix");

                if (bankcode != null && bankcode != string.Empty)
                {
                    _PayeesPage.clickBankNameField();
                    _PayeesPage.enterDataInBankName(bankcode);
                   // _MenuPage.Waitfor2seconds();
                }
                if (branchnamecode != null && branchnamecode != string.Empty)
                {
                    _PayeesPage.clickBranchNameField();
                    _PayeesPage.enterDataInBranchName(branchnamecode);
                   // _MenuPage.Waitfor2seconds();
                }
                if (account != null && account != string.Empty)
                {
                    _PayeesPage.clickAccountField();
                    _PayeesPage.enterDataInAccount(account);
                    //_MenuPage.Waitfor2seconds();
                }
                if (suffix != null && suffix != string.Empty)
                {
                    _PayeesPage.clickSuffixField();
                    _PayeesPage.enterDataInSuffix(suffix);
                   // _MenuPage.Waitfor2seconds();
                }
            }
        }



        [Then(@"Click ‘Add’ button in Payee details entry screen")]
        public void ThenClickAddButtonInPayeeDetailsEntryScreen()
        {
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickSaveAddField();
        }


        [Then(@"validate payeename error")]
        public void ThenValidatePayeenameError()
        {
            
            _PayeesPage.payeeWarning();
        }

     [Then(@"‘Payee added’ message is displayed, and payee is added in the list of payees")]
        public void ThenPayeeAddedMessageIsDisplayedAndPayeeIsAddedInTheListOfPayees()
        {
           // _PayeesPage.confirmationMessageCheck();

            string expectedvalidationmessage = "Payee added";
            string actualvalidationmessage = _PayeesPage.payeeAddedMessage();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "New Payee Added");
        }

       

        [Then(@"I enter a character '([^']*)' in PayeeName field")]
        public void ThenIEnterACharacterInPayeeNameField(string a)
        {
            _PayeesPage.clickPayeeNameField();
            _PayeesPage.enterDataInPayeeName(a);
            _MenuPage.Waitfor2seconds();
        }



        [Then(@"I select an existing payee from the list")]
        public void ThenISelectAnExistingPayeeFromTheList()
        {
            //_PayeesPage.scrollToPayeeFromList();
           // _MenuPage.Waitfor2seconds();
            _PayeesPage.clickanyPayeeFromList();
            
        }

        [Then(@"Enter data in For Payee field")]
        public void ThenEnterDataInForPayeeField(Table table)
        {

            foreach (var item in table.Rows)

            {
                string forpayee = item.GetString("forpayee");

                if (forpayee != null && forpayee != string.Empty)
                {
                    _PayeesPage.clickForPayeeField();
                    _PayeesPage.enterDataInForPayee(forpayee);
                    _MenuPage.Waitfor2seconds();
                   

                }
            }
        }




        [Then(@"I verified that the list is sorted in ascending order")]
        public void ThenIVerifiedThatTheListIsSortedInAscendingOrder()
        {
            System.Threading.Thread.Sleep(2000);
            //_PayeesPage.isPayeeTablePresent();
            var payeenames = _PayeesPage.GetAllPayeeNameasList();
            List<string> names = new List<string>();
            foreach (var item in payeenames) 
            {
                names.Add(item.Text);
            }
            //Console.WriteLine("hey bro");

            static bool IsSortedAscending(List<string> names)
            {
                for (int i = 0; i < names.Count - 1; i++)
                {
                    if (string.Compare(names[i], names[i + 1], StringComparison.Ordinal) > 0)
                    {
                        return false;
                    }
                }
                return true;
            }

            bool isSorted = IsSortedAscending(names);

              if (isSorted)
              {
                     Console.WriteLine("The name list is sorted in ascending order.");
              }
            else
            {
            Console.WriteLine("The name list is not sorted in ascending order.");
            }


        }



        [When(@"I add a new payee ""([^""]*)"" and enter data in Payee Bank Account fields")]
        public void WhenIAddANewPayeeAndEnterDataInPayeeBankAccountFields(string JohnMark, Table table)
        {
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickAddButton();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickPayeeNameField();
            _PayeesPage.enterDataInPayeeName(JohnMark);
            _MenuPage.Waitfor2seconds();
            _PayeesPage.selectNewPayeeName(JohnMark);
            foreach (var item in table.Rows)

            {

                string bankcode = item.GetString("bankcode");
                string branchnamecode = item.GetString("branchnamecode");
                string account = item.GetString("account");
                string suffix = item.GetString("suffix");

                if (bankcode != null && bankcode != string.Empty)
                {
                    _PayeesPage.enterDataInBankName(bankcode);   
                }
                if (branchnamecode != null && branchnamecode != string.Empty)
                {    
                    _PayeesPage.enterDataInBranchName(branchnamecode);  
                }
                if (account != null && account != string.Empty)
                {   
                    _PayeesPage.enterDataInAccount(account);   
                }
                if (suffix != null && suffix != string.Empty)
                {  
                    _PayeesPage.enterDataInSuffix(suffix);   
                }
            }
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickSaveAddField();
            
        }

        [Then(@"I clicked Name header for sorting the list")]
        public void ThenIClickedNameHeaderForSortingTheList()
        {
            _PayeesPage.clickNameField();
        }

        [Then(@"I verified that the list is sorted in descending order")]
        public void ThenIVerifiedThatTheListIsSortedInDescendingOrder()
        {
            System.Threading.Thread.Sleep(2000);
            //_PayeesPage.isPayeeTablePresent();
            var payeenames = _PayeesPage.GetAllPayeeNameasList();
            List<string> names = new List<string>();
            foreach (var item in payeenames)
            {
                names.Add(item.Text);
            }
            static bool IsSortedDescending(List<string> names)
            {
                for (int i = 0; i < names.Count - 1; i++)
                {
                    if (string.Compare(names[i], names[i + 1], StringComparison.Ordinal) < 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            bool isSortedDescending = IsSortedDescending(names);

            if (isSortedDescending)
            {
                Console.WriteLine("The name list is sorted in descending order.");
            }
            else
            {
                Console.WriteLine("The name list is not sorted in descending order.");
            }
        }


        [When(@"I cliked Pay link")]
        public void WhenIClikedPayLink()
        {
            _PayeesPage.clickPayLink();
        }

        [Then(@"I selected Everyday in From Account")]
        public void ThenISelectedEverydayInFromAccount()
        {
            _PayeesPage.clickFromChooseAccount();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickEveryDayAccount();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.getEveryDayBalance();
           // DataContext.EverydayAccountInitialBalance = Convert.ToDouble(_PayeesPage.getEveryDayBalance());
            //Console.WriteLine("Initial EverydayAccountBalance: $" + DataContext.EverydayAccountInitialBalance);


        }
        [Then(@"I selected Bils account option in To field")]
        public void ThenISelectedBilsAccountOptionInToField()
        {
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickToAccount();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickAccountsTab();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.clickBillAccount();
            _MenuPage.Waitfor2seconds();
            _PayeesPage.getBillBalance();
           // DataContext.BillsAccountInitialBalance = Convert.ToDouble(_PayeesPage.getBillBalance());
           // Console.WriteLine("Initial BillsAccountBalance Balance: $" + DataContext.BillsAccountInitialBalance);

        }

        [Then(@"Check the intial balance of Everyday account")]
       public void ThenCheckTheIntialBalanceOfEverydayAccount() 
       {
             DataContext.EverydayAccountInitialBalance = Convert.ToDouble(_PayeesPage.getEveryDayBalance());
           
            Console.WriteLine("Initial EverydayAccountBalance: $" + DataContext.EverydayAccountInitialBalance);
          

       }

       [Then(@"Check the intial balance of Bill account")]
       public void ThenCheckTheIntialBalanceOfBillAccount()
       {
           DataContext.BillsAccountInitialBalance = Convert.ToDouble(_PayeesPage.getBillBalance());
           Console.WriteLine("Initial BillsAccountBalance: $" + DataContext.BillsAccountInitialBalance);
       }



        [Then(@"I entered '([^']*)' in Account field and transfered the amount from Everyday to Bill Account")]
        public void ThenIEnteredInAccountFieldAndTransferedTheAmountFromEverydayToBillAccount(string amount)
        {

            //intValue = 500;
            //integerInput = intValue;
            //stringResult = integerInput.ToString();
            stringResult = amount.ToString();
            Console.WriteLine(stringResult);
            _PayeesPage.clickAmount();
            _PayeesPage.enterDataInAmount(stringResult);
            _PayeesPage.clickTransfer();

        }

        [Then(@"I verified successful message")]
        public void ThenIVerifiedSuccessfulMessage()
        {
            string expectedvalidationmessage = "Transfer successful";
            string actualvalidationmessage = _PayeesPage.transferMessage();
            Assert.AreEqual(expectedvalidationmessage, actualvalidationmessage, "Transferred the amount succeessfully");
            
        }

        [Then(@"I checked the current balance of Everyday account and Bills account")]
        public void ThenIVerifiedTheCurrentBalanceOfEverydayAccountAndBillsAccount()
        {
            _PayeesPage.clickBackButton();
            _MenuPage.Waitfor2seconds();
            //_PayeesPage.clickEveryDayAccountInHome();
           // _PayeesPage.getEveryDayBalanceInHome();
            DataContext.EverydayAccountCurrentBalance = Convert.ToDouble(_PayeesPage.getEveryDayBalanceInHome());
            
            //double EverydayAccountCurrentBalance = double.Parse(DataContext.EverydayAccountCurrentBalance.Replace("$", ""));
           // return EverydayAccountCurrentBalance
            Console.WriteLine("Current EverydayAccountBalance: $" + DataContext.EverydayAccountCurrentBalance);
            _MenuPage.Waitfor2seconds();
           // _PayeesPage.clickBillAccountInHome();
           // _PayeesPage.getBillBalanceInHome();
            DataContext.BillsAccountCurrentBalance = Convert.ToDouble(_PayeesPage.getBillBalanceInHome());
            Console.WriteLine("Current BillsAccountBalance: $" + DataContext.BillsAccountCurrentBalance);
            
        }


        [Then(@"I verified transfer is successful")]
        public void ThenIVerifiedTransferIsSuccessful()
        {
            if (DataContext.EverydayAccountCurrentBalance == DataContext.EverydayAccountInitialBalance - 500)
            {
                Console.WriteLine("Transfer Successful!");
            }
            else
            {
                Console.WriteLine("Transfer Failed.");
            }

            if (DataContext.BillsAccountCurrentBalance == DataContext.BillsAccountInitialBalance + 500)
            {
                Console.WriteLine("Transfer Successful!");
            }
            else
            {
                Console.WriteLine("Transfer Failed.");
            }
            
        }








    }
}
