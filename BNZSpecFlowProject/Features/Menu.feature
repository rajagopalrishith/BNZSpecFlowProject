Feature: Menu

A short summary of the feature

@Menu
Scenario: Verify you can navigate to Payees page using the navigation menu
	Given I open the bnz application home page
	When I click Menu option
	Then I click Payees link from the menulist
	Then Verify Payees page is loaded


