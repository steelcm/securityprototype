Feature: Sign-in
	In order to avoid anybody from editing fund data information
	I want to be asked to authenticate myself

Scenario Outline: appropriate form fields are available
	Given I am on the sign-in page
	Then the <field-name> field is presented

Scenarios: appropriate form fields are available
	| field-name |
	| Username   |
	| Password   |
	| RememberMe |

Scenario: unable to login when provide no credentials
	Given I am on the sign-in page
	When I click the sign-in button
	Then the sign-in page will be displayed with an error

Scenario: unable to login when only my cg initials are provided
	Given I am on the sign-in page
	And I enter my username
	When I click the sign-in button
	Then the sign-in page will be displayed with an error

Scenario: unable to login when only my password is provided
	Given I am on the sign-in page
	And I enter my password
	When I click the sign-in button
	Then the sign-in page will be displayed with an error

Scenario Outline: unable to login when I provide one incorrect and one correct field
	Given I am on the sign-in page
	And I correctly enter my <field-1>
	And I incorrectly enter my <field-2>
	When I click the sign-in button
	Then the sign-in page will be displayed with an error

Scenarios: unable to login when I provide one incorrect and one correct field
	| field-1  | field-2  |
	| Username | Password |
	| Password | Username |
