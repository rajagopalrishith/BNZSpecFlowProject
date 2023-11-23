using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using NUnit.Framework;

namespace BNZSpecFlowProject.Pages
{
    public class PayeesPage : BasePage
    {
        protected new IWebDriver Driver { get; }


        public PayeesPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }

        //Payees page fields

        private readonly By PayeesAddButton = By.XPath("//span[text()='Add']");
        private readonly By PayeesName = By.XPath("//input[@name='apm-name']");
        private readonly By PayeesNameSelection = By.XPath("//span[contains(text(),'Someone new']");
        //private readonly By PayeesNameSelection = By.XPath("(//span[@class='text'])[2]");
        private readonly By BankNameCode = By.Id("apm-bank");
        private readonly By BranchNameCode = By.Id("apm-branch");
        private readonly By Account = By.Id("apm-account");
        private readonly By Suffix = By.Id("apm-suffix");
        private readonly By PayeesSaveAddButton = By.XPath("//button[text()='Add']");
        private readonly By PayeesAddedMessage = By.XPath("//span[text()='Payee added']");
        private readonly By PayeesWarningHoverMessage =By.XPath("//input[@aria-label='Payee Name is a required field. Please complete to continue.']");

        private readonly By Payeeslist = By.XPath("//span[@title='A1 BUILDING CERTIFIERS LTD']");
        //private readonly By Payeeslist = By.XPath("//a[@data-cb-group='cb-companyGroup'])[3]");
        //private readonly By Payeeslist = By.XPath("//ul[@id='cb-companyGroup']/a[@data-cb-group='cb-companyGroup'])[2]");
        // private readonly By Payeeslist = By.XPath("//ul[@id='cb-companyGroup']/span[text()='Companies list, item 13,']");
        // private readonly By Payeeslist = By.XPath("//ul[@id='cb-companyGroup']/a[@data-cb-group='cb-companyGroup'][1]/span[text()='Companies list, item 7,']");
        private readonly By ForPayee = By.Id("apm-that-particulars");
         private readonly By PayeesListing = By.XPath("//span[@class='js-payee-name']");
        // private readonly By PayeesListing = By.XPath("//section[@class='CustomSection']//ul[1]/ul[@class='List List--border']");
        //private readonly By PayeesListing = By.XPath("//ul[@class='List List--border']");
        private readonly By NameHeader = By.XPath("//span[text()='Name']");
        private readonly By PayLink = By.XPath("(//span[text()='Pay'])[1]");
        private readonly By FromChooseAccount = By.XPath("//span[text()='Choose account']");
        private readonly By EveryDayAccountlabel = By.XPath("//p[text()='Everyday']");
        //private readonly By EveryDayAccountBalance = By.XPath("//p[text()='2,500.00 Avl.']");
        private readonly By EveryDayAccountBalance = By.XPath("//p[@class='balance-1-1-48']");
        //private readonly By EveryDayAccountBalance = By.XPath("(//div[@class='content-1-1-45'])[1]");

        private readonly By ToAccount = By.XPath("(//div[@class='content-1-1-36'])[2]");
        private readonly By Accounts = By.XPath("//span[text()='Accounts']");
        private readonly By BillsAccountlabel = By.XPath("//p[text()='Bills ']");
        //private readonly By BillAccountBalance = By.XPath("//p[text()='$420.00 Avl.']");
        private readonly By BillAccountBalance = By.XPath("(//p[@class='balance-1-1-48'])[2]");
        //private readonly By BillAccountBalance = By.XPath("(//div[@class='content-1-1-45'])[2]");
        private readonly By Amount = By.XPath("//input[@name='amount']");
        private readonly By Transfer = By.XPath("//span[text()='Transfer']");
        private readonly By TransferSuccessful = By.XPath("//span[@role='alert']");
        private readonly By BackButton= By.XPath("//span[text()='Back']");
        private readonly By EveryDayAccountBalanceinHome = By.XPath("(//span[@class='account-balance'])[1]");
        private readonly By BillBalanceinHome = By.XPath("(//span[@class='account-balance'])[3]");

        public void clickAddButton()
        {
            ClickOnElement(PayeesAddButton);
        }

        public void clickPayeeNameField()
        {
            ClickOnElement(PayeesName);
        }


