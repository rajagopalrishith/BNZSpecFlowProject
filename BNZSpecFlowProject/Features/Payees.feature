Feature: Payees

A short summary of the feature

@Payees
Scenario: Verify you can add new payee in the Payees page 
	Given Navigate to Payees page
	When Click ‘Add’ button above Payees list
    Then Enter data in Payee Name field  
	  | payeename  | 
	  | <payeename> | 

   Then Enter data in Payee Bank Account fields    
	  | bankcode  | branchnamecode   | account  | suffix  |
	  | <bankcode> | <branchnamecode> | <account> | <suffix> |
	Then Click ‘Add’ button in Payee details entry screen

	Then ‘Payee added’ message is displayed, and payee is added in the list of payees 
	
	Examples:
	|payeename | bankcode | branchnamecode | account | suffix |
	| divya   | 11       | 1111           | 1112224 | 010    |

    Scenario: Verify payee name is a required field
	Given Navigate to Payees page
	When Click ‘Add’ button above Payees list
	Then Click ‘Add’ button in Payee details entry screen
	Then validate payeename error
	Then I enter a character 'a' in PayeeName field
	Then I select an existing payee from the list
	Then Click ‘Add’ button in Payee details entry screen
	Then Enter data in For Payee field 
	 | forpayee  | 
	 | <forpayee>| 
	 Then Click ‘Add’ button in Payee details entry screen

	 Examples:
	|forpayee | 
	| Rishith |

	Scenario: Add a new payee and verify sorting by name
    Given Navigate to Payees page
    When I add a new payee "John Mark" and enter data in Payee Bank Account fields    
	  | bankcode  | branchnamecode   | account  | suffix  |
	  | <bankcode> | <branchnamecode> | <account> | <suffix> |
	Then I verified that the list is sorted in ascending order
	Then I clicked Name header for sorting the list
	Then I verified that the list is sorted in descending order
   

   Examples:
	 | bankcode | branchnamecode | account | suffix |
	 | 11       | 1111           | 1112224 | 010    |

	Scenario: In Payment page Transfer $500 from Everyday account to Bills account and verify the current balance of Everyday account and Bills account
	Given Navigate to Payees page
	When I cliked Pay link 
	Then I selected Everyday in From Account 
	Then I selected Bils account option in To field
	Then Check the intial balance of Everyday account
	Then Check the intial balance of Bill account
	Then I entered '$500' in Account field and transfered the amount from Everyday to Bill Account
	Then I verified successful message
	Then I checked the current balance of Everyday account and Bills account 
	Then I verified transfer is successful
	

