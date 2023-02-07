using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BoDi;
using System.Threading.Tasks;
using BNZSpecFlowProject;
using OpenQA.Selenium.Internal;

namespace BNZ.Pages
{
    public class PayeesPage : BasePage
    {
        protected new IWebDriver Driver { get; }


        public PayeesPage(IWebDriver driver, IWait<IWebDriver> wait) : base(driver, wait)
        {
            Driver = driver;
        }
        private readonly By AddPayees = By.XPath("(//button[@aria-label='Add payee'])[2]");

        private readonly By PayeeName = By.XPath("//div[@class='inputs']//input[@type='text' and @placeholder='Enter a payee name']");

        private readonly By Placeholder  = By.XPath("//span[contains(.,'Someone new')]");

        private readonly By BanKField = By.XPath("//input[@placeholder='Bank']");

        private readonly By BranchField = By.XPath("//input[@placeholder='Branch']");

        private readonly By AccountField = By.XPath("//input[@placeholder='Account']");

        private readonly By SuffixField = By.XPath("//input[@placeholder='Suffix']");

        private readonly By SortByName = By.XPath("//span[contains(.,'Name')]");

        private readonly By PayorTransfer = By.XPath("//span[contains(.,'Pay or transfer')]");

        private readonly By ChooseFromAccount  = By.XPath("//span[contains(.,'Choose account')][1]");

        private readonly By ChooseToAccount = By.XPath("//span[contains(.,'Choose account, payee, or someone new')]");




        private readonly By SelectTypeofAccountsFromToFields   = By.XPath("//span[contains(.,'Accounts')]");


        private readonly By AddPayeeSubmitButton = By.XPath("//button[contains(.,'Add') and @class[contains(., 'js-submit')]]");

        private readonly By AddPayeeSubmitButtonDisabled  = By.XPath("//button[contains(.,'Add') and @class[contains(., 'js-submit Button Button--primary Button--disabled')]]");

        private readonly By PayeeAddedToastMessage  = By.XPath("//span[@role='alert' and text()='Payee added']");

        private readonly By PayeeRequiredFieldMessage  = By.XPath("//input[@aria-label='Payee Name is a required field. Please complete to continue.']");

        private readonly By EverydayAccount = By.XPath("//div[@id='account-ACC-1']//span[@class='account-balance']");

        private readonly By EverydayBills = By.XPath("//div[@id='account-ACC-5']//span[@class='account-balance']");


        private readonly By TransferAmountTxtField  = By.XPath("//input[@data-monitoring-label='Transfer Form Amount']");

        private readonly By TransferButton =  By.XPath("//button[@data-monitoring-label='Transfer Form Submit']//span[contains(.,'Transfer')]");




        public IList<string> GetallPayees() 
        {
            List<string> PayeeNames= new List<string>();
            var  elementName = Driver.FindElements(By.XPath("//span[@class='js-payee-name']"));
            foreach(var element in elementName) 
            { 
            
            PayeeNames.Add(element.Text);
            }
            return PayeeNames;
        }

        private By ToAccountType(string message)

        {
            return By.XPath("//div[@class='imageWrapper-0-5-62']//img[contains(@alt,'"+message+"')]");
        }


        
        private By FromAccountType(string message)

        {
            return By.XPath("//div[@class='imageWrapper-0-5-62']//img[@alt='"+message+"']");
        }

        public void SelectFromAccount(string AccountType)

        {
            System.Threading.Thread.Sleep(2000);
            ClickOnElement(FromAccountType(AccountType));
        }

        public void SelectToAccount(string AccountType)

        {
            System.Threading.Thread.Sleep(2000);
            ClickOnElement(ToAccountType(AccountType));
        }

        public void clickChooseFromAccount()
        {

            ClickOnElement(ChooseFromAccount);
        }

        public void clickChooseToccount()
        {

            ClickOnElement(ChooseToAccount);
        }

        public void ClickSelectAccountCategoryfromTo()
        {

            System.Threading.Thread.Sleep(2000);
            ClickOnElement(SelectTypeofAccountsFromToFields);
        }


        public void ClickTransferButtonforPayments()

        {
            ClickOnElement(TransferButton);

        }


        private By PayeesNames(string message) 
        
        { 
        return By.XPath("//span[contains(.,'"+message+ "') and @class='js-payee-name']");
        }

        public bool  IsPayeeNameDisplayedPayeesNames(string message)

        {
            return IsElementDisplayed(PayeesNames(message));
        }

        public void clickAddpayees()
        {

            ClickOnElement(AddPayees);
        }

      

        public void clickSortByName()
        {

            ClickOnElement(SortByName);

        }

        public void clickPayorTransfer()
        {

            ClickOnElement(PayorTransfer); ;


        }


        public void SetAmount(string  amount)
        {
            TypeOnElement(TransferAmountTxtField, amount);

        }

        public string GetEverydayaccountBalance()
        {

            return GetElementText(EverydayAccount);

        }

        public string GetBillsBalance()
        {

            return GetElementText(EverydayBills);

        }

        public void clickAddpayeesSubmitbuttonDisabled()
        {
            ClickOnElement(AddPayeeSubmitButtonDisabled);

        }

        public bool IsPayeeRequiredMessageDisplayed()
        {
            return IsElementDisplayed(PayeeRequiredFieldMessage);

        }

        public void clickAddpayeesSubmitbutton()
        {
            KeyBoardTabOnElement(SuffixField);
            ClickOnElement(AddPayeeSubmitButton);
            
        }
        public void TypePayeeName(string text)
        {

            TypeOnElement(PayeeName, text);
        }

        public void SelectPlaceholder()
        {

            ClickOnElement(Placeholder);
        }


        public void TypeBankDetails(string text)
        {

            TypeOnElement(BanKField, text);
        }

        public void TypeBranchDetails(string text)
        {

            TypeOnElement(BranchField, text);
        }

        public void TypeAccountDetails(string text)
        {

            TypeOnElement(AccountField, text);
        }

        public void TypeSuffixDetails(string text)
        {

            TypeOnElement(SuffixField, text);
        }
        public void Waitfor2seconds()
        {
            System.Threading.Thread.Sleep(2000);
        }

        public bool IsPayeeAddedToastDisplayed()
        {
            return IsElementDisplayed(PayeeAddedToastMessage);
        }

        public void Waitfor5seconds()
        {
            System.Threading.Thread.Sleep(5000);
        }

    }
}
