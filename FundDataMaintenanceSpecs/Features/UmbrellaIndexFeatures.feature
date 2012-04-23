Feature: Umbrella Index Features
	As an authenticated user of any role
	I want to be able to view a list of all umbrellas


Scenario Outline: Umbrella Values are Viewable Outline
	Given I have navigated to the umbrella index page
	Then umbrella <value> are listed on the index page

Scenarios: Umbrella Values are Viewable Outline
	| value     |
	| name      |
	| code      |
	| custodian |
	| status    |


Scenario Outline: Umbrella Edit Screen is displayed on Umbrella Selection Outline
	Given I have navigated to the umbrella index page
	When I select umbrella with name <name>
	Then the umbrella edit page for <name> is displayed

Scenarios: Umbrella Edit Screen is displayed on Umbrella Selection Outline
	| name                                      |
	| Capital International Fund                |
	| Capital International Institutional Trust |
	| Capital International UK Fund             |

Scenario Outline: Umbrella Edit SCreen is displayed with editable fields for admin
	Given I have navigated to the umbrella index page
	When I select umbrella with name <name>
	Then the umbrella edit screen with <field> is displayed and <editable>

Scenarios: Umbrella Edit SCreen is displayed with editable fields for admin
	| name	                     | field | editable |
	| Capital International Fund | Code  | readonly |
	| Capital International Fund | Name  | editable |



Scenario Outline: Umbrella Custodian is displayed on Umbrella Selection Outline
	Given I have navigated to the umbrella index page
	When I select umbrella with name <name>
	Then the umbrella edit page custodian dropown is displayed

Scenarios: Umbrella Custodian is displayed on Umbrella Selection Outline
	| name                                      |
	| Capital International Fund                |
	| Capital International Institutional Trust |
	| Capital International UK Fund             |