Feature: AccountsFeature


Background:
Given I open the bnz demo application home page

@regression
Scenario: Verify Payees Page is loaded
	Given I click CheckitOut Option
	When I select Menu
	And I select Payees
	Then I verify payees page is loaded


@regression
Scenario: Verify you can add new payee in the Payees page
	Given I click CheckitOut Option
	When I select Menu
	And I select Payees
	And I click Add Payees Option
	And I enter Payee Name Raj
	And I enter bank information as below
	| Bank    | Branch     | Account      | Suffix |
	| 01      | 0061       |  1023333     |   22   |
	And I click submit button 
	Then I verify Payee added message is displayed
	And I verify Payee with name Raj is in the list of Payees added 


@regression
Scenario: Verify Payee Name is a required field
	Given I click CheckitOut Option
	When I select Menu
	And I select Payees
	And I click Add Payees Option
	And I click disabled submit button 
	And I verify mandatory message is shown for Payee field 


@regression
Scenario: Verify that Payees can be sorted by name
	Given I click CheckitOut Option
	When I select Menu
	And I select Payees
	Then I verify the list is sorted Ascending by default
	And I sort the payees list by name 
	Then I verify the list is sorted Descending by default

@regression
Scenario: Verify that payments transfer are correctly updated to respective accounts 
	Given I click CheckitOut Option
	And I fetch balances of accounts
	When I select Menu
	And I click Pay or transfer option
	And I transfer amount as per below parameters
	| FromAccount | ToAccount | Amount |
	| Everyday    | Bills     | 1000   |
   Then I verify the accounts are updated as per below table
   | FromAccount | ToAccount | Amount |
   | Everyday    | Bills     | 1000   |
	