        public void enterDataInPayeeName(string payeename)
        {
            TypeOnElement(PayeesName, payeename);
        }

        public void clickForPayeeField()
        {
            ClickOnElement(ForPayee);
        }

        public void enterDataInForPayee(string forpayee)
        {
            TypeOnElement(ForPayee, forpayee);
        }


        public void selectNewPayeeName(string payeename)
        {
            //   ClickOnElement(PayeesNameSelection);
            KeyBoardEnterOnElement(PayeesName, payeename);
        }

        public void clickBankNameField()
        {
            ClickOnElement(BankNameCode);

        }

        public void enterDataInBankName(String bankcode)
        {
            TypeOnElement(BankNameCode, bankcode);
        }
        public void clickBranchNameField()
        {
            ClickOnElement(BranchNameCode);

        }

        public void enterDataInBranchName(string branchnamecode)
        {
            TypeOnElement(BranchNameCode, branchnamecode);
        }

        public void clickAccountField()
        {
            ClickOnElement(Account);

        }

        public void enterDataInAccount(string account)
        {
            TypeOnElement(Account, account);
        }

        public void clickSuffixField()
        {
            ClickOnElement(Suffix);

        }

        public void enterDataInSuffix(string suffix)
        {
            TypeOnElement(Suffix, suffix);
        }

        public void clickSaveAddField()
        {

            ClickOnElement(PayeesSaveAddButton);

        }


        public void payeeWarning()
        {

           // HoverOnElement(PayeesWarningHoverMessage);
           GetElementText(PayeesWarningHoverMessage);
        }

       // public void confirmationMessageCheck()
       // {
       //     IsElementDisplayed(PayeesAddedMessage);

      //  }
        public string payeeAddedMessage()
        {
            return GetElementText(PayeesAddedMessage);

        }

        public void scrollToPayeeFromList()
        {
            ScrollToAnElement(Payeeslist);
            
        }


        public void clickanyPayeeFromList()
        {
            
            ClickOnElement(Payeeslist);
        }

        public bool isPayeeTablePresent()
        {
            return IsElementPresent(PayeesListing);
        }

        public List<IWebElement> GetAllPayeeNameasList()
        {
            return FindElements(PayeesListing);
        }
      //  public void getListNames() => FindElements(PayeesListing);

        public void clickNameField()
        {
            ClickOnElement(NameHeader);
        }

        public void clickPayLink()
        {
            ClickOnElement(PayLink);
        }

        public void clickFromChooseAccount()
        {
            ClickOnElement(FromChooseAccount);
        }

        public void clickEveryDayAccount()
        {
            ClickOnElement(EveryDayAccountlabel);
        }

      //  public void getEveryDayBalance()
       // {
        //    GetElementText(EveryDayAccountBalance);
       // }

        public string getEveryDayBalance()
        {
            return GetElementValue(EveryDayAccountBalance);
        }

        public void clickToAccount()
        {
            ClickOnElement(ToAccount);
        }

        public void clickAccountsTab()
        {
            ClickOnElement(Accounts);
        }

        public void clickBillAccount()
        {
            ClickOnElement(BillsAccountlabel);
        }



        public string getBillBalance()
        {
            //GetElementText(BillAccountBalance);
            return GetElementValue(BillAccountBalance);
        }

        public void clickAmount()
        {
            ClickOnElement(Amount);

        }
        public void enterDataInAmount(string stringResult)
        {
            TypeOnElement(Amount, stringResult);
        }

        public void clickTransfer()
        {
            ClickOnElement(Transfer);

        }

        public string transferMessage()
        {
            return GetElementText(TransferSuccessful);
            

        }

        public void clickBackButton()
        {
            ClickOnElement(BackButton);
        }

        public void clickEveryDayAccountInHome()
        {
            ClickOnElement(EveryDayAccountBalanceinHome);
        }

        public string getEveryDayBalanceInHome()
        {
           return GetElementValue(EveryDayAccountBalanceinHome);
        }

        public void clickBillAccountInHome()
        {
            ClickOnElement(BillBalanceinHome);
        }

        public string getBillBalanceInHome()
        {
            return GetElementText(BillBalanceinHome);
        }




    }
}
